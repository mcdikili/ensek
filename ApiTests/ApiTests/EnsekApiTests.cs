using ApiTests.Fixture;
using ApiTests.Models;
using Autofac;
using RestSharp;
using System.Text.Json;

namespace ApiTests;

public class EnsekApiTests : IClassFixture<TestFixture>
{
    private readonly TestFixture _fixture;

    public EnsekApiTests(TestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ResetEndpoint_ShouldWork_WithValidBearerToken()
    {
        var resetUrl = $"{_fixture.Container.Resolve<Settings>().BaseUrl}";
        var client = new RestClient(resetUrl);
        var request = new RestRequest("/ENSEK/reset", Method.Post);
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", $"Bearer {_fixture.BearerToken}");

        var response = await client.ExecuteAsync(request);

        Assert.True(response.IsSuccessful, "Reset request failed.");
    }

    [Fact]
    public async Task BuyEnergy_ShouldWork_WithValidBearerToken()
    {
        var buyUrl = $"{_fixture.Container.Resolve<Settings>().BaseUrl}";
        var client = new RestClient(buyUrl);
        var request = new RestRequest("/ENSEK/buy/1/100", Method.Put);
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", $"Bearer {_fixture.BearerToken}");

        var response = await client.ExecuteAsync(request);

        Assert.True(response.IsSuccessful, "Buy energy request failed.");
    }
}
