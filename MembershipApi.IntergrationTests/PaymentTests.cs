using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MembershipApi.IntergrationTests;
using Newtonsoft.Json;
using Xunit;

namespace MembershipApi.IntegrationTests
{
    public class PaymentsTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public PaymentsTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetBalanceSuccessAsync()
        {
            // Arrange
            var request = "/api/payments/123/balance";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode(); 
        }

        [Fact]
        public async Task TestGetBalanceFailureAsync()
        {
            // Arrange
            var request = "/api/payments/452/balance";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
