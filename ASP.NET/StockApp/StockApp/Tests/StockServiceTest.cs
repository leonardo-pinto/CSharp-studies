using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace Tests
{
    public class StockServiceTest
    {
        private readonly IStocksService _stocksService;

        public StockServiceTest()
        {
            _stocksService = new StocksService();
        }

        #region CreateBuyOrder
        [Fact]
        public void CreateBuyOrder_NullBuyOrder()
        {
            // Arrange
            BuyOrderRequest? buyOrderRequest = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]
        public void CreateBuyOrder_InvalidQuantityLess()
        {
            // Arrange
            BuyOrderRequest? buyOrderRequest = new()
            { 
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                Price = 100,
                Quantity = 0,
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]
        public void CreateBuyOrder_InvalidQuantityMore()
        {
            // Arrange
            BuyOrderRequest? buyOrderRequest = new()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                Price = 100,
                Quantity = 100001,
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]
        public void CreateBuyOrder_InvalidPriceLess()
        {
            // Arrange
            BuyOrderRequest? buyOrderRequest = new()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                Price = 0,
                Quantity = 100,
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]
        public void CreateBuyOrder_InvalidPriceMore()
        {
            // Arrange
            BuyOrderRequest? buyOrderRequest = new()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                Price = 10001,
                Quantity = 100,
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]
        public void CreateBuyOrder_StockSymbolNull()
        {
            // Arrange
            BuyOrderRequest? buyOrderRequest = new()
            {
                StockSymbol = null,
                StockName = "Microsoft",
                Price = 10,
                Quantity = 100,
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]
        public void CreateBuyOrder_InvalidDateAndTime()
        {
            // Arrange
            BuyOrderRequest? buyOrderRequest = new()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                Price = 10,
                Quantity = 100,
                DateAndTimeOfOrder = DateTime.Parse("1999-12-31")
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }

        [Fact]
        public void CreateBuyOrder_CorrectValues()
        {
            // Arrange
            BuyOrderRequest? buyOrderRequest = new()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                Price = 10,
                Quantity = 100,
                DateAndTimeOfOrder = DateTime.Parse("2005-12-31")
            };

            // Act
            BuyOrderResponse buyOrderResponse = _stocksService.CreateBuyOrder(buyOrderRequest);

            Assert.NotEqual(Guid.Empty, buyOrderResponse.BuyOrderID);
        }

        #endregion

        #region CreateSellOrder

        [Fact]
        public void CreateSellOrder_NullBuyOrder()
        {
            // Arrange
            SellOrderRequest? sellOrderRequest = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                _stocksService.CreateSellOrder(sellOrderRequest);
            });
        }

        [Fact]
        public void CreateSellOrder_InvalidQuantityLess()
        {
            // Arrange
            SellOrderRequest? sellOrderRequest = new()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                Price = 100,
                Quantity = 0,
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _stocksService.CreateSellOrder(sellOrderRequest);
            });
        }

        [Fact]
        public void CreateSellOrder_InvalidQuantityMore()
        {
            // Arrange
            SellOrderRequest? sellOrderRequest = new()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                Price = 100,
                Quantity = 100001,
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _stocksService.CreateSellOrder(sellOrderRequest);
            });
        }

        [Fact]
        public void CreateSellOrder_InvalidPriceLess()
        {
            // Arrange
            SellOrderRequest? sellOrderRequest = new()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                Price = 0,
                Quantity = 100,
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _stocksService.CreateSellOrder(sellOrderRequest);
            });
        }

        [Fact]
        public void CreateSellOrder_InvalidPriceMore()
        {
            // Arrange
            SellOrderRequest? sellOrderRequest = new()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                Price = 10001,
                Quantity = 100,
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _stocksService.CreateSellOrder(sellOrderRequest);
            });
        }

        [Fact]
        public void CreateSellOrder_StockSymbolNull()
        {
            // Arrange
            SellOrderRequest? sellOrderRequest = new()
            {
                StockSymbol = null,
                StockName = "Microsoft",
                Price = 10,
                Quantity = 100,
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _stocksService.CreateSellOrder(sellOrderRequest);
            });
        }

        [Fact]
        public void CreateSellOrder_InvalidDateAndTime()
        {
            // Arrange
            SellOrderRequest? sellOrderRequest = new()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                Price = 10,
                Quantity = 100,
                DateAndTimeOfOrder = DateTime.Parse("1999-12-31")
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _stocksService.CreateSellOrder(sellOrderRequest);
            });
        }

        [Fact]
        public void CreateSellOrder_CorrectValues()
        {
            // Arrange
            SellOrderRequest? sellOrderRequest = new()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                Price = 10,
                Quantity = 100,
                DateAndTimeOfOrder = DateTime.Parse("2005-12-31")
            };

            // Act
            SellOrderResponse sellOrderResponse = _stocksService.CreateSellOrder(sellOrderRequest);

            Assert.NotEqual(Guid.Empty, sellOrderResponse.SellOrderID);
        }


        #endregion

        #region GetAllBuyOrders

        [Fact]
        public void GetAllBuyrOders_Empty()
        {
            // Act
            List<BuyOrderResponse> buyOrders = _stocksService.GetBuyOrders();

            // Assert
            Assert.Empty(buyOrders);
        }

        [Fact]
        public void GetAllBuyOrders_AddedOrders()
        {
            // Arrange
            BuyOrderRequest? buyOrderRequest1 = new()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                Price = 100,
                Quantity = 10,
                DateAndTimeOfOrder = DateTime.Parse("2005-12-31")
            };

            BuyOrderRequest? buyOrderRequest2 = new()
            {
                StockSymbol = "AMZN",
                StockName = "Amazon",
                Price = 100,
                Quantity = 10,
                DateAndTimeOfOrder = DateTime.Parse("2005-12-31")
            };

            List<BuyOrderRequest> buyOrderRequests = new() { buyOrderRequest1, buyOrderRequest2 };
            List<BuyOrderResponse> buyOrderResponsesAdd = new();

            foreach (BuyOrderRequest buyOrderRequest in buyOrderRequests)
            {
                buyOrderResponsesAdd.Add(_stocksService.CreateBuyOrder(buyOrderRequest));
            }

            // Act
            List<BuyOrderResponse> buyOrderResponsesFromGet = _stocksService.GetBuyOrders();

            // Assert

            foreach (BuyOrderResponse buyOrderResponse in buyOrderResponsesAdd)
            {
                Assert.Contains(buyOrderResponse, buyOrderResponsesFromGet);
            }
        }

        #endregion

        #region GetAllSellOrders
        [Fact]
        public void GetAllSellOrders_Empty()
        {
            // Act
            List<SellOrderResponse> sellOrders = _stocksService.GetSellOrders();

            // Assert
            Assert.Empty(sellOrders);
        }

        [Fact]
        public void GetAllSellOrders_AddedOrders()
        {
            // Arrange
            SellOrderRequest? sellOrderRequest1 = new()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft",
                Price = 100,
                Quantity = 10,
                DateAndTimeOfOrder = DateTime.Parse("2005-12-31")
            };

            SellOrderRequest? sellOrderRequest2 = new()
            {
                StockSymbol = "AMZN",
                StockName = "Amazon",
                Price = 100,
                Quantity = 10,
                DateAndTimeOfOrder = DateTime.Parse("2005-12-31")
            };

            List<SellOrderRequest> sellOrderRequests = new() { sellOrderRequest1, sellOrderRequest2 };
            List<SellOrderResponse> sellOrderResponsesAdd = new();

            foreach (SellOrderRequest sellOrderRequest in sellOrderRequests)
            {
                sellOrderResponsesAdd.Add(_stocksService.CreateSellOrder(sellOrderRequest));
            }

            // Act
            List<SellOrderResponse> sellOrderResponsesFromGet = _stocksService.GetSellOrders();

            // Assert

            foreach (SellOrderResponse sellOrderResponse in sellOrderResponsesAdd)
            {
                Assert.Contains(sellOrderResponse, sellOrderResponsesFromGet);
            }
        }

        #endregion
    }
}