using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GenotypeApp.Interface_elements_extensions
{
    internal static class DataGridViewExtensions
    {
        public static void LoadDataFile(this DataGridView dataTable, string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Input file not found.", filePath);

            var lines = File.ReadAllLines(filePath)
                            .Where(l => !string.IsNullOrWhiteSpace(l))
                            .ToArray();

            var parsed = lines
                .Select(line =>
                {
                    var m = Regex.Match(line, @"^([\t ]*)(.*)$");
                    int offset = m.Groups[1].Value.Length;

                    var tokens = Regex.Split(m.Groups[2].Value.Trim(), @"\s+");
                    return new { offset, tokens };
                })
                .ToList();

            int maxCols = parsed.Max(x => x.offset + x.tokens.Length);

            var table = new DataTable();
            for (int i = 0; i < maxCols; i++)
                table.Columns.Add($"Column{i + 1}", typeof(string));

            foreach (var rowData in parsed)
            {
                var row = table.NewRow();
                for (int j = 0; j < rowData.tokens.Length; j++)
                {
                    row[rowData.offset + j] = rowData.tokens[j];
                }
                table.Rows.Add(row);
            }

            dataTable.DataSource = table;
        }
    }
}
