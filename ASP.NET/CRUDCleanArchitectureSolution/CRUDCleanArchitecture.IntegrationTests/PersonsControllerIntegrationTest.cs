using FluentAssertions;
using Fizzler;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

namespace CrudTests
{
    public class PersonsControllerIntegrationTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public PersonsControllerIntegrationTest(CustomWebApplicationFactory factory)
        {
            // calls ConfigureWebHost (override in CustomWebApplicationFactory)
            // executes Program.cs file ""<Program>""
            _client = factory.CreateClient();
        }

        #region Index
        [Fact]
        public async void Index_ToReturnView()
        {
            // Arrange

            // Act
            HttpResponseMessage response = await _client.GetAsync("/persons/index");

            // Assert
            response.Should().BeSuccessful();

            string responseBody = await response.Content.ReadAsStringAsync();

            // use Fizzler to check HTML DOM
            HtmlDocument html = new();
            // generate HTML document based on string response
            html.LoadHtml(responseBody);
            var document = html.DocumentNode;

            document.QuerySelectorAll("table.persons").Should().NotBeNull(); // table tag with persons class
        }

        #endregion
    }
}
