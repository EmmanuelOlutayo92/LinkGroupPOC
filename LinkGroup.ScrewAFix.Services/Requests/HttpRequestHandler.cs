using LinkGroup.ScrewAFix.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LinkGroup.ScrewAFix.Services.Requests
{

   
    public class HttpRequestHandler : IHttpRequestHandler
    {
        private readonly HttpClient _httpClient;
        public HttpRequestHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IServiceResponse> RestAPiCallPost(IServiceRequestDetails request, string endpoint)
        {
            IServiceResponse serviceresponseDetails  = null;
            var content = new StringContent(JsonConvert.SerializeObject(request.RequestModel), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(endpoint,content);

            if (response.IsSuccessStatusCode)
            {
                serviceresponseDetails = JsonConvert.DeserializeObject<IServiceResponse>(await response.Content.ReadAsStringAsync());
            }

            return serviceresponseDetails;
        }

    }
}
