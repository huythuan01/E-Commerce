using System;
using BaseLibrary.DTOs;
using Blazored.LocalStorage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace ClientLibrary.Helpers
{
    public class GetHttpClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly LocalStorageService localStorageService;
        private const string HeaderKey = "Authorization";

        // Constructor nhận các dependency
        public GetHttpClient(IHttpClientFactory httpClientFactory, LocalStorageService localStorageService)
        {
            this.httpClientFactory = httpClientFactory;
            this.localStorageService = localStorageService;
        }

        public async Task<HttpClient> GetPrivateHttpCLient()
        {
            var client = httpClientFactory.CreateClient("SystemApiClient");
            var stringToken = await localStorageService.GetToken();
            if (string.IsNullOrEmpty(stringToken)) return client;

            var deserializedToken = Serializations.DeserializeJsonString<UserSession>(stringToken);
            if (deserializedToken == null) return client;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", deserializedToken.Token);
            return client;
        }

        public HttpClient GetPublicHttpClient()
        {
            var client = httpClientFactory.CreateClient("SystemApiClient");
            client.DefaultRequestHeaders.Remove(HeaderKey);
            return client;
        }
    }
}
