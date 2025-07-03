using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using GenotypeApp.Application_logic;

namespace GenotypeApp.Interface_elements_extensions
{
    internal static class ComboBoxExtensions
    {
        public static bool PopulateParameterSets(this ComboBox comboBox, string path, bool canBeNewCreated = false)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(path);

            var items = canBeNewCreated ? new List<string> { "New parameter set..." } : new List<string>();

            if (Directory.Exists(path))
                items.AddRange(new DirectoryInfo(path).EnumerateDirectories().Select(d => d.Name).OrderBy(name => name));

            comboBox.DataSource = items;

            if (comboBox.Items.Count > 0)
                return true;

            return false;
        }

        public static void PopulateByNumberRange(this ComboBox comboBox, int start, int end)
        {
            var list = Enumerable.Range(start, end - start + 1).Select(k => k.ToString()).ToList();

            comboBox.DataSource = list;
            comboBox.SelectedIndex = 0;
        }

        public static void PopulateComboBoxWithFiles(this ComboBox comboBox, string directoryPath, string searchPattern = null)
        {
            comboBox.Items.Clear();

            if (!Directory.Exists(directoryPath))
            {
                return;
            }

            string[] files = searchPattern == null
                ? Directory.GetFiles(directoryPath)
                : Directory.GetFiles(directoryPath, searchPattern);

            foreach (var filePath in files)
            {
                comboBox.Items.Add(Path.GetFileName(filePath));
            }
        }

        public static void PopulateAndSelect<T>(
            this ComboBox comboBox,
            HashSet<T> items,
            string itemText
        ) where T : IHasSetName
        {
            if (comboBox == null)
                throw new ArgumentNullException(nameof(comboBox));

            comboBox.Items.Clear();

            foreach (var it in items)
            {
                comboBox.Items.Add(it.SetName);
            }

            comboBox.SelectByText(itemText);
        }

        public static void SelectByText(this ComboBox comboBox, string itemText)
        {
            if (string.IsNullOrWhiteSpace(itemText))
            {
                comboBox.SelectedIndex = -1;
                return;
            }

            int idx = comboBox.FindStringExact(itemText);
            comboBox.SelectedIndex = idx >= 0 ? idx : -1;
        }

        private static T FindByName<T>(
            IEnumerable<T> list,
            string setName
        )
        {
            if (string.IsNullOrWhiteSpace(setName))
                return default;

            var prop = typeof(T).GetProperty("SetName", BindingFlags.Public | BindingFlags.Instance);
            if (prop == null || prop.PropertyType != typeof(string))
                throw new ArgumentException($"Type {typeof(T).Name} does not contain string SetName.");

            return list
                .FirstOrDefault(item => {
                    var val = (string)prop.GetValue(item);
                    return val?.Equals(setName, StringComparison.OrdinalIgnoreCase) ?? false;
                });
        }
        public static T GetSelectedItem<T>(
            this ComboBox comboBox,
            IEnumerable<T> list
        )
        {
            var name = comboBox.SelectedItem?.ToString();
            return FindByName(list, name);
        }
    }
}