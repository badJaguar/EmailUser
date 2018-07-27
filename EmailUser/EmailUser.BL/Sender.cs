using EmailUser.Data;
using EmailUser.NLog.Interface;
using NLog;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailUser
{
    public class Sender : ISender
    {/// <summary>
     /// This class contains realisation of async Task SendEmailAsync method.
     /// </summary>
        readonly IEmailSettings _emailSettings;
        readonly SmtpClient _client;
        readonly MailMessage _mailMessage;
        readonly LoggerAdapter _logger = new LoggerAdapter(LogManager.GetCurrentClassLogger());

        public Sender(IEmailSettings emailSettings)
        {
            this._emailSettings = emailSettings;
            this._client = new SmtpClient(this._emailSettings.Host);
            this._mailMessage =
                new MailMessage(this._emailSettings.FromAddress, this._emailSettings.ToAddress)
                {
                    BodyEncoding = Encoding.UTF8,
                    Subject = this._emailSettings.Subject,
                    Body = this._emailSettings.MailBody
                };
        }

        public async Task SendEmailAsync(string file)
        {
            this._client.Credentials =
                new NetworkCredential(this._emailSettings.FromAddress, this._emailSettings.Passw);
            this._client.EnableSsl = true;
            this._client.Port = this._emailSettings.Port;
            this._logger.Trace($"SMTP client got the port {this._emailSettings.Port}.");
            this._logger.Trace($"Attachment {file} was transfered successfully.");

            await this._client.SendMailAsync(this._mailMessage);
            this._mailMessage.Attachments[0].Dispose();
            this._mailMessage.Attachments.Clear();

            Console.WriteLine($"\nFile sent by Email to {this._emailSettings.ToAddress}.\n");
            this._logger.Info($"Email succsessfully sent to {this._emailSettings.ToAddress}.");
        }
    }
}