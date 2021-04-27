using Horus.Core.Helpers.Interface;
using Horus.Core.Rest.Interfaces;
using MvvmCross.Base;
using MvvmCross.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Horus.Core.Rest.Implementation
{
    public class RestClient : IRestClient
    {
        private readonly IMvxJsonConverter _jsonConverter;
        private readonly IMvxLog _mvxLog;
        private readonly IStorageHelper _storageHelper;

        public RestClient(IMvxJsonConverter jsonConverter, IMvxLog mvxLog, IStorageHelper storageHelper)
        {
            _jsonConverter = jsonConverter;
            _mvxLog = mvxLog;
            _storageHelper = storageHelper;
        }

        public async Task<TResult> MakeApiCall<TResult>(string url, HttpMethod method, object data = null, string token = null) where TResult : class
        {
            url = url.Replace("http://", "https://");

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage { RequestUri = new Uri(url), Method = method })
                {
                    request.Headers.Clear();
                    var accessToken = token ?? await _storageHelper.GetAccessToken();
                    request.Headers.Authorization = new AuthenticationHeaderValue(accessToken);

                    // add content
                    if (method != HttpMethod.Get)
                    {
                        var json = _jsonConverter.SerializeObject(data);
                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    }

                    HttpResponseMessage response = new HttpResponseMessage();
                    try
                    {
                        response = await httpClient.SendAsync(request).ConfigureAwait(false);
                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            throw new ApplicationException("The session was expired. Please, re-login.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _mvxLog.ErrorException("MakeApiCall failed", ex);
                        throw;
                    }

                    var stringSerialized = await response.Content.ReadAsStringAsync();

                    return _jsonConverter.DeserializeObject<TResult>(stringSerialized);
                }
            }
        }
    }
}

