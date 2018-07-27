using EmailUser.Data;
using System.IO;

namespace EmailUser
{
    public class WatcherWrapper : IWatcher
    {
        readonly FileSystemWatcher _watcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="WatcherWrapper"/> class.
        /// </summary>
        public WatcherWrapper() => this._watcher = new FileSystemWatcher();

        public event FileSystemEventHandler Created
        {
            add => this._watcher.Created += value;
            remove => this._watcher.Created -= value;
        }

        public string Filter
        {
            get => this._watcher.Filter;
            set => this._watcher.Filter = value;
        }

        public bool EnableRaisingEvents
        {
            get => this._watcher.EnableRaisingEvents;
            set => this._watcher.EnableRaisingEvents = value;
        }

        public string Path
        {
            get => this._watcher.Path;
            set => this._watcher.Path = value;
        }
    }
}
