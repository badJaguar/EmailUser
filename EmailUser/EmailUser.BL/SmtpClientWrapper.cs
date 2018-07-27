using EmailUser.Data;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailUser
{
    public class SmtpClientWrapper : ISmtpClient
    {
        readonly SmtpClient client;

        public ICredentialsByHost Credentials
        {
            get => this.client.Credentials;
            set => this.client.Credentials = value;
        }

        public bool EnableSsl
        {
            get => this.client.EnableSsl;
            set => this.client.EnableSsl = value;
        }

        public int Port
        {
            get => this.client.Port;
            set => this.client.Port = value;
        }

        public string Host
        {
            get => this.client.Host;
            set => this.client.Host = value;
        }

        public Task SendEmailAsync(string file)
        {
            Console.WriteLine($"Email {file} succsessfully sent.");
            return Task.CompletedTask;
        }
    }
}
