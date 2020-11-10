using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MembershipApi.IntergrationTests;
using Xunit;
using Newtonsoft.Json;
using MembershipApi.Dtos;
using MembershipApi.Models;

namespace MembershipApi.IntegrationTests
{
    public class PaymentsTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public PaymentsTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Theory]
        [InlineData(123, HttpStatusCode.OK)]
        [InlineData(432, HttpStatusCode.OK)]
        [InlineData(553, HttpStatusCode.OK)]
        [InlineData(111, HttpStatusCode.NotFound)]
        [InlineData(222, HttpStatusCode.NotFound)]
        [InlineData(333, HttpStatusCode.NotFound)]
        public async Task TestGetBalanceReturnsCorrectStatusCodeAsync(int EmployeeId, HttpStatusCode ExpectedOutput)
        {
            // Arrange
            var request = $"/api/accounts/{EmployeeId}/balance";

            // Act
            var response = await Client.GetAsync(request);

            // Asserts
            Assert.Equal(ExpectedOutput, response.StatusCode);
        }

        [Theory]
        [InlineData(123, 22.33)]
        [InlineData(432, 3.21)]
        [InlineData(553, 44.22)]
        public async Task TestGetBalanceReturnsCorrectDataAsync(int EmployeeId, double ExpectedBalance)
        {
            // Arrange
            var request = $"/api/accounts/{EmployeeId}/balance";

            // Act
            var response = await Client.GetAsync(request);
            var jsonFromResponse = await response.Content.ReadAsStringAsync();
            UserDto result = JsonConvert.DeserializeObject<UserDto>(jsonFromResponse);
            
            // Assert
            Assert.Equal(ExpectedBalance, result.Balance);
        }
        [Theory]
        [InlineData("Bradley", HttpStatusCode.Created)]
        [InlineData("John", HttpStatusCode.Created)]
        [InlineData("Timmy", HttpStatusCode.Created)]

        public async Task TestPostAccountsReturnsCorrectStatusCodeAsync(string name, HttpStatusCode ExpectedOutput)
        {
            var request = new
            {
                Url = "/api/accounts",
                Body = new
                {
                    Name = name
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            Assert.Equal(ExpectedOutput, response.StatusCode);
        }
        [Theory]
        [InlineData("Bradley", HttpStatusCode.BadRequest)]
        [InlineData("John", HttpStatusCode.BadRequest)]
        [InlineData("Timmy", HttpStatusCode.BadRequest)]

        public async Task TestPostAccountsReturnsCorrectStatusCodeWithBadRequestAsync(string name, HttpStatusCode ExpectedOutput)
        {
            var request = new
            {
                Url = "/api/accounts",
                Body = new
                {
                    Names = name
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            Assert.Equal(ExpectedOutput, response.StatusCode);
        }
        [Theory]
        [InlineData(532, 1.00, HttpStatusCode.OK)]
        [InlineData(444, 1.00, HttpStatusCode.OK)]
        [InlineData(121, 1.00, HttpStatusCode.OK)]

        public async Task TestPatchAccountsReturnsCorrectStatusCodeAsync(int id, double amount, HttpStatusCode ExpectedOutput)
        {
            var request = new
            {
                Url = $"/api/accounts/{id}",
                Body = new
                {
                    Amount = amount
                }
            };

            // Act
            var response = await Client.PatchAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            Assert.Equal(ExpectedOutput, response.StatusCode);
        }
        [Theory]
        [InlineData(10, 600, "Liam", 13.50)]
        [InlineData(1.50, 601, "George", 11.50)]
        [InlineData(0.50, 602, "Becca", 154.83)]

        public async Task TestPatchAccountsReturnsCorrectResponseAsync(double topUpAmmount, int id, string expectedName, double expectedBalance)
        {
            var request = new
            {
                Url = $"/api/accounts/{id}",
                Body = new
                {
                    Amount = topUpAmmount
                }
            };

            // Act
            var response = await Client.PatchAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var jsonFromResponse = await response.Content.ReadAsStringAsync();
            User result = JsonConvert.DeserializeObject<User>(jsonFromResponse);
            // Assert
            Assert.Equal(id, result.EmployeeId);
            Assert.Equal(expectedName, result.Name);
            Assert.Equal(expectedBalance, result.Balance);
        }
    }
}
