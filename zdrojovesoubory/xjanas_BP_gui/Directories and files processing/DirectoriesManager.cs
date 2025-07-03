using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GenotypeApp
{
    internal static class DirectoriesManager
    {
        private static readonly string _rootFolderPath = AppContext.BaseDirectory;
        public static string RootPath => _rootFolderPath;

        public static void CreateDirectory(string path, string name = null)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(path);

            string targetPath = string.IsNullOrWhiteSpace(name) ? path : Path.Combine(path, name);

            Directory.CreateDirectory(targetPath);
        }
        public static void DeleteDirectory(string path)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(path);

            Directory.Delete(path, true);   
        }
        public static bool SyncProgramDirectories()
        {
            var projectPath = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);

            var selected = ProjectInformationModel.Instance
                .UsedSubPrograms
                .Where(kv => kv.Value)
                .Select(kv => kv.Key)
                .ToList();

            var existing = Directory.Exists(projectPath)
                ? Directory
                    .GetDirectories(projectPath)
                    .Select(Path.GetFileName)
                    .ToList()
                : new List<string>();

            var toCreate = selected.Except(existing).ToArray();
            var toDelete = existing.Except(selected).ToArray();

            if (toCreate.Length > 0)
            {
                DirectoriesManager.CreateAdditionalProgramsDirectories(toCreate);
            }

            // 7) Если есть что удалить — спрашиваем пользователя
            if (toDelete.Length > 0)
            {
                var list = string.Join("\n", toDelete);
                var prompt =
                    $"The following folders will be deleted:\n\n{list}\n\n" +
                    "Select an action:\n" +
                    "• Yes — delete and continue\n" +
                    "• No — copy the project and work in a copy\n" +
                    "• Cancel — do nothing";

                var result = MessageBox.Show(
                    prompt,
                    "Confirm the deletion",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                {
                    return false;
                }

                if (result == DialogResult.No)
                {
                    var backupRoot = Path.Combine(
                        ProjectInformationModel.Instance.ProjectPath,
                        ProjectInformationModel.Instance.ProjectName
                          + "_Copy_" + DateTime.Now.ToString("yyyyMMdd_HHmm"));

                    CopyDirectory(projectPath, backupRoot);

                    MessageBox.Show(
                        $"The project is copied to:\n{backupRoot}",
                        "Copying completed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ProjectInformationModel.Instance.ProjectName = Path.GetFileName(backupRoot);
                    projectPath = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);
                }

                if (Directory.Exists(projectPath))
                {
                    foreach (var dirName in toDelete)
                    {
                        var fullPath = Path.Combine(projectPath, dirName);
                        try
                        {
                            Directory.Delete(fullPath, recursive: true);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Couldn't be deleted {fullPath}: {ex.Message}");
                        }
                    }
                }
            }
            return true;
        }

        private static void CopyDirectory(string sourceDir, string targetDir)
        {
            var dirInfo = new DirectoryInfo(sourceDir);
            if (!dirInfo.Exists)
                throw new DirectoryNotFoundException($"The source folder was not found: {sourceDir}");

            Directory.CreateDirectory(targetDir);

            foreach (var file in dirInfo.GetFiles())
            {
                file.CopyTo(Path.Combine(targetDir, file.Name), overwrite: true);
            }

            foreach (var subDir in dirInfo.GetDirectories())
            {
                CopyDirectory(subDir.FullName, Path.Combine(targetDir, subDir.Name));
            }
        }
        public static void CreateAdditionalProgramsDirectories(string[] programsList)
        {
            ArgumentNullException.ThrowIfNull(programsList);

            string commonPath = Path.Combine(ProjectInformationModel.Instance.ProjectPath, ProjectInformationModel.Instance.ProjectName);

            DirectoriesManager.CreateDirectory(commonPath);

            foreach (string program in programsList)
                CreateDirectory(commonPath, program);
        }
    }
}
