namespace EmailUser.Data
{
    public interface IEmailSettings : IMailPass
    {
        string ToAddress { get; set; }

        string DirPath { get; set; }

        string FilePath { get; set; }

        string Message { get; set; }

        string Host { get; set; }

        int Port { get; set; }

        string Subject { get; set; }

        string MailBody { get; set; }
    }
}
