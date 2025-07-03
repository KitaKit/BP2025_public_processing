using System;
using System.Collections.Concurrent;
using System.Threading;

namespace GenotypeApp.Additional_programs_logic.CLUMPP
{
    internal class ProgressRegistry
    {
        public readonly record struct ClumppProgressReport(double Fraction, int LastK, TimeSpan Remaining, int CompletedJobs, int TotalJobs);

        private readonly ConcurrentDictionary<int, JobProgressEstimator> _jobs = new();
        private volatile int _lastK;    
        private readonly ConcurrentDictionary<int, bool> _completed = new();
        private int _completedCount;

        public int TotalJobs => _jobs.Count;
        public void RegisterJob(int k, double totalIter)
        {
            _jobs.TryAdd(k, new JobProgressEstimator(totalIter));
            _completed[k] = false;
        }

        public void Update(int k, double iter)
        {
            _lastK = k;
            if (_jobs.TryGetValue(k, out var est))
            {
                est.Update(iter, DateTime.UtcNow);

                if (iter >= est.TotalIterations - 1 && !_completed[k])
                {
                    _completed[k] = true;
                    Interlocked.Increment(ref _completedCount);
                }
            }
        }

        public ClumppProgressReport MakeReport()
        {
            if (_jobs.IsEmpty) return default;
            var now = DateTime.UtcNow;

            double sumPct = 0;
            int n = 0;
            TimeSpan etaMax = TimeSpan.Zero;

            foreach (var est in _jobs.Values)
            {
                var (pct, eta, _) = est.Snapshot(now);
                sumPct += pct;
                if (eta.HasValue && eta.Value > etaMax)
                    etaMax = eta.Value;
            }

            n = _jobs.Count;
            double fraction = n > 0 ? sumPct / n : 0;

            int completed = _completedCount;   
            int total = _jobs.Count;

            return new ClumppProgressReport(fraction, _lastK, etaMax, completed, total);
        }
    }
}
