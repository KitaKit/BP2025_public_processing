using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace GenotypeApp.Additional_programs_logic.Structure
{
    internal static class StructureInputDataPredictor
    {
        private sealed record Sample(IReadOnlyList<string[]> Rows, int ModalColumnCount);

        private static Sample BuildSample(
            string filePath,
            string? delimiter,
            char commentChar,
            int sampleSize)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Input file not found.", filePath);
            if (sampleSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(sampleSize));

            var rows = new List<string[]>(sampleSize);
            var counts = new Dictionary<int, int>();

            foreach (var raw in File.ReadLines(filePath))
            {
                var line = raw.TrimStart();        
                if (line.Length == 0 || line[0] == commentChar)
                    continue;

                var parts = string.IsNullOrWhiteSpace(delimiter)
                    ? line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)
                    : line.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 0)
                    continue;

                rows.Add(parts);

                if (!counts.TryAdd(parts.Length, 1))
                    counts[parts.Length]++;

                if (rows.Count >= sampleSize)
                    break;
            }

            if (rows.Count == 0)
                throw new InvalidOperationException("No data lines found to analyse.");

            int modal = counts
                .OrderByDescending(kv => kv.Value)
                .ThenBy(kv => kv.Key)
                .First()
                .Key;

            return new Sample(rows, modal);
        }

        public static bool DetectLabel(
        string filePath,
        string delimiter = null,
        char commentChar = '#',
        int sampleSize = 1000,
        double nonNumericRatio = 0.5,
        int sampleSizeMin = 20)
        {
            var sample = BuildSample(filePath, delimiter, commentChar, sampleSize);
            var rows = sample.Rows;

            int modalCount = sample.ModalColumnCount;

            int count = 0;
            int nonNumeric = 0;
            var intValues = new List<long>();

            foreach (var parts in rows)
            {
                if (parts.Length != modalCount)
                    continue;

                var first = parts[0];
                if (!double.TryParse(first, out var d))
                    nonNumeric++;
                else if (d % 1 == 0)
                    intValues.Add((long)d);

                if (++count >= sampleSize && count >= sampleSizeMin)
                    break;
            }

            if (count == 0)
                throw new InvalidOperationException("No data lines found in the file.");

            double ratio = (double)nonNumeric / count;
            if (ratio >= nonNumericRatio)
                return true;

            if (intValues.Count == count)
            {
                var uniqueSorted = intValues.Distinct().OrderBy(x => x).ToList();
                if (uniqueSorted.Count > 1)
                {
                    bool continuous = true;
                    for (int i = 1; i < uniqueSorted.Count; i++)
                    {
                        if (uniqueSorted[i] - uniqueSorted[i - 1] != 1)
                        {
                            continuous = false;
                            break;
                        }
                    }
                    if (continuous)
                        return true;
                }

                var groupSizes = new List<int>();
                int currentSize = 1;
                for (int i = 1; i < intValues.Count; i++)
                {
                    if (intValues[i] == intValues[i - 1])
                        currentSize++;
                    else
                    {
                        groupSizes.Add(currentSize);
                        currentSize = 1;
                    }
                }
                groupSizes.Add(currentSize);

                if (groupSizes.Count > 1 && groupSizes[^1] < groupSizes[0])
                    groupSizes.RemoveAt(groupSizes.Count - 1);

                var distinctSizes = groupSizes.Distinct().ToList();
                if (distinctSizes.Count == 1 && distinctSizes[0] > 1)
                    return true;

                if (intValues.Distinct().Count() == count)
                    return true;
            }
            return false;
        }

        public static bool DetectOneRowPerInd(
        string filePath,
        string delimiter = null,
        char commentChar = '#',
        int sampleSize = 1000)
        {
            var sample = BuildSample(filePath, delimiter, commentChar, sampleSize);
            var rows = sample.Rows;

            bool hasLabel = StructureParametersModel.Instance.mainparams.PREDICTED_LABEL;
            int modalCount = sample.ModalColumnCount;

            if (hasLabel)
            {
                var groupSizes = new List<int>();
                int count = 0;
                string prev = null;
                int currentSize = 0;

                foreach (var parts in rows)
                {
                    if (parts.Length != modalCount)
                        continue;

                    string id = parts[0];
                    if (prev == null || id == prev)
                    {
                        currentSize++;
                    }
                    else
                    {
                        groupSizes.Add(currentSize);
                        currentSize = 1;
                    }
                    prev = id;

                    if (++count >= sampleSize)
                        break;
                }
                groupSizes.Add(currentSize);

                if (groupSizes.Count > 1 && groupSizes[^1] < groupSizes[0])
                    groupSizes.RemoveAt(groupSizes.Count - 1);

                return groupSizes.All(g => g == 1);
            }
            else
            {
                var mp = StructureParametersModel.Instance?.mainparams;
                if (mp != null && mp.PREDICTED_NUMLOCI > 0 && mp.PREDICTED_PLOIDY > 0)
                {
                    int alleleCols = modalCount;
                    if (alleleCols == mp.PREDICTED_NUMLOCI * mp.PREDICTED_PLOIDY)
                        return true;
                    if (alleleCols == mp.PREDICTED_NUMLOCI)
                        return false;
                }

                return true;
            }
        }

        public static bool DetectPopData(
            string filePath,
            string delimiter = null,
            char commentChar = '#',
            int sampleSize = 1000,
            double validRatioLarge = 0.5,
            int sampleSizeMin = 20)
        {
            var sample = BuildSample(filePath, delimiter, commentChar, sampleSize);
            var rows = sample.Rows;

            int modalCount = sample.ModalColumnCount;
            bool hasLabel = StructureParametersModel.Instance.mainparams.PREDICTED_LABEL;
            int popDataIndex = hasLabel ? 1 : 0;

            var popCounts = new Dictionary<int, int>();
            var alleleSamples = new List<string>();
            int scanned = 0;
            int validPositive = 0;

            foreach (var parts in rows)
            {
                if (parts.Length != modalCount)
                    continue;

                if (int.TryParse(parts[popDataIndex], out int code))
                {
                    if (!popCounts.TryGetValue(code, out var c)) popCounts[code] = 0;
                    popCounts[code] = c + 1;
                    if (code > 0) validPositive++;
                }

                if (!hasLabel && popDataIndex + 1 < parts.Length && alleleSamples.Count < 200)
                    alleleSamples.Add(parts[popDataIndex + 1]);

                scanned++;
                if (scanned >= sampleSize && scanned >= sampleSizeMin)
                    break;
            }

            if (scanned == 0 || popCounts.Count == 0)
                return false;

            bool onlyZeroOne = popCounts.Keys.All(v => v == 0 || v == 1);
            if (onlyZeroOne)
            {
                int minRep = Math.Max(1, scanned / 10);
                bool balanced = popCounts.Values.Min() >= minRep;
                return balanced;
            }

            double minValidRatio = scanned < 20 ? 0.3 : validRatioLarge;
            if ((double)validPositive / scanned < minValidRatio)
                return false;

            if (scanned >= 10 && popCounts.Any(kvp => kvp.Value < 2))
                return false;

            if (scanned / popCounts.Count < 2)
                return false;

            if (!hasLabel && alleleSamples.Count > 0)
            {
                int alleleUniques = alleleSamples.Distinct().Count();
                if (alleleUniques - popCounts.Count < 3)
                    return false;
            }

            return true;
        }

        public static bool DetectPopFlag(
            string filePath,
            string delimiter = null,
            char commentChar = '#',
            int sampleSize = 1000,
            double minorityRatioThreshold = 0.05)
        {
            var sample = BuildSample(filePath, delimiter, commentChar, sampleSize);
            var rows = sample.Rows;

            int modalCount = sample.ModalColumnCount;

            int flagIndex = (StructureParametersModel.Instance.mainparams.PREDICTED_LABEL ? 1 : 0) +
                            (StructureParametersModel.Instance.mainparams.PREDICTED_POPDATA ? 1 : 0);

            bool oneRowPerInd = StructureParametersModel.Instance.mainparams.PREDICTED_ONEROWPERIND;

            int scanned = 0;
            int count0 = 0, count1 = 0;
            var values = new List<int>(sampleSize);

            foreach (var parts in rows)
            {
                if (parts.Length != modalCount) continue;

                if (!int.TryParse(parts[flagIndex], out int v))
                    continue;
                if (v != 0 && v != 1) return false;

                if (v == 0) count0++; else count1++;
                values.Add(v);

                if (++scanned >= sampleSize) break;
            }

            if (scanned == 0) return false;

            int minority = Math.Min(count0, count1);
            if (minority > 0)
            {
                double ratio = (double)minority / scanned;
                double threshold = scanned < 10 ? 1.0 : minorityRatioThreshold;
                if (ratio > threshold) return false;
            }

            if (!oneRowPerInd)
            {
                var groupSizes = new List<int>();
                int cur = 1;
                for (int i = 1; i < values.Count; i++)
                {
                    if (values[i] == values[i - 1]) cur++;
                    else { groupSizes.Add(cur); cur = 1; }
                }
                groupSizes.Add(cur);
                if (groupSizes[^1] == 1 && groupSizes.Count > 1)
                    groupSizes.RemoveAt(groupSizes.Count - 1);

                if (groupSizes.Count == 0 || groupSizes.Any(sz => sz != 2))
                    return false;
            }

            return true;
        }

        public static bool DetectLocData(
            string filePath,
            string delimiter = null,
            char commentChar = '#',
            int sampleSize = 1000,
            double maxUniqueRatio = 0.4)
        {
            var sample = BuildSample(filePath, delimiter, commentChar, sampleSize);
            var rows = sample.Rows;

            int modalCount = sample.ModalColumnCount;

            int locIndex = (StructureParametersModel.Instance.mainparams.PREDICTED_LABEL ? 1 : 0) +
                           (StructureParametersModel.Instance.mainparams.PREDICTED_POPDATA ? 1 : 0) +
                           (StructureParametersModel.Instance.mainparams.PREDICTED_POPFLAG ? 1 : 0);

            bool oneRow = StructureParametersModel.Instance.mainparams.PREDICTED_ONEROWPERIND;

            int hardCap = sampleSize;
            int sampleSizeMin = 20;

            var counts = new Dictionary<int, int>();
            int scanned = 0;
            int lastId = int.MinValue;  
            int sequentialCount = 0;    
            var groupSizes = oneRow ? null : new List<int>();

            foreach (var parts in rows)
            {
                if (parts.Length != modalCount)
                    continue;

                if (!int.TryParse(parts[locIndex], out int val) || val < 0)
                    continue;

                counts[val] = counts.TryGetValue(val, out int c) ? c + 1 : 1;

                if (!oneRow)
                {
                    if (val == lastId)
                        sequentialCount++;
                    else
                    {
                        if (sequentialCount > 0) groupSizes!.Add(sequentialCount);
                        sequentialCount = 1;
                        lastId = val;
                    }
                }

                scanned++;
                if (scanned >= hardCap && scanned >= sampleSizeMin) break;
            }
            if (!oneRow && sequentialCount > 0) groupSizes!.Add(sequentialCount);

            if (scanned == 0)
                return false;

            double uniqueRatio = (double)counts.Count / scanned;
            if (uniqueRatio > maxUniqueRatio)
                return false;

            if (!oneRow)
            {
                if (groupSizes!.Count > 0 && groupSizes[^1] == 1)
                    groupSizes.RemoveAt(groupSizes.Count - 1);
                if (groupSizes.Count == 0 || groupSizes.Any(sz => sz != 2))
                    return false;
            }
            if (oneRow && counts.Values.Min() == 0)
                return false;

            return true;
        }

        public static bool DetectPhenotype(
            string filePath,
            string delimiter = null,
            char commentChar = '#',
            int sampleSize = 1000,
            double floatRatioThreshold = 0.3,
            double textRatioThreshold = 0.3,
            double maxUniqueRatio = 0.5)
        {
            var sample = BuildSample(filePath, delimiter, commentChar, sampleSize);
            var rows = sample.Rows;

            int modalCount = sample.ModalColumnCount;

            var mp = StructureParametersModel.Instance.mainparams;
            int phenIndex = (mp.PREDICTED_LABEL ? 1 : 0) + (mp.PREDICTED_POPDATA ? 1 : 0) + (mp.PREDICTED_POPFLAG ? 1 : 0) + (mp.PREDICTED_LOCDATA ? 1 : 0);
            bool oneRow = mp.PREDICTED_ONEROWPERIND;

            var unique = new HashSet<string>();
            var values = new List<string>();
            int scanned = 0;
            int intCount = 0, floatCount = 0, textCount = 0;

            foreach (var parts in rows)
            {
                if (parts.Length != modalCount)
                    continue;

                if (phenIndex >= parts.Length)
                    return false;

                string field = parts[phenIndex];
                bool isInt = int.TryParse(field, NumberStyles.Integer, CultureInfo.InvariantCulture, out _);
                bool isFloat = !isInt && double.TryParse(field, NumberStyles.Float, CultureInfo.InvariantCulture, out _) && field.Contains('.');
                bool isText = !(isInt || isFloat);

                if (isInt) intCount++; else if (isFloat) floatCount++; else textCount++;

                unique.Add(field);
                values.Add(field);
                if (++scanned >= sampleSize)
                    break;
            }

            if (scanned == 0)
                return false;

            bool pairsOk = true;
            if (!oneRow && values.Count >= 2)
            {
                for (int i = 1; i < values.Count; i += 2)
                {
                    if (i == values.Count - 1) break;        
                    if (values[i] != values[i - 1]) { pairsOk = false; break; }
                }
            }

            double floatRatio = (double)floatCount / scanned;
            double textRatio = (double)textCount / scanned;
            double uniqueRatio = (double)unique.Count / scanned;

            if (floatRatio >= floatRatioThreshold && pairsOk)
                return true;

            if (textRatio >= textRatioThreshold && pairsOk)
                return true;

            if (uniqueRatio <= maxUniqueRatio && pairsOk)
            {
                // Optional extra sanity check with NUMLOCI×PLOIDY if known
                //if (mp.NUMLOCI > 0 && mp.PLOIDY > 0)
                //{
                //    int remain = modalCount - phenIndex - 1;
                //    if (remain % (mp.NUMLOCI * mp.PLOIDY) != 0)
                //        return true;
                //}
                //else
                    return true;
            }

            return false;
        }

        public static bool IsRecessive(IReadOnlyList<string> items) => items.All(p => int.TryParse(p, out var v) && (v == 0 || v == 1));
        public static bool IsMapDistances(IReadOnlyList<string> items) => items.Count > 0 && double.TryParse(items[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var first) && first == -1 && items.All(p => double.TryParse(p, NumberStyles.Float, CultureInfo.InvariantCulture, out _));
        public static bool IsPhaseInfo(IReadOnlyList<string> items) => items.All(p => int.TryParse(p, out var v) && (v == 0 || v == 1 || v == 2 || v == -9));
        public static bool IsNotAmbiguous(IReadOnlyList<string> items) => items.All(p => int.TryParse(p, out var v) && (v == 0 || v == 1));
        public static bool IsMarkerNames(IReadOnlyList<string> items)
        {
            int numLoci = StructureParametersModel.Instance.mainparams.NUMLOCI;
            int nonNumeric = items.Count(p => !int.TryParse(p, out _) && !double.TryParse(p, NumberStyles.Float, CultureInfo.InvariantCulture, out _));
            if (nonNumeric > 0) return true; 
            var ints = items.Select(int.Parse).ToList();
            int unique = ints.Distinct().Count();
            int min = ints.Min();
            int max = ints.Max();
            return (max - min + 1) != unique || (max - min) > numLoci / 2;
        }

        public static void DetectAdditionalRows(
            string filePath,
            string delimiter = null,
            char commentChar = '#')
        {
            int numLoci = StructureParametersModel.Instance.mainparams.PREDICTED_NUMLOCI;
            if (numLoci <= 0)
                throw new InvalidOperationException("NUMLOCI must be known before calling DetectAdditionalRows");

            static bool LooksUniform(IReadOnlyList<string> items)
            {
                bool allInt = true, allFloat = true;
                foreach (var s in items)
                {
                    if (!int.TryParse(s, out _)) allInt = false;
                    if (!(double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out _) && s.Contains('.')))
                        allFloat = false;
                }
                return allInt || allFloat || items.All(t => !int.TryParse(t, out _) && !double.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out _));
            }

            var sample = BuildSample(filePath, delimiter, commentChar, 10);
            var rows = sample.Rows;

            bool foundMarkers = false, foundRecessive = false, foundMap = false, foundPhase = false, foundNotAmbig = false;

            foreach (var parts in rows)
            {
                if (parts.Length != numLoci || !LooksUniform(parts))
                    break;

                if (!foundMap && IsMapDistances(parts))
                {
                    foundMap = true;
                    break;
                }

                if (!foundRecessive && IsRecessive(parts) && !foundPhase)
                {
                    foundRecessive = true;
                    continue;
                }

                if (IsPhaseInfo(parts))
                {
                    foundPhase = true;
                    continue;
                }

                if (foundPhase && !foundNotAmbig && IsNotAmbiguous(parts))
                {
                    foundNotAmbig = true;
                    continue;
                }

                if (!foundMarkers && IsMarkerNames(parts))
                {
                    foundMarkers = true;
                    continue;
                }

                break;
            }

            var mp = StructureParametersModel.Instance.mainparams;
            mp.PREDICTED_MARKERNAMES = foundMarkers;
            mp.PREDICTED_RECESSIVEALLELES = foundRecessive;
            mp.PREDICTED_MAPDISTANCES = foundMap;
            mp.PREDICTED_PHASEINFO = foundPhase;
            mp.PREDICTED_NOTAMBIGUOUS = foundNotAmbig;
        }

        public static string? DetectMissingCandidates(
            string filePath,
            string? delimiter = null,
            char commentChar = '#',
            int sampleSize = 1000,
            double alleleCoverThreshold = 0.90)
        {
            var sample = BuildSample(filePath, delimiter, commentChar, sampleSize);
            var rows = sample.Rows;

            int numLoci = StructureParametersModel.Instance.mainparams.PREDICTED_NUMLOCI;
            int ploidy = StructureParametersModel.Instance.mainparams.PLOIDY;
            int extra = StructureParametersModel.Instance.mainparams.PREDICTED_EXTRACOLS;
            if (numLoci == 0 || ploidy == 0)
                return null;                             

            int modalCount = sample.ModalColumnCount;

            int prefix = (StructureParametersModel.Instance.mainparams.PREDICTED_LABEL ? 1 : 0)
                       + (StructureParametersModel.Instance.mainparams.PREDICTED_POPDATA ? 1 : 0)
                       + (StructureParametersModel.Instance.mainparams.PREDICTED_POPFLAG ? 1 : 0)
                       + (StructureParametersModel.Instance.mainparams.PREDICTED_LOCDATA ? 1 : 0)
                       + (StructureParametersModel.Instance.mainparams.PREDICTED_PHENOTYPE ? 1 : 0);

            int genotypeCols = StructureParametersModel.Instance.mainparams.PREDICTED_ONEROWPERIND
                               ? numLoci * ploidy
                               : numLoci;

            int genotypeStart = prefix;
            int genotypeEnd = genotypeStart + genotypeCols;
            if (genotypeEnd > modalCount)                  
                return null;

            int lastInclusive = Math.Min(genotypeEnd, modalCount - extra);
            if (lastInclusive <= genotypeStart)
                return null;

            var intCounts = new Dictionary<int, int>();   
            var strCounts = new Dictionary<string, int>();
            int analysedRows = 0;

            foreach (var parts in rows)
            {
                if (parts.Length != modalCount) continue;

                for (int i = genotypeStart; i < lastInclusive; i++)
                {
                    var tok = parts[i];
                    if (int.TryParse(tok, NumberStyles.Integer, CultureInfo.InvariantCulture, out int ival))
                    {
                        intCounts[ival] = intCounts.GetValueOrDefault(ival) + 1;
                    }
                    else
                    {
                        strCounts[tok] = strCounts.GetValueOrDefault(tok) + 1;
                    }
                }

                if (++analysedRows >= sampleSize) break;
            }

            if (analysedRows == 0) return null;

            bool IsMissingPattern(int code)
            {
                if (code == 0 || code < 0) return true;
                int tmp = Math.Abs(code);
                while (tmp != 0 && tmp % 10 == 9) tmp /= 10;
                return tmp == 0;
            }

            var mainPool = intCounts.Where(kv => !IsMissingPattern(kv.Key))
                                    .OrderByDescending(kv => kv.Value)
                                    .ToList();
            int totalNumeric = mainPool.Sum(kv => kv.Value);
            var mainAlleles = new HashSet<int>();
            double acc = 0;
            foreach (var kv in mainPool)
            {
                mainAlleles.Add(kv.Key);
                acc += (double)kv.Value / Math.Max(1, totalNumeric);
                if (acc >= alleleCoverThreshold) break;
            }

            var numericCandidates = intCounts.Keys
                                             .Where(code => !mainAlleles.Contains(code) && IsMissingPattern(code))
                                             .OrderByDescending(code => intCounts[code]);

            bool IsStringMissing(string s)
            {
                return s == "0" || s.Equals("NA", StringComparison.OrdinalIgnoreCase)
                       || s.Equals("N/A", StringComparison.OrdinalIgnoreCase)
                       || s.Equals("-", StringComparison.Ordinal);
            }

            var stringCandidates = strCounts.Keys.Where(IsStringMissing)
                                                 .OrderByDescending(s => strCounts[s]);

            var combined = numericCandidates.Select(c => c.ToString())
                                            .Concat(stringCandidates)
                                            .Take(3)
                                            .ToList();

            return combined.Count == 0 ? null : string.Join(" or ", combined);
        }

        public static int DetectNumInds(
            string filePath,
            string? delimiter = null,
            char commentChar = '#')
        {
            var sample = BuildSample(filePath, delimiter, commentChar, 2000);
            var rows = sample.Rows;

            int modalCount = sample.ModalColumnCount;

            bool hasLabel = StructureParametersModel.Instance.mainparams.PREDICTED_LABEL;
            bool oneRow = StructureParametersModel.Instance.mainparams.PREDICTED_ONEROWPERIND;
            bool hasPopData = StructureParametersModel.Instance.mainparams.PREDICTED_POPDATA;

            int prefixCount = (hasLabel ? 1 : 0) + (hasPopData ? 1 : 0) +
                              (StructureParametersModel.Instance.mainparams.PREDICTED_POPFLAG ? 1 : 0) +
                              (StructureParametersModel.Instance.mainparams.PREDICTED_LOCDATA ? 1 : 0) +
                              (StructureParametersModel.Instance.mainparams.PREDICTED_PHENOTYPE ? 1 : 0);

            bool RowLooksLikeData(string[] parts)
            {
                if (parts.Length != modalCount) return false;
                for (int i = prefixCount; i < parts.Length; i++)
                    if (int.TryParse(parts[i], out _))
                        return true;
                return false;
            }

            var uniqueIds = new HashSet<string>();
            int dataRows = 0;

            foreach (var parts in rows)
            {
                if (!RowLooksLikeData(parts)) continue;

                dataRows++;
                if (hasLabel)
                    uniqueIds.Add(parts[0]);
            }

            if (dataRows == 0)
                return -1;

            if (hasLabel)
                return uniqueIds.Count;

            if (oneRow)
                return dataRows;

            if (dataRows % 2 != 0)
                return -1;

            return dataRows / 2;
        }

        public static (int extraCols, int numLoci) DetectExtraColsAndNumLoci(
            string filePath,
            string delimiter = null,
            char commentChar = '#',
            int sampleSize = 1000,
            int maxExtraAllowed = 32)
        {
            var sample = BuildSample(filePath, delimiter, commentChar, sampleSize);
            int modal = sample.ModalColumnCount;

            var mp = StructureParametersModel.Instance.mainparams;

            int prefix = (mp.PREDICTED_LABEL ? 1 : 0)
                       + (mp.PREDICTED_POPDATA ? 1 : 0)
                       + (mp.PREDICTED_POPFLAG ? 1 : 0)
                       + (mp.PREDICTED_LOCDATA ? 1 : 0)
                       + (mp.PREDICTED_PHENOTYPE ? 1 : 0);

            int ploidy = mp.PLOIDY;
            bool oneRow = mp.PREDICTED_ONEROWPERIND;
            if (ploidy <= 0)
                throw new InvalidOperationException("PLOIDY must be known first.");

            int factor = oneRow ? ploidy : 1;
            if (!oneRow && ploidy != 2)
                throw new InvalidOperationException("Two-row формат разрешён только для диплоидов.");

            for (int extra = 0; extra <= maxExtraAllowed; extra++)
            {
                int genotypeCols = modal - prefix - extra;
                if (genotypeCols <= 0) continue;
                if (genotypeCols % factor != 0) continue;

                int loci = genotypeCols / factor;
                if (loci <= 0) continue;

                return (extra, loci);      
            }

            throw new InvalidDataException(
                $"Не удалось согласовать layout (prefix={prefix}, modal={modal}).");
        }

        public static int DetectPloidy(
            string filePath,
            string delimiter = null,
            char commentChar = '#',
            int sampleSize = 1000,
            int maxPloidy = 8)
        {
            var sample = BuildSample(filePath, delimiter, commentChar, sampleSize);
            int modalCount = sample.ModalColumnCount;

            int prefixCount = (StructureParametersModel.Instance.mainparams.PREDICTED_LABEL ? 1 : 0)
                            + (StructureParametersModel.Instance.mainparams.PREDICTED_POPDATA ? 1 : 0)
                            + (StructureParametersModel.Instance.mainparams.PREDICTED_POPFLAG ? 1 : 0)
                            + (StructureParametersModel.Instance.mainparams.PREDICTED_LOCDATA ? 1 : 0)
                            + (StructureParametersModel.Instance.mainparams.PREDICTED_PHENOTYPE ? 1 : 0);

            int extraCols = StructureParametersModel.Instance.mainparams.PREDICTED_EXTRACOLS;
            if (extraCols < 0)
                return -1;

            bool oneRow = StructureParametersModel.Instance.mainparams.PREDICTED_ONEROWPERIND;

            int genotypeColsPerRow = modalCount - prefixCount - extraCols;
            if (genotypeColsPerRow <= 0)
                throw new InvalidOperationException("Could not locate genotype block – check prefix/extracol detection.");

            int numLoci = StructureParametersModel.Instance.mainparams.PREDICTED_NUMLOCI;
            if (numLoci > 0)
            {
                if (genotypeColsPerRow % numLoci != 0)
                    throw new InvalidOperationException($"Genotype column count ({genotypeColsPerRow}) not divisible by NUMLOCI ({numLoci}).");

                int allelesPerRow = genotypeColsPerRow / numLoci;

                if (!oneRow)
                {
                   
                    if (allelesPerRow * 2 > maxPloidy || (allelesPerRow * 2) % 2 != 0)
                        throw new InvalidOperationException("Odd ploidy with two‑rows‑per‑ind is unsupported by STRUCTURE.");
                    return allelesPerRow * 2;
                }
                else
                {
                    if (allelesPerRow > maxPloidy)
                        throw new InvalidOperationException($"Inferred ploidy ({allelesPerRow}) exceeds configured maxPloidy ({maxPloidy}).");
                    return allelesPerRow;
                }
            }
            else
            {
                for (int p = Math.Min(maxPloidy, genotypeColsPerRow); p >= 1; p--)
                {
                    if (genotypeColsPerRow % p == 0)
                    {
                        if (!oneRow && p % 2 != 0)
                            continue;
                        return p;
                    }
                }
                return 1;
            }
        }
    }
}
