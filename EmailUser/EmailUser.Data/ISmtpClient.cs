using System.Net;
using System.Threading.Tasks;

namespace EmailUser.Data
{
    /// <summary>
    /// The interface of SmtpClientWrapper class.
    /// </summary>
    public interface ISmtpClient
    {
        ICredentialsByHost Credentials { get; set; }

        bool EnableSsl { get; set; }

        int Port { get; set; }

        string Host { get; set; }

        Task SendEmailAsync(string file);
    }
}
