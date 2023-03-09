using Microsoft.Extensions.Configuration;
using RepositoryContracts;
using ServiceContracts;


namespace Services
{
    public class FinnhubService : IFinnhubService
    {
        private readonly IFinhubRepository _finnhubRepository;

        public FinnhubService(IFinhubRepository finnhubRepository)
        {
            _finnhubRepository= finnhubRepository;
        }

        public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            Dictionary<string, object>? responseDictionary = await _finnhubRepository.GetCompanyProfile(stockSymbol);
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

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            Dictionary<string, object>? responseDictionary = await _finnhubRepository.GetStockPriceQuote(stockSymbol);
            return responseDictionary;
        }

        public async Task<List<Dictionary<string, string>>?> GetStocks()
        {
            List<Dictionary<string, string>>? stocks = await _finnhubRepository.GetStocks();
            return stocks;
        }

        public async Task<Dictionary<string, object>?> SearchStocks(string stockSymbol)
        {
            Dictionary<string, object>? stock = await _finnhubRepository.SearchStocks(stockSymbol);
            return stock;
        }

        
    }
}