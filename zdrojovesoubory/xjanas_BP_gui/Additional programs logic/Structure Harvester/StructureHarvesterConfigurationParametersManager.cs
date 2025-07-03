using System;
using System.Collections.Generic;
using System.IO;

namespace GenotypeApp.Additional_programs_logic.Structure_Harvester
{
    public static class StructureHarvesterConfigurationParametersManager
    {
        private static StructureHarvesterConfigurationParametersModel _currentParameterSet;
        private static HashSet<StructureHarvesterConfigurationParametersModel> _parameterSetList = new HashSet<StructureHarvesterConfigurationParametersModel>();

        public static StructureHarvesterConfigurationParametersModel CurrentParameterSet { get => _currentParameterSet; set => _currentParameterSet = value; }
        public static HashSet<StructureHarvesterConfigurationParametersModel> ParameterSetList { get => _parameterSetList; }

        public static int? GetIndivCountFromOutputFile(int kStart, string baseDirectory)
        {
            string fileName = $"K{kStart}.indfile";
            string filePath = Path.Combine(baseDirectory, fileName);

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            int? maxValue = null;
            int? previousValue = null;

            foreach (var rawLine in File.ReadLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(rawLine))
                    continue;

                var parts = rawLine.Trim().Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0)
                    continue;

                if (!int.TryParse(parts[0], out int current))
                    continue;

                if (previousValue.HasValue)
                {
                    if (current < previousValue.Value)
                        break;
                }

                if (!maxValue.HasValue || current > maxValue.Value)
                    maxValue = current;

                previousValue = current;
            }

            return maxValue;
        }

        public static int GetPopCountFromOutputFile(int kStart, string baseDirectory)
        {
            string fileName = $"K{kStart}.popfile";
            string filePath = Path.Combine(baseDirectory, fileName);

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            int maxValue = 0;
            int? previousValue = null;

            foreach (var rawLine in File.ReadLines(filePath))
            {
                var line = rawLine?.Trim();
                if (string.IsNullOrEmpty(line))
                    continue;

                int colonIdx = line.IndexOf(':');
                if (colonIdx < 0)
                    continue;

                var numStr = line.Substring(0, colonIdx).Trim();
                if (!int.TryParse(numStr, out int current))
                    continue;

                if (previousValue.HasValue && current < previousValue.Value)
                    break;

                if (current > maxValue)
                    maxValue = current;
                previousValue = current;
            }

            return maxValue;
        }
    }
}
