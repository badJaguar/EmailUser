using EmailUser.Data;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace EmailUser.BL.Test
{
    [TestFixture]
    public class EmailUserSendTests
    {
        [Test]
        public void MethodSender_TheFileCreatedAndSendOfEmailIsSuccessfullAndFileWasDeleted_CalledOnce()
        {
            var settings = new Mock<IEmailSettings>();
            var watcher = new Mock<IWatcher>();
            var file = new Mock<IFileWrapper>();
            var sender = new Mock<ISender>(MockBehavior.Strict);

            sender.Setup(method => method.SendEmailAsync(It.IsAny<string>())).Returns((Task.CompletedTask));
            var realizer = new EmailSendRealizer(settings.Object, sender.Object, watcher.Object, file.Object);
            realizer.Start();

            watcher.Raise(e => e.Created += null,
                this, new FileSystemEventArgs(WatcherChangeTypes.Created, @"C:\Files", string.Empty));
            sender.Verify(s => s.SendEmailAsync(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void MethodSender_TheFileCreatedAndSendOfEmailIsSuccessfullAndFileWasDeleted_NeverCalled()
        {
            var settings = new Mock<IEmailSettings>();
            var watcher = new Mock<IWatcher>();
            var file = new Mock<IFileWrapper>();
            var sender = new Mock<ISender>(MockBehavior.Strict);

            sender.Setup(method => method.SendEmailAsync(It.IsAny<string>())).Returns((Task.CompletedTask));
            var realizer = new EmailSendRealizer(settings.Object, sender.Object, watcher.Object, file.Object);

            realizer.Start();

            sender.Verify(s => s.SendEmailAsync(It.IsAny<string>()), Times.Never);
        }
    }
}
