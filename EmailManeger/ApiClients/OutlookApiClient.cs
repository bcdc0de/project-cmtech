using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using EmailManeger.Models;

namespace EmailManeger.ApiClients;
public class OutlookApiClient
{
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly string _redirectUri;

    public OutlookApiClient(string clientId, string clientSecret, string redirectUri)
    {
        _clientId = clientId;
        _clientSecret = clientSecret;
        _redirectUri = redirectUri;
    }

    public async Task<string> GetAccessToken()
    {

        var scopes = new string[] {
            "https://graph.microsoft.com/.default"
        };

        var cca = ConfidentialClientApplicationBuilder
            .Create(_clientId)
            .WithClientSecret(_clientSecret)
            .WithAuthority(new Uri("https://login.microsoftonline.com/common/v2.0"))
            .Build();

        var result = await cca.AcquireTokenForClient(scopes)
            .ExecuteAsync();

        return result.AccessToken;
    }
}

