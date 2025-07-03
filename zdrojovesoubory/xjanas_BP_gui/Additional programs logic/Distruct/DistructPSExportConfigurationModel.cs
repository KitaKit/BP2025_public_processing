using System.IO;

namespace GenotypeApp.Additional_programs_logic.Distruct
{
    internal static class DistructPSExportConfigurationModel
    {
        private readonly static string _dllGhostscriptPath = Path.Combine(DirectoriesManager.RootPath, "gsdll64.dll");
        private readonly static string _libGhostscriptPath = Path.Combine(DirectoriesManager.RootPath, "ghostscript_lib");

        public static string DllGhostscriptPath => _dllGhostscriptPath;

        public static string LibGhostscriptPath => _libGhostscriptPath;
    }
}
