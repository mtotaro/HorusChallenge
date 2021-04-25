using Horus.Core.Helpers.Interface;
using MvvmCross.Logging;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Horus.Core.Helpers.Implementation
{
    internal class StorageHelper : IStorageHelper
    {
        private readonly IMvxLog _mvxLog;
        private readonly string _accessTokenKeyName;

        public StorageHelper(IMvxLog mvxLog)
        {
            _mvxLog = mvxLog;
            _accessTokenKeyName = "access_token";

        }

        public async Task SetAccessToken(string accessToken)
        {
            try
            {
                Application.Current.Properties[_accessTokenKeyName] = accessToken;
                await Application.Current.SavePropertiesAsync();

                //await SecureStorage.SetAsync(_accessTokenKeyName, accessToken);
            }
            catch (Exception ex)
            {
                _mvxLog.ErrorException("Cannot set access token", ex);
            }
        }

        public async Task<string> GetAccessToken()
        {
            try
            {
                if (!Application.Current.Properties.ContainsKey(_accessTokenKeyName))
                    return null;

                return (string)Application.Current.Properties[_accessTokenKeyName];
                //return await SecureStorage.GetAsync(_accessTokenKeyName);
            }
            catch (Exception ex)
            {
                _mvxLog.ErrorException("Cannot get access token", ex);

                return null;
            }
        }

    }
}
