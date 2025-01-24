namespace Alfateam.ID.API.Models
{
    public class AuthResultTokens
    {
        public string SessID { get; set; } 
        public DateTime ExpiresAt { get; set; } 
        public string RefreshToken { get; set; }
    }
}
