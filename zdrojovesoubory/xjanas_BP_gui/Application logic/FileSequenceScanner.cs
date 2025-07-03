using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace GenotypeApp.Additional_programs_logic.Structure
{
    internal static class FileSequenceScanner
    {
        private static readonly Regex FilePattern =
        new Regex(@"^K(?<k>\d+)-i(?<i>\d+)_f$", RegexOptions.Compiled);
        private static readonly Regex TypePattern =
        new Regex(@"^K(?<k>\d+)\.(?<type>popq|indiv)$", RegexOptions.Compiled);

        public static (int maxK, int maxI) FindMaxKi(string directoryPath)
        {
            if (directoryPath == null) throw new ArgumentNullException(nameof(directoryPath));
            if (!Directory.Exists(directoryPath)) throw new DirectoryNotFoundException(directoryPath);

            var sequences = new Dictionary<int, HashSet<int>>();

            foreach (var filePath in Directory.GetFiles(directoryPath))
            {
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                var m = FilePattern.Match(fileName);
                if (!m.Success) continue;

                int k = int.Parse(m.Groups["k"].Value);
                int i = int.Parse(m.Groups["i"].Value);

                if (!sequences.TryGetValue(k, out var set))
                {
                    set = new HashSet<int>();
                    sequences[k] = set;
                }
                set.Add(i);
            }

            int maxK = 0;
            for (int k = 1; ; k++)
            {
                if (sequences.ContainsKey(k))
                    maxK = k;
                else
                    break;
            }

            if (maxK == 0)
                return (0, 0);

            var iSet = sequences[maxK];
            int maxI = 0;
            for (int i = 1; ; i++)
            {
                if (iSet.Contains(i))
                    maxI = i;
                else
                    break;
            }

            return (maxK, maxI);
        }

        public static (int maxPopqK, int maxIndivK) FindMaxKByType(string directoryPath)
        {
            if (directoryPath == null) throw new ArgumentNullException(nameof(directoryPath));
            if (!Directory.Exists(directoryPath)) throw new DirectoryNotFoundException(directoryPath);

            var popqSet = new HashSet<int>();
            var indivSet = new HashSet<int>();

            foreach (var filePath in Directory.GetFiles(directoryPath))
            {
                var fileName = Path.GetFileName(filePath);
                var m = TypePattern.Match(fileName);
                if (!m.Success) continue;

                int k = int.Parse(m.Groups["k"].Value);
                var type = m.Groups["type"].Value;

                if (type == "popq")
                    popqSet.Add(k);
                else if (type == "indiv")
                    indivSet.Add(k);
            }

            int maxPopqK = 0;
            for (int k = 1; ; k++)
            {
                if (popqSet.Contains(k))
                    maxPopqK = k;
                else
                    break;
            }

            int maxIndivK = 0;
            for (int k = 1; ; k++)
            {
                if (indivSet.Contains(k))
                    maxIndivK = k;
                else
                    break;
            }

            return (maxPopqK, maxIndivK);
        }
    }
}
