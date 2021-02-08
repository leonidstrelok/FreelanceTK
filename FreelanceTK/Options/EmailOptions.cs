namespace FreelanceTK.Options
{
    /// <summary>
    /// Опции для почты
    /// </summary>
    public class EmailOptions
    {
        public string Sender { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
