using Microsoft.Extensions.Configuration;
using ServiceContracts;
using System;
using System.Net.Http;
using System.Text.Json;

namespace Services
{
    public class FinnhubService : IFinnhubService
    {
        private readonly HttpClient _httpClient;
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        //public FinnhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        //{
        //    _httpClientFactory = httpClientFactory;
        //    _configuration = configuration;
        //}

        public FinnhubService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            var responseString = await _httpClient.GetStringAsync($"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token={_configuration["FinnhubToken"]}");


            // convert response body (from JSON into Dictionary)
            Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(responseString);

            if (responseDictionary == null)
            {
                throw new InvalidOperationException("No response from server");
            }

            if (responseDictionary.ContainsKey("error"))
            {
                throw new InvalidOperationException(Convert.ToString(responseDictionary["error"]));
            }

            // return response dictionary back to the caller
            return responseDictionary;
        }

        //public Dictionary<string, object>? GetCompanyProfile(string stockSymbol)
        //{
        //    // create http client
        //    HttpClient httpClient = _httpClientFactory.CreateClient();

        //    // create http request
        //    HttpRequestMessage httpRequestMessage = new()
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri($"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token={_configuration["FinnhubToken"]}")
        //    };

        //    // send request
        //    HttpResponseMessage httpResponseMessage = httpClient.Send(httpRequestMessage);

        //    // read response body
        //    string responseBody = new StreamReader(httpResponseMessage.Content.ReadAsStream()).ReadToEnd();

        //    // convert response body (from JSON into Dictionary)
        //    Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(responseBody);

        //    if (responseDictionary == null)
        //    {
        //        throw new InvalidOperationException("No response from server");
        //    }

        //    if (responseDictionary.ContainsKey("error"))
        //    {
        //        throw new InvalidOperationException(Convert.ToString(responseDictionary["error"]));
        //    }

        //    // return response dictionary back to the caller
        //    return responseDictionary;
        //}

        //public Dictionary<string, object>? GetStockPriceQuote(string stockSymbol)
        //{
        //    // create http client
        //    HttpClient httpClient = _httpClientFactory.CreateClient();

        //    // create http request
        //    HttpRequestMessage httpRequestMessage = new()
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["FinnhubToken"]}") //URI includes the secret token
        //    };

        //    // send request
        //    HttpResponseMessage httpResponseMessage = httpClient.Send(httpRequestMessage);

        //    // read response body
        //    string responseBody = new StreamReader(httpResponseMessage.Content.ReadAsStream()).ReadToEnd();

        //    // converts response body (from JSON into Dictionary)
        //    Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(responseBody);

        //    if (responseDictionary == null)
        //    {
        //        throw new InvalidOperationException("No response from server");
        //    }

        //    if (responseDictionary.ContainsKey("error"))
        //    {
        //        throw new InvalidOperationException(Convert.ToString(responseDictionary["error"]));
        //    }

        //    // return response dictionary back to the caller
        //    return responseDictionary;
        //}
    }
}