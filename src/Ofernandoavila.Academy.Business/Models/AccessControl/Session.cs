namespace Ofernandoavila.Academy.Business.Models.AccessControl
{
    public class Session : Entity
    {
        public string UserAgent { get; private set; }
        public DateTime SignInDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string Token { get; private set; }
        public string RefreshToken { get; private set; }
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Session() { }

        public Session(Guid id, string userAgent, DateTime expirationDate, string token, string refreshToken, Guid userId)
        {
            Id = id;
            UserAgent = userAgent;
            ExpirationDate = expirationDate;
            Token = token;
            RefreshToken = refreshToken;
            UserId = userId;
        }
    }
}
