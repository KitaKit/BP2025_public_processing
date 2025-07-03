using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace GenotypeApp.Additional_programs_logic.Distruct
{
    public sealed class DistructParametersModel : INotifyPropertyChanged
    {
        private static readonly DistructParametersModel _instance = new DistructParametersModel();
        public static DistructParametersModel Instance => _instance;

        //public string INFILE_POPQ 
        //{ 
        //    get => _infile_popQ;
        //    set 
        //    { 
        //        if (_infile_popQ == value) return; 
        //        if (value.Length > 50) throw new Exception(); 
        //        _infile_popQ = value; 
        //    }
        //}
        //public string INFILE_INDIVQ 
        //{ 
        //    get => _infile_indivQ;
        //    set
        //    {
        //        if (_infile_indivQ == value) return;
        //        if (value.Length > 50) throw new Exception();
        //        _infile_indivQ = value;
        //    }
        //}
        public string INFILE_LABEL_ATOP 
        { 
            get => _infile_label_atop;
            set
            {
                if (_infile_label_atop == value) return;
                if (value.Length > 50) throw new Exception();
                _infile_label_atop = value;
                OnPropertyChanged();
            }
        }
        public string INFILE_LABEL_BELOW 
        { 
            get => _infile_label_below;
            set
            {
                if (_infile_label_below == value) return;
                if (value.Length > 50) throw new Exception();
                _infile_label_below = value;
                OnPropertyChanged();
            }
        }
        public string INFILE_CLUST_PERM 
        { 
            get => _infile_clust_perm;
            set
            {
                if (_infile_clust_perm == value) return;
                if (value.Length > 50) throw new Exception();
                _infile_clust_perm = value;
                OnPropertyChanged();
            }
        }
        //public string OUTFILE 
        //{ 
        //    get => _outfile;
        //    set
        //    {
        //        if (_outfile == value) return;
        //        if (value.Length > 50) throw new Exception();
        //        _outfile = value;
        //    }
        //}
        //public int K 
        //{
        //    get => _k;
        //    set
        //    {
        //        if (_k == value) return;
        //        _k = Math.Max(1, Math.Min(value, 60));
        //    }
        //}
        public int NUMPOPS 
        { 
            get => _numpops;
            set
            {
                if (_numpops == value) return;
                _numpops = Math.Max(0, Math.Min(value, 5000));
                OnPropertyChanged();
            }
        }
        public int NUMINDS 
        { 
            get => _numinds;
            set
            {
                if (_numinds == value) return;
                _numinds = Math.Max(0, Math.Min(value, 5000));
                OnPropertyChanged();
            }
        }
        public bool PRINT_INDIVS 
        { 
            get => _print_indivs;
            set
            {
                _print_indivs = value;
                OnPropertyChanged();
            }
        }
        public bool PRINT_LABEL_ATOP 
        { 
            get => _print_label_atop;
            set
            {
                _print_label_atop = value;
                OnPropertyChanged();
            }
        }
        public bool PRINT_LABEL_BELOW 
        { 
            get => _print_label_below;
            set
            {
                _print_label_below = value;
                OnPropertyChanged();
            }
        }
        public bool PRINT_SEP 
        { 
            get => _print_sep;
            set
            {
                _print_sep = value;
                OnPropertyChanged();
            }
        }
        public double FONTHEIGHT 
        { 
            get => _fontheight;
            set
            {
                _fontheight = value;
                OnPropertyChanged();
            }
        }
        public double DIST_ABOVE 
        { 
            get => _dist_above;
            set
            {
                _dist_above = value;
                OnPropertyChanged();
            }
        }
        public double DIST_BELOW 
        { 
            get => _dist_below;
            set
            {
                _dist_below = value;
                OnPropertyChanged();
            }
        }
        public double BOXHEIGHT 
        { 
            get => _boxheight;
            set
            {
                _boxheight = value;
                OnPropertyChanged();
            }
        }
        public double INDIVWIDTH 
        { 
            get => _indivwidth;
            set
            {
                _indivwidth = value;
                OnPropertyChanged();
            }
        }
        public int ORIENTATION 
        { 
            get => _orientation;
            set
            {
                if (_orientation != value) return;
                _orientation = Math.Max(0, Math.Min(value, 3));
                OnPropertyChanged();
            }
        }
        public double XORIGIN 
        { 
            get => _xorigin;
            set
            {
                _xorigin = value;
                OnPropertyChanged();
            }
        }
        public double YORIGIN 
        { 
            get => _yorigin;
            set
            {
                _yorigin = value;
                OnPropertyChanged();
            }
        }
        public double XSCALE 
        { 
            get => _xscale;
            set
            {
                _xscale = value;
                OnPropertyChanged();
            }
        }
        public double YSCALE 
        { 
            get => _yscale;
            set
            {
                _yscale = value;
                OnPropertyChanged();
            }
        }
        public double ANGLE_LABEL_ATOP 
        { 
            get => _angle_label_atop;
            set
            {
                if (value != _angle_label_atop) return;
                _angle_label_atop = Math.Max(0, Math.Min(value, 180));
                OnPropertyChanged();
            }
        }
        public double ANGLE_LABEL_BELOW 
        { 
            get => _angle_label_below;
            set
            {
                if(value != _angle_label_below) return;
                _angle_label_below = Math.Max(0, Math.Max(value, 180));
                OnPropertyChanged();
            }
        }
        public double LINEWIDTH_RIM 
        { 
            get => _linewidth_rim;
            set
            {
                _linewidth_rim = value;
                OnPropertyChanged();
            }
        }
        public double LINEWIDTH_SEP 
        {
            get => _linewidth_sep;
            set
            {
                _linewidth_sep = value;
                OnPropertyChanged();
            }
        }
        public double LINEWIDTH_IND 
        { 
            get => _linewidth_ind;
            set
            {
                _linewidth_ind = value;
                OnPropertyChanged();
            }
        }
        public bool GRAYSCALE 
        { 
            get => _grayscale;
            set
            {
                _grayscale = value;
                OnPropertyChanged();
            }
        }
        public bool ECHO_DATA 
        { 
            get => _echo_data;
            set
            {
                _echo_data = value;
                OnPropertyChanged();
            }
        }
        public bool REPRINT_DATA 
        { 
            get => _reprint_data;
            set
            {
                _reprint_data = value;
                OnPropertyChanged();
            }
        }
        public bool PRINT_INFILE_NAME 
        { 
            get => _print_infile_name;
            set
            {
                _print_infile_name = value;
                OnPropertyChanged();
            }
        }
        public bool PRINT_COLOR_BREWER 
        { 
            get => _print_color_brewer;
            set
            {
                _print_color_brewer = value;
                OnPropertyChanged();
            }
        }

        public List<string> GetParamsStringList()
        {
            return new List<string>
            {
                FormatParametersString("#define INFILE_POPQ", " "),
                FormatParametersString("#define INFILE_INDIVQ", " "),
                FormatParametersString("#define INFILE_LABEL_ATOP", INFILE_LABEL_ATOP),
                FormatParametersString("#define INFILE_LABEL_BELOW", INFILE_LABEL_BELOW),
                FormatParametersString("#define INFILE_CLUST_PERM", INFILE_CLUST_PERM),
                FormatParametersString("#define OUTFILE", " "),
                FormatParametersString("#define K", " "),
                FormatParametersString("#define NUMPOPS", NUMPOPS),
                FormatParametersString("#define NUMINDS", NUMINDS),
                FormatParametersString("#define PRINT_INDIVS", PRINT_INDIVS),
                FormatParametersString("#define PRINT_LABEL_ATOP", PRINT_LABEL_ATOP),
                FormatParametersString("#define PRINT_LABEL_BELOW", PRINT_LABEL_BELOW),
                FormatParametersString("#define PRINT_SEP", PRINT_SEP),
                FormatParametersString("#define FONTHEIGHT", FONTHEIGHT),
                FormatParametersString("#define DIST_ABOVE", DIST_ABOVE),
                FormatParametersString("#define DIST_BELOW", DIST_BELOW),
                FormatParametersString("#define BOXHEIGHT", BOXHEIGHT),
                FormatParametersString("#define INDIVWIDTH", INDIVWIDTH),
                FormatParametersString("#define ORIENTATION", ORIENTATION),
                FormatParametersString("#define XORIGIN", XORIGIN),
                FormatParametersString("#define YORIGIN", YORIGIN),
                FormatParametersString("#define XSCALE", XSCALE),
                FormatParametersString("#define YSCALE", YSCALE),
                FormatParametersString("#define ANGLE_LABEL_ATOP", ANGLE_LABEL_ATOP),
                FormatParametersString("#define ANGLE_LABEL_BELOW", ANGLE_LABEL_BELOW),
                FormatParametersString("#define LINEWIDTH_RIM", LINEWIDTH_RIM),
                FormatParametersString("#define LINEWIDTH_SEP", LINEWIDTH_SEP),
                FormatParametersString("#define LINEWIDTH_IND", LINEWIDTH_IND),
                FormatParametersString("#define GRAYSCALE", GRAYSCALE),
                FormatParametersString("#define ECHO_DATA", ECHO_DATA),
                FormatParametersString("#define REPRINT_DATA", REPRINT_DATA),
                FormatParametersString("#define PRINT_INFILE_NAME", PRINT_INFILE_NAME),
                FormatParametersString("#define PRINT_COLOR_BREWER", PRINT_COLOR_BREWER)
            };
        }
        public void LoadFromLines(List<string> lines)
        {
            var paramDict = lines
                            .Select(l => l.Trim())
                            .Where(l => l.StartsWith("#define"))
                            .Select(l => l.Substring("#define".Length).Trim())
                            .Select(line =>
                            {
                                var parts = line.Split(new[] { ' ', '\t' }, 2, StringSplitOptions.RemoveEmptyEntries);
                                var key = parts[0];
                                var value = parts.Length == 2
                                    ? parts[1]
                                    : string.Empty;   
                                return new KeyValuePair<string, string>(key, value);
                            })
                            .ToDictionary(kv => kv.Key, kv => kv.Value);

            var obj = Instance;
            ApplyDictionaryToObject(obj, paramDict);
        }

        private void ApplyDictionaryToObject(object obj, Dictionary<string, string> dict)
        {
            var type = obj.GetType();
            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!prop.CanWrite)
                    continue;

                if (dict.TryGetValue(prop.Name, out var strValue))
                {
                    var targetType = Nullable.GetUnderlyingType(prop.PropertyType)
                                     ?? prop.PropertyType;

                    object value;
                    if (targetType == typeof(string))
                    {
                        value = strValue;
                    }
                    else if (targetType.IsEnum)
                    {
                        value = Enum.Parse(targetType, strValue, ignoreCase: true);
                    }
                    else
                    {
                        value = (targetType == typeof(bool) || targetType == typeof(bool?)) ? (strValue == "0" ? (object)false : strValue == "1" ? (object)true : (object)bool.Parse(strValue)) : Convert.ChangeType(strValue, targetType, CultureInfo.InvariantCulture);
                    }

                    prop.SetValue(obj, value);
                }
            }
        }
        private static string FormatParametersString(string parameterName, object parameterValue, int parameterNameColumnWidth = 27)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(parameterName);

            string textValue = string.Empty;

            switch (parameterValue)
            {
                case bool b:
                    textValue = b ? "1" : "0";
                    break;

                case double d:
                    textValue = d.ToString(CultureInfo.InvariantCulture);
                    break;

                case float f:
                    textValue = f.ToString(CultureInfo.InvariantCulture);
                    break;

                case decimal m:
                    textValue = m.ToString(CultureInfo.InvariantCulture);
                    break;

                default:
                    textValue = parameterValue?.ToString() ?? string.Empty;
                    break;
            }

            return parameterName.PadRight(parameterNameColumnWidth) + textValue;
        }

        //private string _infile_popQ = string.Empty;
        //private string _infile_indivQ = string.Empty;
        private string _infile_label_atop = "INFILE_LABEL_ATOP";
        private string _infile_label_below = "INFILE_LABEL_BELOW";
        private string _infile_clust_perm = "INFILE_CLUST_PERM";
        //private string _outfile = string.Empty;
        //private int _k = 0;
        private int _numpops = 6;
        private int _numinds = 0;
        private bool _print_indivs = false;
        private bool _print_label_atop = true;
        private bool _print_label_below = true;
        private bool _print_sep = true;

        private double _fontheight = 6;
        private double _dist_above = 5;
        private double _dist_below = -7;
        private double _boxheight = 36;
        private double _indivwidth = 1.5;
        private int _orientation = 0;
        private double _xorigin = 72;
        private double _yorigin = 28;
        private double _xscale = 1;
        private double _yscale = 1;
        private double _angle_label_atop = 60;
        private double _angle_label_below = 60;
        private double _linewidth_rim = 3;
        private double _linewidth_sep = 0.3;
        private double _linewidth_ind = 0.3;
        private bool _grayscale = false;
        private bool _echo_data = true;
        private bool _reprint_data = true;
        private bool _print_infile_name = false;
        private bool _print_color_brewer = true;


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
