using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenotypeApp.Application_logic
{
    internal static class FilesManager
    {
        public static void CopyFile(string originalPath, string originalName, string newPath = null, string newName = null)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(originalPath);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(originalName);
            
            string sourcePath = Path.Combine(originalPath, originalName);

            if (!File.Exists(sourcePath))
                throw new FileNotFoundException(sourcePath);

            string targetDirectory = string.IsNullOrWhiteSpace(newPath) ? originalPath : newPath;
            DirectoriesManager.CreateDirectory(targetDirectory);

            string targetFile = string.IsNullOrWhiteSpace(newName) ? originalName : newName;
            string targetPath = Path.Combine(targetDirectory, targetFile);

            if (!File.Exists(targetPath))
                File.Copy(sourcePath, targetPath);
            else
                File.Copy(sourcePath, targetPath, overwrite: true);
        }
        public static void WriteFileByList(List<string> dataList, string path, string name = null)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(path);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(name);

            string targetPath = string.IsNullOrWhiteSpace(name) ? path : Path.Combine(path, name);

            using (var writer = new StreamWriter(targetPath, false, new UTF8Encoding(false)))
            {
                foreach (var line in dataList)
                {
                    writer.Write(line + '\n');
                }
            }
        }
        public static List<string> ReadFileToList(string path, string name = null)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            var fullPath = string.IsNullOrWhiteSpace(name)
                ? path
                : Path.Combine(path, name);
            try
            {
                return File.ReadAllLines(fullPath, new UTF8Encoding(false)).ToList();
            }
            catch 
            {
                return new List<string>();
            }
        }
    }
}
