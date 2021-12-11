using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase.Api.Client
{
    public static class ClientFactory
    {
        public static T CreateClient<T>(HttpClient httpClient, string apiKey)
            where T : ClientBase
        {

            return Activator.CreateInstance(typeof(T), httpClient, apiKey) as T;
        }
    }
}
