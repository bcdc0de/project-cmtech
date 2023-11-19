using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EmailManager.Models;

namespace EmailApi.ApiClients
{
    public class OutlookApiClient
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly HttpClient _httpClient;

        public OutlookApiClient(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _httpClient = new HttpClient();
        }

        public async Task<List<Email>> GetEmails()
        {
            // Implemente a lógica real para obter e-mails do Outlook usando HttpClient ou outra biblioteca.
            // ...
            return new List<Email>();
        }
    }
}
