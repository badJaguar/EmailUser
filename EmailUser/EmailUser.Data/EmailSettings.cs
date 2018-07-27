namespace EmailUser.Data
{
    public class EmailSettings : IEmailSettings
    {
        public string DirPath { get; set; } = @"C:\Files";

        public string FilePath { get; set; } = @"C:\Files\sample.txt";

        public string Host { get; set; } = "smtp.gmail.com";

        public string MailBody { get; set; } = "Привет друзья!";

        public string Message { get; set; }

        public int Port { get; set; } = 587;

        public string Subject { get; set; } = "Test message";

        public string ToAddress { get; set; } = "bad_jaguar@mail.ru";

        public string FromAddress { get; set; } = "bad.bad.jaguar@gmail.com";

        public string Passw { get; set; } = "Sikander1986";
    }
}
