using FluentAssertions;

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
        
        }

        #endregion
    }
}
