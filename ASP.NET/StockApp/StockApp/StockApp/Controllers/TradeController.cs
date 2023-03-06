using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServiceContracts;
using ServiceContracts.DTO;
using StockApp.Models;
using Rotativa.AspNetCore;

namespace StockApp.Controllers
{
    [Route("[controller]")]
    public class TradeController : Controller
    {
        private readonly TradingOptions _tradingOptions;
        private readonly IStocksService _stocksService;
        private readonly IFinnhubService _finnhubService;
        private readonly IConfiguration _configuration;

        public TradeController(
            IOptions<TradingOptions> tradingOptions,
            IStocksService stocksService,
            IFinnhubService finnhubService,
            IConfiguration configuration
        )
        {
            _tradingOptions = tradingOptions.Value;
            _stocksService = stocksService;
            _finnhubService = finnhubService;
            _configuration = configuration;
        }

        [Route("/")]
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            // Reset stock symbol if not exists
            if (string.IsNullOrEmpty(_tradingOptions.DefaultStockSymbol))
            {
                _tradingOptions.DefaultStockSymbol = "MSFT";
            }

            // get company profile from API server
            Dictionary<string, object>? companyProfileDictionary = await _finnhubService.GetCompanyProfile(_tradingOptions.DefaultStockSymbol);

            // get stock price from API server
            Dictionary<string, object>? stockQuoteDictionary = await _finnhubService.GetStockPriceQuote(_tradingOptions.DefaultStockSymbol);

            // create model object
            StockTrade stockTrade = new()
            { StockSymbol = _tradingOptions.DefaultStockSymbol };

            // load data from finnhubservice into model object
            if (companyProfileDictionary != null && stockQuoteDictionary != null)
            {
                stockTrade = new()
                {
                    StockSymbol = Convert.ToString(companyProfileDictionary["ticker"]),
                    StockName = Convert.ToString(companyProfileDictionary["name"]),
                    Price = Convert.ToDouble(stockQuoteDictionary["c"].ToString())
                };
            }

            // Send Finnhub token to View
            ViewBag.FinnhubToken = _configuration["FinnhubToken"];

            return View(stockTrade);
        }

        // makes endpoint as buyOrder
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> BuyOrder(BuyOrderRequest buyOrderRequest)
        {
            // update date of order
            buyOrderRequest.DateAndTimeOfOrder = DateTime.Now;

            // re-validate the model object after updating the date
            ModelState.Clear();
            TryValidateModel(buyOrderRequest);

            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage).ToList();
                StockTrade stockTrade = new() { StockSymbol = buyOrderRequest.StockSymbol, StockName = buyOrderRequest.StockName, Quantity = buyOrderRequest.Quantity };

                return View("Index", stockTrade);
            }

            // invoke service method
            BuyOrderResponse buyOrderResponse = await _stocksService.CreateBuyOrder(buyOrderRequest);

            return RedirectToAction(nameof(Orders));
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> SellOrder(SellOrderRequest sellOrderRequest)
        {
            //update date of order
            sellOrderRequest.DateAndTimeOfOrder = DateTime.Now;

            //re-validate the model object after updating the date
            ModelState.Clear();
            TryValidateModel(sellOrderRequest);

            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                StockTrade stockTrade = new StockTrade() { StockName = sellOrderRequest.StockName, Quantity = sellOrderRequest.Quantity, StockSymbol = sellOrderRequest.StockSymbol };
                return View("Index", stockTrade);
            }

            //invoke service method
            SellOrderResponse sellOrderResponse = await _stocksService.CreateSellOrder(sellOrderRequest);

            return RedirectToAction(nameof(Orders));
        }

        [Route("[action]")]
        public async Task<IActionResult> Orders()
        {
            //invoke service methods
            List<BuyOrderResponse> buyOrderResponses = await _stocksService.GetBuyOrders();
            List<SellOrderResponse> sellOrderResponses = await _stocksService.GetSellOrders();

            //create model object
            Orders orders = new() { BuyOrders = buyOrderResponses, SellOrders = sellOrderResponses };

            ViewBag.TradingOptions = _tradingOptions;

            return View(orders);
        }

        [Route("/orders-pdf")]
        public async Task<IActionResult> OrdersPDF()
        {
            // Get list of all orders
            List<IOrderResponse> orders = new();
            orders.AddRange(await _stocksService.GetBuyOrders());
            orders.AddRange(await _stocksService.GetSellOrders());
            orders.OrderByDescending(order => order.DateAndTimeOfOrder).ToList();

            ViewBag.TradingOptions = _tradingOptions;

            return new ViewAsPdf("OrdersPDF", orders, ViewData)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins()
                {
                    Top = 20,
                    Right = 20,
                    Bottom = 20,
                    Left = 20,
                },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };

        }
    }
}
