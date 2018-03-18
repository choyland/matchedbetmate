namespace MatchedBetMate.Business.Interfaces.Services
{
    public interface ICredentialsService
    {
        string AuthToken { get; set; }
        void DeleteCredentials();
    }
}
