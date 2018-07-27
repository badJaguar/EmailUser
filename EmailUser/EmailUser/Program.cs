using EmailUser.BL;
using EmailUser.Data;
using Ninject;
using NLog;
using System;
using ILogger = NLog.ILogger;

namespace EmailUser
{
    class Program
    {
        static void Main()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IEmailSettings>().To<EmailSettings>();
                kernel.Bind<IWatcher>().To<WatcherWrapper>();
                kernel.Bind<ISender>().To<Sender>();
                kernel.Bind<IFileWrapper>().To<FileWrapper>();
                kernel.Bind<ILogger>().ToMethod(p => LogManager.GetCurrentClassLogger());
                kernel.Bind<EmailSendRealizer>().ToSelf();

                kernel.Get<EmailSendRealizer>().Start();
            }

            Console.ReadKey();
        }
    }
}
