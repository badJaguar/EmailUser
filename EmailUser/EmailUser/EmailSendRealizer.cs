using EmailUser.Data;
using System;
using System.IO;
using EmailUser.NLog.Interface;
using NLog;

namespace EmailUser
{/// <summary>
///  <param cref="EmailSendRealizer">The client class that acts as main logical class in solution 'EmailSender'.
///  </param>It contains method Start()with Create event and private method OnCreated for this event.
///  </summary>
    public class EmailSendRealizer
    {
        readonly ISender _emailSender;
        readonly IFileWrapper _file;
        readonly IEmailSettings _settings;
        readonly IWatcher _watcher;
        readonly LoggerAdapter _logger = new LoggerAdapter(LogManager.GetCurrentClassLogger());

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSendRealizer"/> class.
        /// </summary>
        /// <param name="settings">Reference to class Settings. Refers to the data of the Settings class.</param>
        /// <param name="emailSender">>Reference to the class Sender. Refers the SendEmailAsync() method. Uses async/await.</param>
        /// <param name="watcher"> Reference to the WatcherWrapper class. The wraper of FileSystemWatcher class.</param>
        /// <param name="file">Reference to the FileWrapper class. The wrapper of File's parent class FileInfo.</param>
        public EmailSendRealizer(IEmailSettings settings, ISender emailSender, IWatcher watcher, IFileWrapper file)
        {
            this._settings = settings;
            this._emailSender = emailSender;
            this._watcher = watcher;
            this._file = file;
        }

        public void Start()
        {
            this._watcher.Created += this.OnCreated;
            this._logger.Trace($"The event Created has called.");
            this._watcher.Path = this._settings.DirPath;
            this._watcher.Filter = "*.*";
            this._watcher.EnableRaisingEvents = true;
            // this._watcher.Created -= this.OnCreated;
        }

        void OnCreated(object sender, FileSystemEventArgs e)
        {
            try
            {
                Console.WriteLine($"New file \"{e.Name}\" was created.");
                this._emailSender.SendEmailAsync(e.FullPath).Wait();
                this._file.Delete(e.FullPath);
                Console.WriteLine($"\"{e.Name}\" file \nin \"{e.FullPath}\" was deleted.");
                Console.WriteLine($"{new string('=', 70)}\n");
            }
            catch (NullReferenceException exception)
            {
                if (e.FullPath == null)
                    this._logger.Fatal($"The path{e.FullPath} is invalid.\n {exception.Message}");
                if (e.Name == null)
                    this._logger.Fatal($"Noname file {e.Name}");
            }

            catch (AggregateException exception)
            {
                this._logger.Fatal($"Maybe you created .xls file inside the {e.FullPath} folder." +
                                   $"\nAppart from .xls there are creates .tmp file and then creates" +
                                   $".xls named file.");
            }
        }
    }
}