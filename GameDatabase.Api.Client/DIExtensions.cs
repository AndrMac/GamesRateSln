using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase.Api.Client
{
    public static class DIExtensions
    {
        public static IServiceCollection AddGameAPIClient(
            this IServiceCollection services,
            string baseAddress,
            string apiKey,
            Action<HttpClient> httpConfig = null)
        {
            services.AddHttpClient("API-CLIENT", client =>
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("key", apiKey);
                if (httpConfig != null)
                {
                    httpConfig(client);
                }
            });

            return services;
        }
    }
}
