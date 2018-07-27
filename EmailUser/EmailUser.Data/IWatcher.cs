using System.IO;

namespace EmailUser.Data
{
    public interface IWatcher
    {
        event FileSystemEventHandler Created;

        string Path { get; set; }

        string Filter { get; set; }

        bool EnableRaisingEvents { get; set; }

    }
}
