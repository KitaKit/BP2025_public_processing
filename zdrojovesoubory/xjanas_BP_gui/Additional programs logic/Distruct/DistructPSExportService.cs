using Ghostscript.NET;
using Ghostscript.NET.Processor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GenotypeApp.Additional_programs_logic.Distruct
{
    internal static class DistructPSExportService
    {
        private static GhostscriptVersionInfo _versionInfo;

        public enum OutputFormat
        {
            PDF,
            PNG,
            JPEG,
            BMP
        }
        public enum PageOrientation
        {
            Portrait,
            Seascape,
            ReversePortrait,
            Landscape
        }

        public static async Task ExportRangeAsync(
            string dllPath,
            string libPath,
            string psDirectory,
            int kStart,
            int kEnd,
            IEnumerable<OutputFormat> formats,
            PageOrientation orientation,
            string outputDirectory,
            bool tmp = false,
            int dpi = 300)
        {
            if (string.IsNullOrWhiteSpace(dllPath) || !File.Exists(dllPath))
                throw new ArgumentException("Incorrect path to the Ghostscript DLL.", nameof(dllPath));

            var fileInfo = FileVersionInfo.GetVersionInfo(dllPath);
            var version = new Version(
                fileInfo.FileMajorPart,
                fileInfo.FileMinorPart,
                fileInfo.FileBuildPart,
                fileInfo.FilePrivatePart);

            var dllDirectory = Path.GetDirectoryName(dllPath) ?? string.Empty;
            _versionInfo = new GhostscriptVersionInfo(
                version,
                dllPath,
                libPath,
                GhostscriptLicense.GPL);

            if (!Directory.Exists(psDirectory))
                throw new DirectoryNotFoundException($"The catalog was not found: {psDirectory}");
            Directory.CreateDirectory(outputDirectory);

            var tasks = new List<Task>();
            for (int k = kStart; k <= kEnd; k++)
            {
                string inputPs = Path.Combine(psDirectory, (tmp ? "K" + k + "_tmp" + ".ps" : $"K{k}.ps"));
                if (!File.Exists(inputPs)) continue;

                foreach (var fmt in formats)
                {
                    string extension = fmt.ToString().ToLower();
                    string outputFile = Path.Combine(outputDirectory, tmp ? $"K{k}_tmp.{extension}" : $"K{k}.{extension}");
                    tasks.Add(Task.Run(() => ConvertWithLibrary(inputPs, outputFile, fmt, orientation, dpi)));
                }
            }
            await Task.WhenAll(tasks);
        }

        sealed class GsCapture : GhostscriptStdIO
        {
            private readonly Action<string>? _out;
            private readonly Action<string>? _err;

            public GsCapture(Action<string>? outLine = null, Action<string>? errLine = null)
                : base(false,   
                       true,    
                       true)    
            {
                _out = outLine;
                _err = errLine;
            }

            public override void StdOut(string s) => _out?.Invoke(s);
            public override void StdError(string s) => _err?.Invoke(s);

            public override void StdIn(out string input, int count) => input = string.Empty;
        }


        private static (int width, int height) GetBBoxByGhostscript(string ps)
        {
            string bboxLine = string.Empty;

            var capture = new GsCapture(
                outLine: s => { if (s.StartsWith("%%BoundingBox:")) bboxLine = s; });

            using (var proc = new GhostscriptProcessor(_versionInfo, true))
            {
                proc.StartProcessing(
                    new[] { "-dBATCH", "-dNOPAUSE", "-sDEVICE=bbox", ps }, capture);
            }

            var m = Regex.Match(bboxLine,
                     @"%%BoundingBox:\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)");
            if (!m.Success) return (0, 0);

            int w = int.Parse(m.Groups[3].Value) - int.Parse(m.Groups[1].Value);
            int h = int.Parse(m.Groups[4].Value) - int.Parse(m.Groups[2].Value);
            return (w, h);
        }

        private static void ConvertWithLibrary(
                string inputPs, string outputFile,
                OutputFormat fmt, PageOrientation orient, int dpi)
        {
            var (wPt, hPt) = GetBBoxByGhostscript(inputPs);
            if (wPt == 0 || hPt == 0) { wPt = 612; hPt = 792; }   // Fallback: Letter

            bool swap = orient is PageOrientation.Landscape
                                     or PageOrientation.Seascape;
            if (swap) (wPt, hPt) = (hPt, wPt);

            string dev = GetDeviceName(fmt);

            var args = new List<string>
    {
        "-dSAFER","-dBATCH","-dNOPAUSE",
        $"-sDEVICE={dev}",
        $"-sOutputFile={outputFile}",
        $"-dDEVICEWIDTHPOINTS={wPt}",
        $"-dDEVICEHEIGHTPOINTS={hPt}",
        "-dFIXEDMEDIA"           
    };

            if (fmt is OutputFormat.PNG or OutputFormat.JPEG or OutputFormat.BMP)
            {
                int rot = orient switch
                {
                    PageOrientation.Landscape => 90,
                    PageOrientation.ReversePortrait => 180,
                    PageOrientation.Seascape => 270,
                    _ => 0
                };
                if (rot != 0) args.Add($"-dRotate={rot}");
                if (fmt is OutputFormat.PNG or OutputFormat.JPEG)
                    args.Add($"-r{dpi}");
            }

            args.Add(inputPs);        

            using var proc = new GhostscriptProcessor(_versionInfo, true);
            proc.StartProcessing(args.ToArray(), null);
        }
        private static string GetDeviceName(OutputFormat format) => format switch
        {
            OutputFormat.PDF => "pdfwrite",
            OutputFormat.PNG => "png16m",
            OutputFormat.JPEG => "jpeg",
            OutputFormat.BMP => "bmp16m",
            _ => throw new NotSupportedException($"Format {format} is not supported.")
        };
    }
}
