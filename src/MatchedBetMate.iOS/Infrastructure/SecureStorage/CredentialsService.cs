using Foundation;
using MatchedBetMate.iOS.Business.Interfaces.Services;
using Security;

namespace MatchedBetMate.iOS.Infrastructure.SecureStorage
{
    public class CredentialsService : ICredentialsService
    {
        private const string AuthTokenKey = "AuthToken";

        public string AuthToken
        {
            get => GetCredential(AuthTokenKey);
            set => SaveCredentials(AuthTokenKey, value);
        }

        public void DeleteCredentials()
        {
            var queryRecord = new SecRecord(SecKind.GenericPassword)
            {
                Generic = NSData.FromString(AuthTokenKey)
            };

            var matchedRecord = SecKeyChain.QueryAsRecord(queryRecord, out var result);
            if (result == SecStatusCode.Success)
            {
                SecKeyChain.Remove(matchedRecord);
            }
        }

        private static void SaveCredentials(string key, string value)
        {
            var queryRecord = new SecRecord(SecKind.GenericPassword)
            {
                Generic = NSData.FromString(key)
            };

            var matchedRecord = SecKeyChain.QueryAsRecord(queryRecord, out var result);
            if (result == SecStatusCode.Success)
            {
                var updated = matchedRecord;
                updated.ValueData = value;

                SecKeyChain.Update(queryRecord, updated);
            }
            else
            {
                var newRecord = new SecRecord(SecKind.GenericPassword)
                {
                    ValueData = value,
                    Generic = key
                };

                SecKeyChain.Add(newRecord);
            }
        }

        private static string GetCredential(string key)
        {
            var record = new SecRecord(SecKind.GenericPassword)
            {
                Generic = NSData.FromString(key)
            };

            var matched = SecKeyChain.QueryAsRecord(record, out var result);
            return result != SecStatusCode.Success ? null : matched.ValueData.ToString();
        }
    }
}