using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GenotypeApp.Additional_programs_logic.Structure
{
    public sealed partial class StructureParametersModel
    {
        private sealed class StructureExtraparamsSubModel : StructureExtraparamsAbstractSubModel, INotifyPropertyChanged
        {
            ///Program options.
            /// Assume the model without admixture. (Each individual is assumed to be completely from one of the K populations.) In the output, instead of printing the average value of Q as in the admixture case, the program prints the posterior probability that each individual is from each population. 1 = no admixture; 0 = model with admixture.
            private bool _noAdmix = false;
            public override bool NOADMIX
            {
                get => _noAdmix;
                set { if (_noAdmix == value) return; _noAdmix = value; OnPropertyChanged(); }
            }
            /// Use the linkage model model.
            private bool _linkage = false;
            public override bool LINKAGE
            {
                get => _linkage;
                set { if (_linkage == value) return; _linkage = value; OnPropertyChanged(); }
            }
            /// Use prior population information to assign individuals to clusters. Must have POPDATA=1.
            private bool _usePopInfo = false;
            public override bool USEPOPINFO
            {
                get => _usePopInfo;
                set { if (_usePopInfo == value) return; _usePopInfo = value; OnPropertyChanged(); }
            }
            /// Use location information to improve the performance on data that are weakly informative about structure.
            private bool _locPrior = false;
            public override bool LOCPRIOR
            {
                get => _locPrior;
                set { if (_locPrior == value) return; _locPrior = value; OnPropertyChanged(); }
            }
            /// Assume the same value of Fk for all populations (analogous to Wright’s traditional FST ). This is not recommended for most data, because in practice you probably expect different levels of divergence in each population.
            private bool _onefst = false;
            public override bool ONEFST
            {
                get => _onefst;
                set { if (_onefst == value) return; _onefst = value; OnPropertyChanged(); }
            }
            /// Infer the value of the model parameter α from the data; otherwise α is fixed at the value ALPHA which is chosen by the user.This option is ignored under the NOADMIX model.
            private bool _inferAlpha = true;
            public override bool INFERALPHA
            {
                get => _inferAlpha;
                set { if (_inferAlpha == value) return; _inferAlpha = value; OnPropertyChanged(); }
            }
            /// Infer a separate α for each population. Not recommended in most cases but may be useful for situations with asymmetric admixture.
            private bool _popAlphas = false;
            public override bool POPALPHAS
            {
                get => _popAlphas;
                set { if (_popAlphas == value) return; _popAlphas = value; OnPropertyChanged(); }
            }            
            /// Dirichlet parameter (α) for degree of admixture (this is the initial value if INFERALPHA==1). 
            private double _alpha = 1;
            public override double ALPHA
            {
                get => _alpha;
                set { if (_alpha == value) return; _alpha = value; OnPropertyChanged(); }
            }
            /// Infer a suitable value for λ. Not recommended for most analyses.
            private bool _inferLambda = false;
            public override bool INFERLAMBDA
            {
                get => _inferLambda;
                set { if (_inferLambda == value) return; _inferLambda = value; OnPropertyChanged(); }
            }
            /// Infer a separate λ for each population
            private bool _popSpecificLambda = false;
            public override bool POPSPECIFICLAMBDA
            {
                get => _popSpecificLambda;
                set { if (_popSpecificLambda == value) return; _popSpecificLambda = value; OnPropertyChanged(); }
            }
            /// Parameterizes the allele frequency prior, and for most data the default value of 1 seems to work pretty well.
            private double _lambda = 1;
            public override double LAMBDA
            {
                get => _lambda;
                set { if (_lambda == value) return; _lambda = value; OnPropertyChanged(); }
            }

            ///Priors.
            /// prior mean and SD of Fst for pops
            private double _fPriorMean = 0.01;
            public override double FPRIORMEAN
            {
                get => _fPriorMean;
                set { if (_fPriorMean == value) return; _fPriorMean = Math.Max(0.00001, Math.Min(value, 100)); OnPropertyChanged(); }
            }
            /// the prior is a Gamma distribution with these parameters
            private double _fPriorSD = 0.05;
            public override double FPRIORSD
            {
                get => _fPriorSD;
                set { if (_fPriorSD == value) return; _fPriorSD = Math.Max(0.00001, Math.Min(value, 100)); OnPropertyChanged(); }
            }

            /// Assume a uniform prior for α which runs between 0 and ALPHAMAX. This model seems to work fine; the alternative model (when UNIFPRIORALPHA=0) is to take α as having a Gamma prior, with mean ALPHAPRIORA × ALPHAPRIORB, and variance ALPHAPRIORA × ALPHAPRIORB^2.
            private bool _unifPriorAlpha = true;
            public override bool UNIFPRIORALPHA
            {
                get => _unifPriorAlpha;
                set { if (_unifPriorAlpha == value) return; _unifPriorAlpha = value; OnPropertyChanged(); }
            }

            private double _alphaMax = 10;
            public override double ALPHAMAX
            {
                get => _alphaMax;
                set { if (_alphaMax == value) return; _alphaMax = Math.Max(0, Math.Min(value, 32768)); OnPropertyChanged(); }
            }
            /// The Metropolis-Hastings update step for α involves picking a α' from a Normal with mean α and standard deviation ALPHAPROPSD> 0. The value of ALPHAPROPSD does not affect the asymptotic behaviour of the Markov chain, but may have a substantial impact on the rate of convergence.If there is a lot of information about α, small values of ALPHAPROPSD are preferable to obtain a reasonable acceptance rate. If there’s not much information about α, larger values produce better mixing
            private double _alphaPropSD = 0.025;
            public override double ALPHAPROPSD
            {
                get => _alphaPropSD;
                set { if (_alphaPropSD == value) return; _alphaPropSD = Math.Max(0.00001, Math.Min(value, 100)); OnPropertyChanged(); }
            }
            private double _alphaPriorB = 0.001;
            public override double ALPHAPRIORB
            {
                get => _alphaPriorB;
                set { if (_alphaPriorB == value) return; _alphaPriorB = Math.Max(0.00001, Math.Min(value, 100)); OnPropertyChanged(); }
            }
            private double _alphaPriorA = 0.05;
            public override double ALPHAPRIORA
            {
                get => _alphaPriorA;
                set { if (_alphaPriorA == value) return; _alphaPriorA = Math.Max(0.00001, Math.Min(value, 100)); OnPropertyChanged(); }
            }

            /// When the linkage model is used, the switch rate r is taken to have a uniform prior on a log scale, between LOG10RMIN and LOG10RMAX.These values need to be set by the user to make sense in terms of the scale of map units being used.
            /// log10 of minimum allowed value of r under linkage model.
            private double _log10rMin = -4;
            public override double LOG10RMIN
            {
                get => _log10rMin;
                set { if (_log10rMin == value) return; _log10rMin = Math.Max(-1000, Math.Min(value, 1000)); OnPropertyChanged(); }
            }
            /// standard deviation of log r in update.
            private double _log10propSD = 0.1;
            public override double LOG10PROPSD
            {
                get => _log10propSD;
                set { if (_log10propSD == value) return; _log10propSD = Math.Max(-1000, Math.Min(value, 1000)); OnPropertyChanged(); }
            }
            /// log10 of maximum allowed value of r.
            private double _log10rMax = 1;
            public override double LOG10RMAX
            {
                get => _log10rMax;
                set { if (_log10rMax == value) return; _log10rMax = Math.Max(-1000, Math.Min(value, 1000)); OnPropertyChanged(); }
            }
            /// initial value of log10 r.
            private double _log10rStart = -2;
            public override double LOG10RSTART
            {
                get => _log10rStart;
                set { if (_log10rStart == value) return; _log10rStart = Math.Max(LOG10RMIN, Math.Min(value, LOG10RMAX)); OnPropertyChanged(); }
            }

            /// Using prior population information (USEPOPINFO).
            /// This corresponds to G. When using prior population information for individuals (USEPOPINFO= 1), the program tests whether each individual has an immigrant ancestor in the last G generations, where G = 0 corresponds to the individual being an immigrant itself.In order to ha
            private int _gensBack = 2;
            public override int GENSBACK
            {
                get => _gensBack;
                set { if (_gensBack == value) return; _gensBack = Math.Max(0, Math.Min(value, 32768)); OnPropertyChanged(); }
            }
            /// prior prob that an individual is a migrant (used only when USEPOPINFO==1), this should be small, eg 0.01 or 0.1.
            private double _migrPrior = 0.01;
            public override double MIGRPRIOR
            {
                get => _migrPrior;
                set { if (_migrPrior == value) return; _migrPrior = Math.Max(0, Math.Min(value, 1)); OnPropertyChanged(); }
            }
            private bool _pFromPopFlagOnly = false;
            public override bool PFROMPOPFLAGONLY
            {
                get => _pFromPopFlagOnly;
                set { if (_pFromPopFlagOnly == value) return; _pFromPopFlagOnly = value; OnPropertyChanged(); }
            }

            ///LOCPRIOR model for using location information.
            private bool _locIsPop = false;
            public override bool LOCISPOP
            {
                get => _locIsPop;
                set { if (_locIsPop == value) return; _locIsPop = value; OnPropertyChanged(); }
            }
            private double _locPriorInit = 1;
            public override double LOCPRIORINIT
            {
                get => _locPriorInit;
                set { if (_locPriorInit == value) return; _locPriorInit = Math.Max(1, Math.Min(value, MAXLOCPRIOR)); OnPropertyChanged(); }
            }
            private double _maxLocPrior = 1;
            public override double MAXLOCPRIOR
            {
                get => _maxLocPrior;
                set { if (_maxLocPrior == value) return; _maxLocPrior = Math.Max(1, Math.Min(value, 100)); OnPropertyChanged(); }
            }

            ///Output options.
            /// When this is turned on, the point estimate for Q is not only printed into the main results file, but also into a separate file with suffix “q”. This file is required in order to run the companion program STRAT.
            private bool _printNet = true;
            public override bool PRINTNET
            {
                get => _printNet;
                set { if (_printNet == value) return; _printNet = value; OnPropertyChanged(); }
            }
            private bool _printLambda = true;
            public override bool PRINTLAMBDA
            {
                get => _printLambda;
                set { if (_printLambda == value) return; _printLambda = value; OnPropertyChanged(); }
            }
            private bool _printQsum = true;
            public override bool PRINTQSUM
            {
                get => _printQsum;
                set { if (_printQsum == value) return; _printQsum = value; OnPropertyChanged(); }
            }
            private bool _siteBySite = false;
            public override bool SITEBYSITE
            {
                get => _siteBySite;
                set { if (_siteBySite == value) return; _siteBySite = value; OnPropertyChanged(); }
            }
            private int _updateFreq = 100;
            public override int UPDATEFREQ
            {
                get => _updateFreq;
                set { if (_updateFreq == value) return; _updateFreq = value; OnPropertyChanged(); }
            }
            private bool _printLikes = false;
            public override bool PRINTLIKES
            {
                get => _printLikes;
                set { if (_printLikes == value) return; _printLikes = value; OnPropertyChanged(); }
            }
            private bool _intermedSave = false;
            public override bool INTERMEDSAVE
            {
                get => _intermedSave;
                set { if (_intermedSave == value) return; _intermedSave = value; OnPropertyChanged(); }
            }
            private bool _echoData = true;
            public override bool ECHODATA
            {
                get => _echoData;
                set { if (_echoData == value) return; _echoData = value; OnPropertyChanged(); }
            }
            private bool _printQhat = false;
            public override bool PRINTQHAT
            {
                get => _printQhat;
                set { if (_printQhat == value) return; _printQhat = value; OnPropertyChanged(); }
            }
            private bool _ancestDist = false;
            public override bool ANCESTDIST
            {
                get => _ancestDist;
                set { if (_ancestDist == value) return; _ancestDist = value; OnPropertyChanged(); }
            }
            /// the size of the displayed probability interval on Q(values between 0.0--1.0)
            private double _ancestPint = 0.9;
            public override double ANCESTPINT
            {
                get => _ancestPint;
                set { if (_ancestPint == value) return; _ancestPint = Math.Max(0, Math.Min(value, 1)); OnPropertyChanged(); }
            }
            /// the distribution of Q values is stored as a histogram with this number of boxes
            private int _numBoxes = 1000;
            public override int NUMBOXES
            {
                get => _numBoxes;
                set { if (_numBoxes == value) return; _numBoxes = Math.Max(1, Math.Min(value, 32768)); OnPropertyChanged(); }
            }

            ///Miscellaneous.
            /// Use given populations as the initial condition for population origins. (Need POPDATA==1). This option provides a check that the Markov chain is converging properly in cases where you expected the inferred structure to match the input labels, and it did not.This option assumes that the PopData in the input file are between 1 and k where k ≤MAXPOPS. Individuals for whom the PopData are not in this range are initialized at random.
            private bool _startAtPopInfo = false;
            public override bool STARTATPOPINFO
            {
                get => _startAtPopInfo;
                set { if (_startAtPopInfo == value) return; _startAtPopInfo = value; OnPropertyChanged(); }
            }
            /// Frequency of using a Metropolis-Hastings step to update Q under the admixture model.
            private int _metroFreq = 10;
            public override int METROFREQ
            {
                get => _metroFreq;
                set { if (_metroFreq == value) return; _metroFreq = Math.Max(1, Math.Min(value, 32768)); OnPropertyChanged(); }
            }
            /// allele frequencies are correlated among pops
            private bool _freqsCorr = true;
            public override bool FREQSCORR
            {
                get => _freqsCorr;
                set { if (_freqsCorr == value) return; _freqsCorr = value; OnPropertyChanged(); }
            }
            /// estimate the probability of the data under the model, used when choosing the best number of subpopulations
            private bool _computerProb = true;
            public override bool COMPUTEPROB
            {
                get => _computerProb;
                set { if (_computerProb == value) return; _computerProb = value; OnPropertyChanged(); }
            }
            private int _admBurnIn = 500;
            public override int ADMBURNIN
            {
                get => _admBurnIn;
                set { if (_admBurnIn == value) return; _admBurnIn = Math.Max(0, Math.Min(value, Instance.mainparams.BURNIN)); OnPropertyChanged(); }
            }
            private bool _randomize = true;
            public override bool RANDOMIZE
            {
                get => _randomize;
                set { if (_randomize == value) return; _randomize = value; OnPropertyChanged(); }
            }
            private int _seed = 2245;
            public override int SEED
            {
                get => _seed;
                set { if (_seed == value) return; _seed = Math.Max(0, Math.Min(value, 32768)); OnPropertyChanged(); }
            }
            private bool _reportThitRate = false;
            public override bool REPORTHITRATE
            {
                get => _reportThitRate;
                set { if (_reportThitRate == value) return; _reportThitRate = value; OnPropertyChanged(); }
            }

            ///// Invalid user input, expected number, of either columns or row, is zero
            //private bool _zeroExpectedColsOrRows;
            //public override bool zeroExpectedColsOrRows
            //{
            //    get => _zeroExpectedColsOrRows;
            //    set { if (_zeroExpectedColsOrRows == value) return; _zeroExpectedColsOrRows = value; OnPropertyChanged(); }
            //}
            ///// Indicates wrong number of rows
            //private bool _rowsError;
            //public override bool rowsError
            //{
            //    get => _rowsError;
            //    set { if (_rowsError == value) return; _rowsError = value; OnPropertyChanged(); }
            //}
            ///// Expected number of rows in data file
            //private int _expectedRows;
            //public override int expectedRows
            //{
            //    get => _expectedRows;
            //    set { if (_expectedRows == value) return; _expectedRows = value; OnPropertyChanged(); }
            //}
            ///// Acutal number of rows in data file
            //private int _actualRows;
            //public override int actualRows
            //{
            //    get => _actualRows;
            //    set { if (_actualRows == value) return; _actualRows = value; OnPropertyChanged(); }
            //}
            ///// Indicates wrong number of columns
            //private bool _columnsError;
            //public override bool columnsError
            //{
            //    get => _columnsError;
            //    set { if (_columnsError == value) return; _columnsError = value; OnPropertyChanged(); }
            //}
            ///// Row ID, where columns does not match
            //private int _errorRow;
            //public override int errorRow
            //{
            //    get => _errorRow;
            //    set { if (_errorRow == value) return; _errorRow = value; OnPropertyChanged(); }
            //}
            ///// Expected number of columns in certain row
            //private int _expectedColumns;
            //public override int expectedColumns
            //{
            //    get => _expectedColumns;
            //    set { if (_expectedColumns == value) return; _expectedColumns = value; OnPropertyChanged(); }
            //}
            ///// Actual number of columns in certain row

            public override event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
