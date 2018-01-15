namespace SRM.Common.Configurations
{
    public class EmailConfiguration
    {
        public string SmtpServer { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FromEmail { get; set; }

        public string ResetPasswordText { get; set; }
    }
}
