namespace Annotations.Web.dScribe.Models
{
    public class AppSettings
    {
        public IdentityServerSettings IdentityServer { get; set; }

        public AccessServiceSettings AccessService { get; set; }

        public EmailSetting Email { get; set; }
    }

    public class IdentityServerSettings
    {
        public string Url { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

    public class AppServiceSettings
    {
        public string Url { get; set; }
        public string Name { get; set; }
    }
    public class AccessServiceSettings
    {
        public string Url { get; set; }
        public string Name { get; set; }
    }
    public class EmailSetting
    {
        public string SenderAddress { get; set; }
        public string SMTPServer { get; set; }
        public string ToAddress { get; set; }
    }
}
