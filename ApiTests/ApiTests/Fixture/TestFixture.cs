using System.Diagnostics;
using System.Text.Json;
using ApiTests.Models;
using Autofac;
using RestSharp;

namespace ApiTests.Fixture
{
    public class TestFixture : IDisposable
    {
        public ILifetimeScope Container { get; private set; }
        public string BearerToken { get; private set; }

        public TestFixture()
        {
            // Perform setup logic here (runs once per test class)
            var containerBuilder = TestDependencies.GetContainerBuilder();
            Container = containerBuilder.Build();

            var settings = Container.Resolve<Settings>();
            if (settings != null)
            {
                Debug.Print(settings.BaseUrl.ToString());
            }

            // Retrieve Bearer token
            BearerToken = RetrieveBearerToken(settings.BaseUrl);
        }

        private string RetrieveBearerToken(string baseUrl)
        {
            var loginUrl = $"{baseUrl}";
            var client = new RestClient(loginUrl);
            var request = new RestRequest("/ENSEK/login",Method.Post);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                username = "test",
                password = "testing"
            });

            var response = client.ExecuteAsync(request).GetAwaiter().GetResult();
            if (!response.IsSuccessful)
            {
                throw new Exception("Failed to retrieve Bearer token.");
            }

            var responseJson = JsonDocument.Parse(response.Content);
            return responseJson.RootElement.GetProperty("access_token").GetString();
        }

        public void Dispose()
        {
            // Perform cleanup logic here (if needed)
            Container?.Dispose();
        }
    }
}
