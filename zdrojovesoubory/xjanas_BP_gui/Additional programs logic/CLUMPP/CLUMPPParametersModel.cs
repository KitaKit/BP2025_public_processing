using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace GenotypeApp.Additional_programs_logic.CLUMPP
{
    public class CLUMPPParametersModel : INotifyPropertyChanged
    {
        private static readonly CLUMPPParametersModel _instance = new CLUMPPParametersModel();
        public static CLUMPPParametersModel Instance => _instance;

        private bool _dataType = true;
        private string _indFile = string.Empty;
        private string _popFile = string.Empty;
        private string _outFile = string.Empty;
        private string _miscFile = string.Empty;
        private int _k = 0;
        //private int _c = 0;
        private int _numOfInd = 0;
        private int _numOfPop = 0;
        private int _r = 0;
        private int _m = 1;
        private bool _w = false;
        private int _s = 2;

        private int _greedyOption = 1;

        private int _repeats = 1000;

        private string _permutationFile;

        private int _printPermutedData = 1;

        private string _permutedDataFile;

        private bool _printEveryPerm = false;

        private string _everyPermFile;

        private bool _printRandomInputOrder = false;
        
        private string _randomInputOrderFile;
        
        private bool _overrideWarnings = false;
        
        private int _orderByRun = 1;

        public bool DATATYPE 
        { 
            get => _dataType;
            set { _dataType = value; OnPropertyChanged(); }
        }
        public string INDFILE 
        { 
            get => _indFile;
            set { if (_indFile == value) return; _indFile = value; OnPropertyChanged(); }
        }
        public string POPFILE
        {
            get => _popFile;
            set { if(_popFile == value) return; _popFile = value; OnPropertyChanged(); }
        }
        public string OUTFILE
        {
            get => _outFile;
            set { if (_outFile == value) return; _outFile = value; OnPropertyChanged(); }
        }
        public string MISCFILE 
        { 
            get => _miscFile;
            set { if (_miscFile == value) return; _miscFile = value; OnPropertyChanged(); }
        }
        public int K
        {
            get => _k;
            set { if (_k == value) return; _k = value; OnPropertyChanged(); }
        }
        //public int C
        //{
        //    get => _c;
        //    set { if (_c == value) return; _c = value; OnPropertyChanged(); }
        //}
        public int R
        {
            get => _r;
            set { if (_r == value) return; _r = value; OnPropertyChanged(); }
        }
        public int M
        {
            get => _m;
            set { if (_m == value) return; _m = value; OnPropertyChanged(); }
        }
        public int GREADY_OPTION
        {
            get => _greedyOption;
            set { if (_greedyOption == value) return; _greedyOption = value; OnPropertyChanged(); }
        }
        public int REPEATS 
        {
            get => _repeats;
            set { if (_repeats == value) return; _repeats = value; OnPropertyChanged(); }
        }
        public string PERMUTATIONFILE 
        {
            get => _permutationFile;
            set { if (_permutationFile == value) return; _permutationFile = value; OnPropertyChanged(); }
        }
        public int PRINT_PERMUTED_DATA
        {
            get => _printPermutedData;
            set { if (_printPermutedData == value) return; _printPermutedData = value; OnPropertyChanged(); }
        }
        public string PERMUTED_DATAFILE
        {
            get => _permutedDataFile;
            set { if (_permutedDataFile == value) return; _permutedDataFile = value; OnPropertyChanged(); } 
        }
        public bool PRINT_EVERY_PERM
        {
            get => _printEveryPerm;
            set {  _printEveryPerm = value; OnPropertyChanged(); }
        }
        public string EVERY_PERMFILE
        {
            get => _everyPermFile;
            set { if (_everyPermFile == value) return; _everyPermFile = value; OnPropertyChanged();}
        }
        public bool PRINT_RANDOM_INPUTORDER
        {
            get => _printRandomInputOrder;
            set { _printRandomInputOrder = value; OnPropertyChanged(); }
        }
        public string RANDOM_INPUTORDERFILE 
        {
            get => _randomInputOrderFile;
            set { if(_randomInputOrderFile == value) return; _randomInputOrderFile = value; OnPropertyChanged(); }
        }
        public bool OVERRIDE_WARNINGS
        {
            get => _overrideWarnings;
            set { _overrideWarnings = value; OnPropertyChanged(); }
        }
        public int ORDER_BY_RUN
        {
            get => _orderByRun;
            set { if (_orderByRun == value) return; _orderByRun = Math.Max(0, Math.Min(value, R)); OnPropertyChanged(); }
        }

        public int NumOfInd 
        { 
            get => _numOfInd;
            set { if (_numOfInd == value) return; _numOfInd = value; OnPropertyChanged(); } 
        }
        public int NumOfPop 
        { 
            get => _numOfPop;
            set { if (_numOfPop == value) return; _numOfPop = value; OnPropertyChanged(); } 
        }

        public bool W
        { 
            get => _w;
            set { _w = value; OnPropertyChanged(); } 
        }

        public bool S
        {
            get { return _s == 2; }
            set { _s = value ? 2 : 1; OnPropertyChanged(); }
        }

        public List<string> GetParamsStringList()
        {
            return new List<string>
            {
                FormatParametersString("DATATYPE", DATATYPE),
                FormatParametersString("INDFILE", "K1.indfile"),
                FormatParametersString("POPFILE", "K1.popfile"),
                FormatParametersString("OUTFILE", "K1.indivq"),
                FormatParametersString("MISCFILE", "K1.miscfile"),
                FormatParametersString("K", 1),
                FormatParametersString("C", 1),
                FormatParametersString("R", R),
                FormatParametersString("M", M),
                FormatParametersString("W", W),
                FormatParametersString("S", _s),
                FormatParametersString("GREEDY_OPTION", GREADY_OPTION),
                FormatParametersString("REPEATS", REPEATS),
                FormatParametersString("PERMUTATIONFILE", PERMUTATIONFILE),
                FormatParametersString("PRINT_PERMUTED_DATA", PRINT_PERMUTED_DATA),
                FormatParametersString("PERMUTED_DATAFILE", "perm.perm_datafile"),
                FormatParametersString("PRINT_EVERY_PERM", PRINT_EVERY_PERM),
                FormatParametersString("EVERY_PERMFILE", "everyperm.every_permfile"),
                FormatParametersString("PRINT_RANDOM_INPUTORDER", PRINT_RANDOM_INPUTORDER),
                FormatParametersString("RANDOM_INPUTORDERFILE", "randomorder.random_inputorderfile"),
                FormatParametersString("OVERRIDE_WARNINGS", OVERRIDE_WARNINGS),
                FormatParametersString("ORDER_BY_RUN", ORDER_BY_RUN)
            };
        }

        public void LoadFromLines(List<string> lines)
        { 
            var dict = lines
                .Select(l => l.Trim())
                .Where(line => !string.IsNullOrEmpty(line))       
                .Select(line =>
                {
                    var parts = line.Split(new[] { ' ', '\t' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    var key = parts[0];
                    var value = parts.Length == 2
                        ? parts[1]
                        : string.Empty;
                    return new KeyValuePair<string, string>(key, value);
                })
                .ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);

            var obj = Instance;
            ApplyDictionaryToObject(obj, dict);
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
                    else if (targetType == typeof(bool) || targetType == typeof(bool?))
                    {
                        if (strValue == "2")
                        {
                            value = true;
                        }
                        else if (strValue == "1")
                        {
                            value = false;
                        }
                        else if (strValue == "0")
                        {
                            value = false;
                        }
                        else
                        {
                            value = bool.Parse(strValue);
                        }
                    }
                    else
                    {
                        value = Convert.ChangeType(strValue, targetType, CultureInfo.InvariantCulture);
                    }


                    prop.SetValue(obj, value);
                }
            }
        }

        private static string FormatParametersString(string parameterName, object parameterValue, int parameterNameColumnWidth = 26)
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
