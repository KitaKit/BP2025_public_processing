using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GenotypeApp.Interface_elements_extensions
{
    internal static class TreeViewExtensions
    {
        public static void PopulateProjectFolders(this TreeView treeView, string populatePath)
        {
            ArgumentNullException.ThrowIfNull(treeView);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(populatePath);

            treeView.Nodes.Clear();

            TreeNode rootNode = new TreeNode(ProjectInformationModel.Instance.ProjectName) { Tag = populatePath };
            treeView.Nodes.Add(rootNode);

            Stack<(string DirectoryPath, TreeNode Node)> stack = new Stack<(string, TreeNode)>();
            stack.Push((populatePath, rootNode));

            while (stack.Count > 0)
            {
                var (currentFolder, parentNode) = stack.Pop();

                IEnumerable<string> directories;
                try
                {
                    directories = Directory.EnumerateDirectories(currentFolder).OrderBy(d => d);
                }
                catch (UnauthorizedAccessException uaEx)
                {
                    parentNode.Nodes.Add("[Access Denied]");
                    continue;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in folder processing '{currentFolder}': {ex.Message}");
                    continue;
                }

                foreach (string directoryPath in directories)
                {
  
                    string directoryName = Path.GetFileName(directoryPath);
                    TreeNode directoryNode = new TreeNode(directoryName) { Tag = directoryPath };
                    parentNode.Nodes.Add(directoryNode);

                    try
                    {
                        var files = Directory.EnumerateFiles(directoryPath).OrderBy(f => f);
                        foreach (string filePath in files)
                        {
                            string fileName = Path.GetFileName(filePath);
                            TreeNode fileNode = new TreeNode(fileName) { Tag = filePath };
                            directoryNode.Nodes.Add(fileNode);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        directoryNode.Nodes.Add("[Access Denied]");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error when processing files in '{directoryPath}': {ex.Message}");
                    }

                    stack.Push((directoryPath, directoryNode));
                }
            }
        }

        private static TreeNode FindNodeByPath(TreeNodeCollection nodes, string targetPath)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag?.ToString().Equals(targetPath, StringComparison.OrdinalIgnoreCase) == true)
                    return node;

                TreeNode found = FindNodeByPath(node.Nodes, targetPath);
                if (found != null)
                    return found;
            }
            return null;
        }
        public static void UpdateNode(this TreeView treeView, string parentPath)
        {
            if (treeView == null) throw new ArgumentNullException(nameof(treeView));
            if (string.IsNullOrWhiteSpace(parentPath)) return;

            TreeNode parentNode = FindNodeByPath(treeView.Nodes, parentPath);
            if (parentNode == null || !Directory.Exists(parentPath))
                return;

            treeView.BeginUpdate();
            try
            {
                var existing = parentNode.Nodes
                    .Cast<TreeNode>()
                    .ToDictionary(n => (string)n.Tag!, n => n);

                foreach (var dir in Directory.EnumerateDirectories(parentPath).OrderBy(d => d))
                {
                    if (existing.TryGetValue(dir, out var node))
                    {
                        existing.Remove(dir);
                    }
                    else
                    {
                        node = new TreeNode(Path.GetFileName(dir)) { Tag = dir };
                        parentNode.Nodes.Add(node);
                    }
                }

                foreach (var file in Directory.EnumerateFiles(parentPath).OrderBy(f => f))
                {
                    if (existing.TryGetValue(file, out var node))
                    {
                        existing.Remove(file);
                    }
                    else
                    {
                        node = new TreeNode(Path.GetFileName(file)) { Tag = file };
                        parentNode.Nodes.Add(node);
                    }
                }

                foreach (var orphan in existing.Values)
                    parentNode.Nodes.Remove(orphan);
            }
            catch (UnauthorizedAccessException)
            {
            }
            finally
            {
                treeView.EndUpdate();
            }

            parentNode.Expand();
        }
    }
}
