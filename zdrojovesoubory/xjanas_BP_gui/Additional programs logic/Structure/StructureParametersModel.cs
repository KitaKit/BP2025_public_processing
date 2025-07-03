using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace GenotypeApp.Additional_programs_logic.Structure
{
    public sealed partial class StructureParametersModel
    {
        public abstract class StructureMainparamsAbstractSubModel
        {
            public abstract int BURNIN { get; set; }
            public abstract int NUMREPS { get; set; }
            public abstract int NUMINDS { get; set; }

            public abstract int PREDICTED_NUMINDS { get; set; }

            public abstract int NUMLOCI { get; set; }

            public abstract int PREDICTED_NUMLOCI { get; set; }

            public abstract int PLOIDY { get; set; }

            public abstract int PREDICTED_PLOIDY { get; set; }

            public abstract int MISSING { get; set; }

            public abstract string PREDICTED_MISSING { get; set; }

            public abstract bool ONEROWPERIND { get; set; }

            public abstract bool PREDICTED_ONEROWPERIND { get; set; }

            public abstract bool LABEL { get; set; }

            public abstract bool PREDICTED_LABEL { get; set; }

            public abstract bool POPDATA { get; set; }

            public abstract bool PREDICTED_POPDATA { get; set; }

            public abstract bool POPFLAG { get; set; }

            public abstract bool PREDICTED_POPFLAG { get; set; }

            public abstract bool LOCDATA { get; set; }

            public abstract bool PREDICTED_LOCDATA { get; set; }

            public abstract bool PHENOTYPE { get; set; }

            public abstract bool PREDICTED_PHENOTYPE { get; set; }

            public abstract int EXTRACOLS { get; set; }

            public abstract int PREDICTED_EXTRACOLS { get; set; }

            public abstract bool MARKERNAMES { get; set; }

            public abstract bool? PREDICTED_MARKERNAMES { get; set; }

            public abstract bool RECESSIVEALLELES { get; set; }

            public abstract bool? PREDICTED_RECESSIVEALLELES { get; set; }

            public abstract bool MAPDISTANCES { get; set; }

            public abstract bool? PREDICTED_MAPDISTANCES { get; set; }

            public abstract bool PHASED { get; set; }
            public abstract bool PHASEINFO { get; set; }

            public abstract bool? PREDICTED_PHASEINFO { get; set; }

            public abstract bool MARKOVPHASE { get; set; }
            public abstract bool NOTAMBIGUOUS { get; set; }

            public abstract bool? PREDICTED_NOTAMBIGUOUS { get; set; }

            public abstract string INFILE { get; set; }
            public abstract string OUTFILE { get; set; }
            public abstract bool UseExtraCols { get; set; }
            public abstract event PropertyChangedEventHandler PropertyChanged;
        }
        public abstract class StructureExtraparamsAbstractSubModel
        {
            public abstract bool NOADMIX { get; set; }
            public abstract bool LINKAGE { get; set; }
            public abstract bool USEPOPINFO { get; set; }
            public abstract bool LOCPRIOR { get; set; }
            public abstract bool ONEFST { get; set; }
            public abstract bool INFERALPHA { get; set; }
            public abstract bool POPALPHAS { get; set; }
            public abstract double ALPHA { get; set; }
            public abstract bool INFERLAMBDA { get; set; }
            public abstract bool POPSPECIFICLAMBDA { get; set; }
            public abstract double LAMBDA { get; set; }
            public abstract double FPRIORMEAN { get; set; }
            public abstract double FPRIORSD { get; set; }
            public abstract bool UNIFPRIORALPHA { get; set; }
            public abstract double ALPHAMAX { get; set; }
            public abstract double ALPHAPRIORB { get; set; }
            public abstract double ALPHAPRIORA { get; set; }
            public abstract double LOG10RMIN { get; set; }
            public abstract double LOG10PROPSD { get; set; }
            public abstract double LOG10RMAX { get; set; }
            public abstract double LOG10RSTART { get; set; }
            public abstract int GENSBACK { get; set; }
            public abstract double MIGRPRIOR { get; set; }
            public abstract bool PFROMPOPFLAGONLY { get; set; }
            public abstract bool LOCISPOP { get; set; }
            public abstract double LOCPRIORINIT { get; set; }
            public abstract double MAXLOCPRIOR { get; set; }
            public abstract bool PRINTNET { get; set; }
            public abstract bool PRINTLAMBDA { get; set; }
            public abstract bool PRINTQSUM { get; set; }
            public abstract bool SITEBYSITE { get; set; }
            public abstract int UPDATEFREQ { get; set; }
            public abstract bool PRINTLIKES { get; set; }
            public abstract bool INTERMEDSAVE { get; set; }
            public abstract bool ECHODATA { get; set; }
            public abstract int ADMBURNIN { get; set; }
            public abstract bool RANDOMIZE { get; set; }
            public abstract int SEED { get; set; }
            public abstract bool PRINTQHAT { get; set; }
            public abstract double ANCESTPINT { get; set; }
            public abstract int NUMBOXES { get; set; }
            public abstract bool STARTATPOPINFO { get; set; }
            public abstract int METROFREQ { get; set; }
            public abstract double ALPHAPROPSD { get; set; }
            public abstract bool FREQSCORR { get; set; }
            public abstract bool COMPUTEPROB { get; set; }
            public abstract bool ANCESTDIST { get; set; }
            public abstract bool REPORTHITRATE { get; set; }
            public abstract event PropertyChangedEventHandler PropertyChanged;

            //public abstract bool zeroExpectedColsOrRows { get; set; }
            //public abstract bool rowsError { get; set; }
            //public abstract int expectedRows { get; set; }
            //public abstract int actualRows { get; set; }
            //public abstract bool columnsError { get; set; }
            //public abstract int errorRow { get; set; }
            //public abstract int expectedColumns { get; set; }
        }

        private static readonly StructureParametersModel _instance = new StructureParametersModel();
        public static StructureParametersModel Instance => _instance;
        private StructureParametersModel()
        {
            mainparams = new StructureMainparamsSubModel();
            extraparams = new StructureExtraparamsSubModel();
        }

        public StructureMainparamsAbstractSubModel mainparams { get; }
        public StructureExtraparamsAbstractSubModel extraparams { get; }

        public List<string> GetMainparamsStringList()
        {
            return new List<string>
            {
                FormatParametersString("#define MAXPOPS",   1),
                FormatParametersString("#define BURNIN",    Instance.mainparams.BURNIN),
                FormatParametersString("#define NUMREPS", Instance.mainparams.NUMREPS),
                FormatParametersString("#define INFILE", Instance.mainparams.INFILE),
                FormatParametersString("#define OUTFILE", Instance.mainparams.OUTFILE),
                FormatParametersString("#define NUMINDS", Instance.mainparams.NUMINDS),
                FormatParametersString("#define NUMLOCI", Instance.mainparams.NUMLOCI),
                FormatParametersString("#define PLOIDY", Instance.mainparams.PLOIDY),
                FormatParametersString("#define MISSING", Instance.mainparams.MISSING),
                FormatParametersString("#define ONEROWPERIND", Instance.mainparams.ONEROWPERIND),
                FormatParametersString("#define LABEL", Instance.mainparams.LABEL),
                FormatParametersString("#define POPDATA", Instance.mainparams.POPDATA),
                FormatParametersString("#define POPFLAG", Instance.mainparams.POPFLAG),
                FormatParametersString("#define LOCDATA", Instance.mainparams.LOCDATA),
                FormatParametersString("#define PHENOTYPE", Instance.mainparams.PHENOTYPE),
                FormatParametersString("#define EXTRACOLS", Instance.mainparams.EXTRACOLS),
                FormatParametersString("#define MARKERNAMES", Instance.mainparams.MARKERNAMES),
                FormatParametersString("#define RECESSIVEALLELES", Instance.mainparams.RECESSIVEALLELES),
                FormatParametersString("#define MAPDISTANCES", Instance.mainparams.MAPDISTANCES),
                FormatParametersString("#define PHASED", Instance.mainparams.PHASED),
                FormatParametersString("#define PHASEINFO", Instance.mainparams.PHASEINFO),
                FormatParametersString("#define MARKOVPHASE", Instance.mainparams.MARKOVPHASE),
                FormatParametersString("#define NOTAMBIGUOUS", Instance.mainparams.NOTAMBIGUOUS),

                FormatParametersString("#define NOADMIX",    Instance.extraparams.NOADMIX),
                FormatParametersString("#define LINKAGE",    Instance.extraparams.LINKAGE),
                FormatParametersString("#define USEPOPINFO",    Instance.extraparams.USEPOPINFO),
                FormatParametersString("#define LOCPRIOR",    Instance.extraparams.LOCPRIOR),
                FormatParametersString("#define FREQSCORR",    Instance.extraparams.FREQSCORR),
                FormatParametersString("#define ONEFST",    Instance.extraparams.ONEFST),
                FormatParametersString("#define INFERALPHA",    Instance.extraparams.INFERALPHA),
                FormatParametersString("#define POPALPHAS",    Instance.extraparams.POPALPHAS),
                FormatParametersString("#define ALPHA",    Instance.extraparams.ALPHA),
                FormatParametersString("#define INFERLAMBDA",    Instance.extraparams.INFERLAMBDA),
                FormatParametersString("#define POPSPECIFICLAMBDA",    Instance.extraparams.POPSPECIFICLAMBDA),
                FormatParametersString("#define LAMBDA",    Instance.extraparams.LAMBDA),
                FormatParametersString("#define FPRIORMEAN",    Instance.extraparams.FPRIORMEAN),
                FormatParametersString("#define FPRIORSD",    Instance.extraparams.FPRIORSD),
                FormatParametersString("#define UNIFPRIORALPHA",    Instance.extraparams.UNIFPRIORALPHA),
                FormatParametersString("#define ALPHAMAX",    Instance.extraparams.ALPHAMAX),
                FormatParametersString("#define ALPHAPRIORA",    Instance.extraparams.ALPHAPRIORA),
                FormatParametersString("#define ALPHAPRIORB",    Instance.extraparams.ALPHAPRIORB),
                FormatParametersString("#define LOG10RMIN",    Instance.extraparams.LOG10RMIN),
                FormatParametersString("#define LOG10RMAX",    Instance.extraparams.LOG10RMAX),
                FormatParametersString("#define LOG10PROPSD",    Instance.extraparams.LOG10PROPSD),
                FormatParametersString("#define LOG10RSTART",    Instance.extraparams.LOG10RSTART),
                FormatParametersString("#define GENSBACK",    Instance.extraparams.GENSBACK),
                FormatParametersString("#define MIGRPRIOR",    Instance.extraparams.MIGRPRIOR),
                FormatParametersString("#define PFROMPOPFLAGONLY",    Instance.extraparams.PFROMPOPFLAGONLY),//0
                FormatParametersString("#define LOCISPOP",    Instance.extraparams.LOCISPOP),//1
                FormatParametersString("#define LOCPRIORINIT",    Instance.extraparams.LOCPRIORINIT),//1
                FormatParametersString("#define MAXLOCPRIOR",    Instance.extraparams.MAXLOCPRIOR),//20
                FormatParametersString("#define PRINTNET",    Instance.extraparams.PRINTNET),//1
                FormatParametersString("#define PRINTLAMBDA",    Instance.extraparams.PRINTLAMBDA),//1
                FormatParametersString("#define PRINTQSUM",    Instance.extraparams.PRINTQSUM),//1
                FormatParametersString("#define SITEBYSITE",    Instance.extraparams.SITEBYSITE),//0
                FormatParametersString("#define PRINTQHAT",    Instance.extraparams.PRINTQHAT),
                FormatParametersString("#define UPDATEFREQ",    Instance.extraparams.UPDATEFREQ),//100
                FormatParametersString("#define PRINTLIKES",    Instance.extraparams.PRINTLIKES),//0
                FormatParametersString("#define INTERMEDSAVE",    Instance.extraparams.INTERMEDSAVE),//0
                FormatParametersString("#define ECHODATA",    Instance.extraparams.ECHODATA),//1
                FormatParametersString("#define ANCESTDIST",    Instance.extraparams.ANCESTDIST),
                FormatParametersString("#define ANCESTPINT",    Instance.extraparams.ANCESTPINT),
                FormatParametersString("#define NUMBOXES",    Instance.extraparams.NUMBOXES),
                FormatParametersString("#define COMPUTEPROB",    Instance.extraparams.COMPUTEPROB),
                FormatParametersString("#define ADMBURNIN",    Instance.extraparams.ADMBURNIN),//500
                FormatParametersString("#define ALPHAPROPSD",    Instance.extraparams.ALPHAPROPSD),
                FormatParametersString("#define STARTATPOPINFO",    Instance.extraparams.STARTATPOPINFO),
                FormatParametersString("#define RANDOMIZE",    Instance.extraparams.RANDOMIZE),//1
                FormatParametersString("#define SEED",    Instance.extraparams.SEED),//2245
                FormatParametersString("#define METROFREQ",    Instance.extraparams.METROFREQ),
                FormatParametersString("#define REPORTHITRATE",    Instance.extraparams.REPORTHITRATE)//0
            };
        }
        public List<string> GetExtraparamsStringList()
        {
            return new List<string>
            {
                //FormatParametersString("#define NOADMIX",    Instance.extraparams.NOADMIX),
                //FormatParametersString("#define LINKAGE",    Instance.extraparams.LINKAGE),
                //FormatParametersString("#define USEPOPINFO",    Instance.extraparams.USEPOPINFO),
                //FormatParametersString("#define LOCPRIOR",    Instance.extraparams.LOCPRIOR),
                //FormatParametersString("#define FREQSCORR",    Instance.extraparams.FREQSCORR),
                //FormatParametersString("#define ONEFST",    Instance.extraparams.ONEFST),
                //FormatParametersString("#define INFERALPHA",    Instance.extraparams.INFERALPHA),
                //FormatParametersString("#define POPALPHAS",    Instance.extraparams.POPALPHAS),
                //FormatParametersString("#define ALPHA",    Instance.extraparams.ALPHA),
                //FormatParametersString("#define INFERLAMBDA",    Instance.extraparams.INFERLAMBDA),
                //FormatParametersString("#define POPSPECIFICLAMBDA",    Instance.extraparams.POPSPECIFICLAMBDA),
                //FormatParametersString("#define LAMBDA",    Instance.extraparams.LAMBDA),
                //FormatParametersString("#define FPRIORMEAN",    Instance.extraparams.FPRIORMEAN),
                //FormatParametersString("#define FPRIORSD",    Instance.extraparams.FPRIORSD),
                //FormatParametersString("#define UNIFPRIORALPHA",    Instance.extraparams.UNIFPRIORALPHA),
                //FormatParametersString("#define ALPHAMAX",    Instance.extraparams.ALPHAMAX),
                //FormatParametersString("#define ALPHAPRIORA",    Instance.extraparams.ALPHAPRIORA),
                //FormatParametersString("#define ALPHAPRIORB",    Instance.extraparams.ALPHAPRIORB),
                //FormatParametersString("#define LOG10RMIN",    Instance.extraparams.LOG10RMIN),
                //FormatParametersString("#define LOG10RMAX",    Instance.extraparams.LOG10RMAX),
                //FormatParametersString("#define LOG10PROPSD",    Instance.extraparams.LOG10PROPSD),
                //FormatParametersString("#define LOG10RSTART",    Instance.extraparams.LOG10RSTART),
                //FormatParametersString("#define GENSBACK",    Instance.extraparams.GENSBACK),
                //FormatParametersString("#define MIGRPRIOR",    Instance.extraparams.MIGRPRIOR),
                //FormatParametersString("#define PFROMPOPFLAGONLY",    Instance.extraparams.PFROMPOPFLAGONLY),//0
                //FormatParametersString("#define LOCISPOP",    Instance.extraparams.LOCISPOP),//1
                //FormatParametersString("#define LOCPRIORINIT",    Instance.extraparams.LOCPRIORINIT),//1
                //FormatParametersString("#define MAXLOCPRIOR",    Instance.extraparams.MAXLOCPRIOR),//20
                //FormatParametersString("#define PRINTNET",    Instance.extraparams.PRINTNET),//1
                //FormatParametersString("#define PRINTLAMBDA",    Instance.extraparams.PRINTLAMBDA),//1
                //FormatParametersString("#define PRINTQSUM",    Instance.extraparams.PRINTQSUM),//1
                //FormatParametersString("#define SITEBYSITE",    Instance.extraparams.SITEBYSITE),//0
                //FormatParametersString("#define PRINTQHAT",    Instance.extraparams.PRINTQHAT),
                //FormatParametersString("#define UPDATEFREQ",    Instance.extraparams.UPDATEFREQ),//100
                //FormatParametersString("#define PRINTLIKES",    Instance.extraparams.PRINTLIKES),//0
                //FormatParametersString("#define INTERMEDSAVE",    Instance.extraparams.INTERMEDSAVE),//0
                //FormatParametersString("#define ECHODATA",    Instance.extraparams.ECHODATA),//1
                //FormatParametersString("#define ANCESTDIST",    Instance.extraparams.ANCESTDIST),
                //FormatParametersString("#define ANCESTPINT",    Instance.extraparams.ANCESTPINT),
                //FormatParametersString("#define NUMBOXES",    Instance.extraparams.NUMBOXES),
                //FormatParametersString("#define COMPUTEPROB",    Instance.extraparams.COMPUTEPROB),
                //FormatParametersString("#define ADMBURNIN",    Instance.extraparams.ADMBURNIN),//500
                //FormatParametersString("#define ALPHAPROPSD",    Instance.extraparams.ALPHAPROPSD),
                //FormatParametersString("#define STARTATPOPINFO",    Instance.extraparams.STARTATPOPINFO),
                //FormatParametersString("#define RANDOMIZE",    Instance.extraparams.RANDOMIZE),//1
                //FormatParametersString("#define SEED",    Instance.extraparams.SEED),//2245
                //FormatParametersString("#define METROFREQ",    Instance.extraparams.METROFREQ),
                //FormatParametersString("#define REPORTHITRATE",    Instance.extraparams.REPORTHITRATE)//0
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

            var mainObj = Instance.mainparams;
            ApplyDictionaryToObject(mainObj, paramDict);

            var extraObj = Instance.extraparams;
            ApplyDictionaryToObject(extraObj, paramDict);
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
    }
}
