namespace CVGeneratorApp.Api.Common.Models
{
    public class Token
    {
        public string AccessToken { get; set; } = null!;
        public DateTime Expiration { get; set; }
    }
}
