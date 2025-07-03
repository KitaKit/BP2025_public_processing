using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GenotypeApp.Additional_programs_logic.Structure
{
    public sealed partial class StructureParametersModel
    {
        private sealed class StructureMainparamsSubModel : StructureMainparamsAbstractSubModel, INotifyPropertyChanged
        {
            ///Basic Program Parameters.
            /// Length of burnin period before the start of data collection.
            private int _burnIn = 10000;
            public override int BURNIN
            {
                get => _burnIn;
                set { if (_burnIn == value) return; _burnIn = Math.Max(0, Math.Min(value, 131072)); OnPropertyChanged(); }
            }
            /// Number of MCMC reps after burnin.
            private int _numReps = 10000;
            public override int NUMREPS
            {
                get => _numReps;
                set { if (_numReps == value) return; _numReps = Math.Max(0, Math.Min(value, 131072)); OnPropertyChanged(); }
            }

            ///Data file format.
            /// Number of individuals in data file.
            private int _numInds = 0;
            public override int NUMINDS
            {
                get => _numInds;
                set
                {
                    if (_numInds == value) return;
                    _numInds = Math.Max(0, Math.Min(value, 32768));
                    OnPropertyChanged();
                }
            }

            private int _predictedNumInds = -1;
            public override int PREDICTED_NUMINDS
            {
                get => _predictedNumInds;
                set { if (_predictedNumInds == value) return; _predictedNumInds = value; OnPropertyChanged(); }
            }

            /// Number of loci in data file.
            private int _numLoci = 0;
            public override int NUMLOCI
            {
                get => _numLoci;
                set
                {
                    if (_numLoci == value) return;
                    _numLoci = Math.Max(0, Math.Min(value, 32768));
                    OnPropertyChanged();
                }
            }

            private int _predictedNumLoci = -1;
            public override int PREDICTED_NUMLOCI
            {
                get => _predictedNumLoci;
                set { if (_predictedNumLoci == value) return; _predictedNumLoci = value; OnPropertyChanged(); }
            }

            private int _ploidy = 2;
            public override int PLOIDY
            {
                get => _ploidy;
                set 
                { 
                    if (_ploidy == value) return;
                    _ploidy = Math.Max(1, Math.Min(value, 32768));
                    OnPropertyChanged();
                }
            }

            private int _predictedPloidy = -1;
            public override int PREDICTED_PLOIDY
            {
                get => _predictedPloidy;
                set
                {
                    if (_predictedPloidy == value) return;
                    _predictedPloidy = value;
                    OnPropertyChanged();
                }
            }

            /// Value given to missing genotype data.
            private int _missing = 0;
            public override int MISSING
            {
                get => _missing;
                set { if (_missing == value) return; _missing = Math.Max(-999, Math.Min(value, 999)); OnPropertyChanged(); }
            }

            private string _predictedMissing = string.Empty;
            public override string PREDICTED_MISSING
            {
                get => _predictedMissing;
                set { if (_predictedMissing == value) return; _predictedMissing = value; OnPropertyChanged(); }
            }

            /// True if data per individual are in one row
            private bool _oneRowPerInd = false;
            public override bool ONEROWPERIND
            {
                get => _oneRowPerInd;
                set
                {
                    if (_oneRowPerInd == value) return;
                    _oneRowPerInd = value;
                    OnPropertyChanged();                                                             
                }
            }

            private bool _predictedOneRowPerInd = false;
            public override bool PREDICTED_ONEROWPERIND
            {
                get => _predictedOneRowPerInd;
                set
                {
                    if (_predictedOneRowPerInd == value) return;
                    _predictedOneRowPerInd = value;
                    OnPropertyChanged();
                }
            }

            /// Input file contains labels (names) for each individual. True = Yes; False = No.
            private bool _label = false;
            public override bool LABEL
            {
                get => _label;
                set 
                {
                    if (_label == value) return;
                    _label = value;
                    OnPropertyChanged();                                                          
                }
            }

            private bool _predictedLabel = false;
            public override bool PREDICTED_LABEL
            {
                get => _predictedLabel;
                set
                {
                    if (_predictedLabel == value) return;
                    _predictedLabel = value;
                    OnPropertyChanged();
                }
            }

            /// Input file contains a user-defined population-of-origin for each individual. True = Yes; False = No.
            private bool _popData = false;
            public override bool POPDATA
            {
                get => _popData;
                set
                {
                    if (_popData == value) return;
                    _popData = value;
                    OnPropertyChanged();
                }
            }

            private bool _predictedPopData = false;
            public override bool PREDICTED_POPDATA
            {
                get => _predictedPopData;
                set
                {
                    if (_predictedPopData == value) return;
                    _predictedPopData = value;
                    OnPropertyChanged();
                }
            }

            /// Input file contains an indicator variable which says whether to use popinfo when USEPOPINFO==1. True = Yes; False = No.
            private bool _popFlag = false;
            public override bool POPFLAG
            {
                get => _popFlag;
                set
                {
                    if (_popFlag == value) return;
                    _popFlag = value;
                    OnPropertyChanged();
                }
            }

            private bool _predictedPopFlag = false;
            public override bool PREDICTED_POPFLAG
            {
                get => _predictedPopFlag;
                set
                {
                    if (_predictedPopFlag == value) return;
                    _predictedPopFlag = value;
                    OnPropertyChanged();
                }
            }

            /// Input file contains a user-defined sampling location for each individual. True = Yes; False = No. For use in the LOCPRIOR model. Can set LOCISPOP=1 to use the POPDATA instead in the LOCPRIOR model.
            private bool _locData = false;
            public override bool LOCDATA
            {
                get => _locData;
                set
                {
                    if (_locData == value) return;
                    _locData = value;
                    OnPropertyChanged();
                }
            }

            private bool _predictedLocData = false;
            public override bool PREDICTED_LOCDATA
            {
                get => _predictedLocData;
                set
                {
                    if (_predictedLocData == value) return;
                    _predictedLocData = value;
                    OnPropertyChanged();
                }
            }

            /// Input file contains a column of phenotype information. True = Yes; False = No.
            private bool _phenotype = false;
            public override bool PHENOTYPE
            {
                get => _phenotype;
                set
                {
                    if (_phenotype == value) return;
                    _phenotype = value;
                    OnPropertyChanged();
                }
            }

            private bool _predictedPhenotype = false;
            public override bool PREDICTED_PHENOTYPE
            {
                get => _predictedPhenotype;
                set
                {
                    if (_predictedPhenotype == value) return;
                    _predictedPhenotype = value;
                    OnPropertyChanged();
                }
            }

            /// Number of additional columns of data after the Phenotype before the genotype data start. These are ignored by the program. 0 = no extra columns.
            private int _extraCols = 0;
            public override int EXTRACOLS
            {
                get => _extraCols;
                set 
                {
                    int normalized = _useExtraCols ? value : 0;

                    if (_extraCols == normalized) return;
                    _extraCols = Math.Max(0, Math.Min(normalized, 32768));
                    OnPropertyChanged();
                }
            }

            private int _predictedExtraCols = 0;
            public override int PREDICTED_EXTRACOLS
            {
                get => _predictedExtraCols;
                set 
                {
                    if (_predictedExtraCols == value) return;
                    _predictedExtraCols = value;
                    OnPropertyChanged();
                }
            }

            /// The top row of the data file contains a list of L names corresponding to the markers used.
            private bool _markerNames = false;
            public override bool MARKERNAMES
            {
                get => _markerNames;
                set
                {
                    if (_markerNames == value) return;
                    _markerNames = value;
                    OnPropertyChanged();
                }
            }

            private bool? _predictedMarkerNames = false;
            public override bool? PREDICTED_MARKERNAMES
            {
                get => _predictedMarkerNames;
                set
                {
                    if (_predictedMarkerNames == value) return;
                    _predictedMarkerNames = value;
                    OnPropertyChanged();
                }
            }

            /// Next row of data file contains a list of L integers indicating which alleles are recessive at each locus.Setting this to 1 implies that the dominant marker model is in use.
            private bool _recessiveAlleles = false;
            public override bool RECESSIVEALLELES
            {
                get => _recessiveAlleles;
                set
                {
                    if (_recessiveAlleles == value) return;
                    _recessiveAlleles = value;
                    if (!value)
                        NOTAMBIGUOUS = false;
                    OnPropertyChanged();
                }
            }

            private bool? _predictedRecessiveAlleles = false;
            public override bool? PREDICTED_RECESSIVEALLELES
            {
                get => _predictedRecessiveAlleles;
                set
                {
                    if (_predictedRecessiveAlleles == value) return;
                    _predictedRecessiveAlleles = value;
                    OnPropertyChanged();
                }
            }

            /// The next row of the data file (or the first row if MARKERNAMES==0) contains a list of mapdistances between neighboring loci.
            private bool _mapDistances = false;
            public override bool MAPDISTANCES
            {
                get => _mapDistances;
                set
                {
                    if (_mapDistances == value) return;
                    _mapDistances = value;
                    OnPropertyChanged();
                }
            }

            private bool? _predictedMapDistances = false;
            public override bool? PREDICTED_MAPDISTANCES
            {
                get => _predictedMapDistances;
                set
                {
                    if (_predictedMapDistances == value) return;
                    _predictedMapDistances = value;
                    OnPropertyChanged();
                }
            }

            ///Advanced data file options.
            /// For use with linkage model. Indicates that data are in correct phase.
            private bool _phased = false;
            public override bool PHASED
            {
                get => _phased;
                set { if (_phased == value) return; _phased = value; OnPropertyChanged(); }
            }
            /// The row(s) of genotype data for each individual are followed by a row of information about haplotype phase.This is for use with the linkage model only.
            private bool _phaseInfo = false;
            public override bool PHASEINFO
            {
                get => _phaseInfo;
                set
                {
                    if (_phaseInfo == value) return;
                    _phaseInfo = value;
                    OnPropertyChanged();
                }
            }

            private bool? _predictedPhaseInfo = false;
            public override bool? PREDICTED_PHASEINFO
            {
                get => _predictedPhaseInfo;
                set
                {
                    if (_predictedPhaseInfo == value) return;
                    _predictedPhaseInfo = value;
                    OnPropertyChanged();
                }
            }

            /// The phase info follows a Markov model.
            private bool _markovPhase = false;
            public override bool MARKOVPHASE
            {
                get => _markovPhase;
                set { if (_markovPhase == value) return; _markovPhase = value; OnPropertyChanged(); }
            }

            private bool _notAmbiguous = false;
            public override bool NOTAMBIGUOUS
            { 
                get => _notAmbiguous;
                set { if (_notAmbiguous == value) return; _notAmbiguous = value; OnPropertyChanged(); } 
            }

            private bool? _predictedNotAmbiguous = false;
            public override bool? PREDICTED_NOTAMBIGUOUS
            {
                get => _predictedNotAmbiguous;
                set { if (_predictedNotAmbiguous == value) return; _predictedNotAmbiguous = value; }
            }

            private string _outFile = "outFile_";
            public override string OUTFILE
            {
                get => _outFile;
                set { if (_outFile == value) return; _outFile = value.Length > 30 ? value.Substring(0,30) : value; OnPropertyChanged(); }
            }

            private string _inFile = string.Empty;
            public override string INFILE
            {
                get => _inFile;
                set { if (_inFile == value) return; _inFile = value.Length > 30 ? value.Substring(0, 30) : value; OnPropertyChanged(); }
            }

            public override event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            /*===============================================================================================================================*/
            /*CUSTOM PROPERTIES*/
            /*===============================================================================================================================*/
            private bool _useExtraCols = false;

            public override bool UseExtraCols
            {
                get => _useExtraCols;
                set
                {
                    if (_useExtraCols == value) return; _useExtraCols = value; OnPropertyChanged();
                    EXTRACOLS = _extraCols;
                }
            }
        }
    }
}
