using System;
using System.Collections.Generic;
using System.Linq;

namespace GenotypeApp.Additional_programs_logic.CLUMPP
{
    internal class JobProgressEstimator
    {
        private readonly double _totalIterations;     
        private readonly double _alpha;               
        private readonly int _window;                 
        private readonly Queue<double> _recent = new();

        private double _speedEwma;                    
        private double _lastIter;
        private DateTime _lastStamp;

        public double TotalIterations => _totalIterations;

        public JobProgressEstimator(double totalIterations, double alpha = 0.25, int window = 7)
        {
            _totalIterations = totalIterations;
            _alpha = alpha;
            _window = window;
        }

        public void Update(double iter, DateTime ts)
        {
            if (_lastStamp != default && iter > _lastIter)
            {
                var dt = (ts - _lastStamp).TotalSeconds;
                if (dt > 0)
                {
                    var speed = (iter - _lastIter) / dt;
                    _speedEwma = _speedEwma == 0 ? speed : _alpha * speed + (1 - _alpha) * _speedEwma;
                    _recent.Enqueue(speed);
                    if (_recent.Count > _window) _recent.Dequeue();
                }
            }
            _lastIter = iter;
            _lastStamp = ts;
        }

        public (double pct, TimeSpan? eta, double sigmaPct) Snapshot(DateTime now)
        {
            if (_lastIter >= _totalIterations - 1)        
                return (1.0, TimeSpan.Zero, 0);

            if (_speedEwma < 1e-9)
                return (0, null, 0);

            var elapsed = (now - _lastStamp).TotalSeconds;
            var syntheticDone = _lastIter + _speedEwma * elapsed;
            var rawPct = syntheticDone / _totalIterations;

            double sigma = 0;
            if (_recent.Count >= 2)
            {
                var m = _recent.Average();
                sigma = Math.Sqrt(_recent.Sum(s => (s - m) * (s - m)) / (_recent.Count - 1));
            }
            var sigmaPct = sigma / _speedEwma;                   
            var capPct = Math.Max(0.0, 1.0 - Math.Max(0.01, 3 * sigmaPct));
            var shownPct = Math.Clamp(Math.Min(rawPct, capPct), 0.0, 1.0);

            var syntheticRemaining = _totalIterations - syntheticDone;
            var safety = 0.01 * _totalIterations;     
            var restIter = Math.Max(syntheticRemaining, safety);

            TimeSpan eta = TimeSpan.FromSeconds(restIter / _speedEwma);
            return (shownPct, eta, sigmaPct);
        }
    }
}
