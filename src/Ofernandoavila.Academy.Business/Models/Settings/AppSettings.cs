namespace Ofernandoavila.Academy.Business.Models.Settings
{
    public class AppSettings
    {
        public int TokenExpirationInMinutes { get; set; }
        public int RefreshTokenExpirationInMinutes { get; set; }
        public string Secret { get; set; }
        public string Emitter { get; set; }
        public string[] ValidIn { get; set; }

        public AppSettings()
        {

        }

        public AppSettings(int tokenExpirationInMinutes, int refreshTokenExpirationInMinutes, string secret, string emitter, string[] validIn)
        {
            TokenExpirationInMinutes = tokenExpirationInMinutes;
            RefreshTokenExpirationInMinutes = refreshTokenExpirationInMinutes;
            Secret = secret;
            Emitter = emitter;
            ValidIn = validIn;
        }
    }
}
