using System;
using System.IO;

namespace GenotypeApp.Additional_programs_logic.Structure
{
    internal static class StructureInputDataValidator
    {
        public static void ValidateInputData()
        {
            using var reader = new StreamReader(Path.Combine(StructureStartupPreparationService.OriginalDataFilePath, StructureStartupPreparationService.OriginalDataFileName));

            // Metadata columns before allele data
            int metaCols = (StructureParametersModel.Instance.mainparams.LABEL ? 1 : 0)
                         + (StructureParametersModel.Instance.mainparams.POPDATA ? 1 : 0)
                         + (StructureParametersModel.Instance.mainparams.POPFLAG ? 1 : 0)
                         + (StructureParametersModel.Instance.mainparams.LOCDATA ? 2 : 0)
                         + (StructureParametersModel.Instance.mainparams.PHENOTYPE ? 1 : 0)
                         + StructureParametersModel.Instance.mainparams.EXTRACOLS;

            // How many allele tokens per row
            int alleleColsPerRow = StructureParametersModel.Instance.mainparams.NUMLOCI * (StructureParametersModel.Instance.mainparams.ONEROWPERIND ? StructureParametersModel.Instance.mainparams.PLOIDY : 1);
            int expectGenotypeCols = metaCols + alleleColsPerRow;

            // Optional header rows --------------------------------------
            if (StructureParametersModel.Instance.mainparams.MARKERNAMES) ExpectTokens(reader, StructureParametersModel.Instance.mainparams.NUMLOCI, "marker names");
            if (StructureParametersModel.Instance.mainparams.RECESSIVEALLELES) ExpectTokens(reader, StructureParametersModel.Instance.mainparams.NUMLOCI, "recessive‑allele row");
            if (StructureParametersModel.Instance.mainparams.MAPDISTANCES) ExpectTokens(reader, StructureParametersModel.Instance.mainparams.NUMLOCI, "map distance");

            // Loop over individuals ------------------------------------
            int rowsPerGeno = StructureParametersModel.Instance.mainparams.ONEROWPERIND ? 1 : StructureParametersModel.Instance.mainparams.PLOIDY;   // genotype rows per individual
            int totalRowsRead = 0;
            for (int ind = 0; ind < StructureParametersModel.Instance.mainparams.NUMINDS; ind++)
            {
                // genotype rows
                for (int gr = 0; gr < rowsPerGeno; gr++)
                {
                    ValidateAlleleRow(reader, expectGenotypeCols, metaCols, ++totalRowsRead);
                }

                // optional PHASEINFO row
                if (StructureParametersModel.Instance.mainparams.PHASEINFO)
                {
                    if (reader.EndOfStream)
                        throw new Exception($"Missing phase info row after individual {ind + 1}.");

                    var line = reader.ReadLine()!;
                    var tokens = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                    totalRowsRead++;

                    // Adopt STRUCTURE behavior: phase row must have *at least* NumLoci tokens
                    if (tokens.Length < StructureParametersModel.Instance.mainparams.NUMLOCI)
                        throw new Exception($"Phase info row for individual {ind + 1} has too few tokens (got {tokens.Length}, expected ≥ {StructureParametersModel.Instance.mainparams.NUMLOCI}).");
                }
            }

            if (!reader.EndOfStream)
            {
                long extraRows = 0;
                while (!reader.EndOfStream)
                {
                    var rest = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(rest)) extraRows++;
                }
                throw new Exception($"Bad format in data source: number of rows are more than expected ({totalRowsRead + extraRows}).");
            }
        }
        private static void ValidateAlleleRow(StreamReader reader, int expectCols, int metaCols, int rowNumber)
        {
            if (reader.EndOfStream)
                throw new Exception($"Premature end of file: expected more genotype rows (stopped at row {rowNumber}).");

            var line = reader.ReadLine()!;
            var tokens = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length != expectCols)
                throw new Exception($"Bad format at line {rowNumber}: expected {expectCols} tokens, got {tokens.Length}.");

            int startIdx = metaCols; // allele list begins here

            for (int i = startIdx; i < tokens.Length; i++)
            {
                var raw = tokens[i];
                if (!double.TryParse(raw, out double allele))
                    throw new Exception($"Non‑integer allele code at line {rowNumber}, col {i + 1} (got '{raw}').");
                if (allele == StructureParametersModel.Instance.mainparams.MISSING) continue;
            }
        }
        private static void ExpectTokens(StreamReader reader, int expected, string context)
        {
            if (reader.EndOfStream)
                throw new Exception($"Missing {context} line.");

            var line = reader.ReadLine()!;
            var tokens = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length != expected)
                throw new Exception($"Incorrect number of tokens in {context}: expected {expected}, got {tokens.Length}.");
        }
    }
}
