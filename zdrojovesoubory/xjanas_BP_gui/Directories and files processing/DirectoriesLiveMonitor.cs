using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenotypeApp.Directories_and_files_processing
{
    internal class DirectoriesLiveMonitor
    {
        private readonly FileSystemWatcher _watcher;
        private readonly System.Timers.Timer _debounceTimer;
        private readonly HashSet<string> _pendingDirs = new();
        private readonly object _lock = new();

        public event Action<IEnumerable<string>> DirectoriesChanged;


        public DirectoriesLiveMonitor(string path, int debounceMs = 500)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path cannot be null or whitespace.", nameof(path));

            _watcher = new FileSystemWatcher(path)
            {
                IncludeSubdirectories = true,
                NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastWrite
            };

            _watcher.InternalBufferSize = 64 * 1024; // 64 Kb

            _watcher.Created += OnFileSystemEvent;
            _watcher.Deleted += OnFileSystemEvent;
            _watcher.Renamed += OnFileSystemRenamedEvent;
            _watcher.Changed += OnFileSystemEvent;

            _debounceTimer = new System.Timers.Timer(debounceMs) { AutoReset = false };
            _debounceTimer.Elapsed += (s, e) => FlushPending();
        }

        private void OnFileSystemEvent(object sender, FileSystemEventArgs e)
        {
            Enqueue(Path.GetDirectoryName(e.FullPath)!);

        }

        private void OnFileSystemRenamedEvent(object sender, RenamedEventArgs e)
        {
            Enqueue(Path.GetDirectoryName(e.FullPath)!);
            Enqueue(Path.GetDirectoryName(e.OldFullPath)!);
        }

        private void Enqueue(string dir)
        {
            lock (_lock)
            {
                _pendingDirs.Add(dir);
                _debounceTimer.Stop();
                _debounceTimer.Start();
            }
        }

        private void FlushPending()
        {
            List<string> toNotify;
            lock (_lock)
            {
                toNotify = _pendingDirs.ToList();
                _pendingDirs.Clear();
            }
            DirectoriesChanged?.Invoke(toNotify);
        }


        public void Start() => _watcher.EnableRaisingEvents = true;
        public void Stop() => _watcher.EnableRaisingEvents = false;
    }
}
