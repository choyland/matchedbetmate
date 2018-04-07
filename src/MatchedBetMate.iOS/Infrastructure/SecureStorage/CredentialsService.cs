using System;
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
            get => ValueForKey(AuthTokenKey);
            set => SetValueForKey(value, AuthTokenKey);
        }

        public string ValueForKey(string key)
        {
            var record = ExistingRecordForKey(key);
            var match = SecKeyChain.QueryAsRecord(record, out var resultCode);

            return resultCode == SecStatusCode.Success ? NSString.FromData(match.ValueData, NSStringEncoding.UTF8) : string.Empty;
        }

        public void SetValueForKey(string value, string key)
        {
            var record = ExistingRecordForKey(key);
            if (string.IsNullOrEmpty(value))
            {
                if (!string.IsNullOrEmpty(ValueForKey(key)))
                    RemoveRecord(record);

                return;
            }

            // if the key already exists, remove it
            if (!string.IsNullOrEmpty(ValueForKey(key)))
                RemoveRecord(record);

            var result = SecKeyChain.Add(CreateRecordForNewKeyValue(key, value));
            if (result != SecStatusCode.Success)
            {
                throw new Exception($"Error adding record: {result}");
            }
        }

        private static SecRecord CreateRecordForNewKeyValue(string key, string value)
        {
            return new SecRecord(SecKind.GenericPassword)
            {
                Account = key,
                Service = "MatchedBetMate",
                Label = key,
                ValueData = NSData.FromString(value, NSStringEncoding.UTF8),
            };
        }

        private static SecRecord ExistingRecordForKey(string key)
        {
            return new SecRecord(SecKind.GenericPassword)
            {
                Account = key,
                Service = "MatchedBetMate",
                Label = key,
            };
        }

        private static bool RemoveRecord(SecRecord record)
        {
            var result = SecKeyChain.Remove(record);
            if (result != SecStatusCode.Success)
            {
                throw new Exception($"Error removing record: {result}");
            }

            return true;
        }
    }
}