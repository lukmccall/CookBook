using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CookBook.Services
{
    public class HttpClientInjector : IDisposable
    {

        private readonly Dictionary<string, HttpClient> _clients = new Dictionary<string, HttpClient>();

        public HttpClient GetClientForState(string state)
        {
            if (_clients.ContainsKey(state))
            {
                return _clients[state];
            }

            var newClient = new HttpClient();
            _clients.Add(state, newClient);
            return newClient;
        }

        public void Dispose()
        {
            foreach (var client in _clients.Values)
            {
                client.Dispose();
            }
        }

    }
}
