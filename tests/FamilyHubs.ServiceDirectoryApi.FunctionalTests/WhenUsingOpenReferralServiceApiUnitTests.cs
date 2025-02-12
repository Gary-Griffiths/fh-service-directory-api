﻿using FamilyHubs.ServiceDirectory.Shared.Models.Api.OpenReferralServices;
using FamilyHubs.SharedKernel;
using FluentAssertions;
using System.Text;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FamilyHubs.ServiceDirectoryApi.FunctionalTests;

[Collection("Sequential")]
public class WhenUsingOpenReferralServiceApiUnitTests : BaseWhenUsingOpenReferralApiUnitTests
{
#if DEBUG
    [Fact]
#else
    [Fact(Skip = "This test should be run locally")]
#endif
    public async Task ThenTheOpenReferralServicesIsDeleted()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri(_client.BaseAddress + $"api/services/96781fd9-95a2-4196-8db6-0f083f1c38fc")
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var retVal = await JsonSerializer.DeserializeAsync<bool>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        retVal.Should().Be(true);
    }

#if DEBUG
    [Fact]
#else
    [Fact(Skip = "This test should be run locally")]
#endif
    public async Task ThenTheOpenReferralServicesAreRetrieved()
    {
        GetServicesUrlBuilder getServicesUrlBuilder = new GetServicesUrlBuilder();
        string url = getServicesUrlBuilder
                    .WithStatus("active")
                    .WithEligibility(0,99)
                    .WithProximity(52.6312, -1.66526, 1609.34)
                    .WithPage(1, 10)
                    .Build();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + $"api/services{url}")
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();


        var retVal = await JsonSerializer.DeserializeAsync<PaginatedList<OpenReferralServiceDto>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var item = retVal?.Items.FirstOrDefault(x => x.Id == "4591d551-0d6a-4c0d-b109-002e67318231");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        retVal.Should().NotBeNull();
        item.Should().NotBeNull();
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        item.Id.Should().Be("4591d551-0d6a-4c0d-b109-002e67318231");
    }

#if DEBUG
    [Fact]
#else
    [Fact(Skip = "This test should be run locally")]
#endif
    public async Task ThenTheOpenReferralServicesWithEligabiltyAreRetrieved()
    {
        GetServicesUrlBuilder getServicesUrlBuilder = new GetServicesUrlBuilder();
        string url = getServicesUrlBuilder
                    .WithStatus("active")
                    .WithEligibility(0, 99)
                    .WithPage(1, 10)
                    .Build();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + $"api/services{url}")
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();


        var retVal = await JsonSerializer.DeserializeAsync<PaginatedList<OpenReferralServiceDto>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var item = retVal?.Items.FirstOrDefault(x => x.Id == "4591d551-0d6a-4c0d-b109-002e67318231");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        retVal.Should().NotBeNull();
        item.Should().NotBeNull();
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        item.Id.Should().Be("4591d551-0d6a-4c0d-b109-002e67318231");
    }

#if DEBUG
    [Fact]
#else
    [Fact(Skip = "This test should be run locally")]
#endif
    public async Task ThenTheOpenReferralServicesWithProximityAreRetrieved()
    {
        GetServicesUrlBuilder getServicesUrlBuilder = new GetServicesUrlBuilder();
        string url = getServicesUrlBuilder
                    .WithStatus("active")
                    .WithProximity(52.6312, -1.66526, 1609.34)
                    .WithPage(1, 10)
                    .Build();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + $"api/services{url}")
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();


        var retVal = await JsonSerializer.DeserializeAsync<PaginatedList<OpenReferralServiceDto>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var item = retVal?.Items.FirstOrDefault(x => x.Id == "4591d551-0d6a-4c0d-b109-002e67318231");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        retVal.Should().NotBeNull();
        item.Should().NotBeNull();
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        item.Id.Should().Be("4591d551-0d6a-4c0d-b109-002e67318231");
    }

#if DEBUG
    [Fact]
#else
    [Fact(Skip = "This test should be run locally")]
#endif
    public async Task ThenTheOpenReferralServicesWithServiceDeliveryAreRetrieved()
    {
        GetServicesUrlBuilder getServicesUrlBuilder = new GetServicesUrlBuilder();
        string url = getServicesUrlBuilder
                    .WithStatus("active")
                    .WithDelimitedSearchDeliveries("online")
                    .WithPage(1, 10)
                    .Build();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + $"api/services{url}")
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var retVal = await JsonSerializer.DeserializeAsync<PaginatedList<OpenReferralServiceDto>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var item = retVal?.Items.FirstOrDefault(x => x.Id == "4591d551-0d6a-4c0d-b109-002e67318231");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        retVal.Should().NotBeNull();
        item.Should().NotBeNull();
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        item.Id.Should().Be("4591d551-0d6a-4c0d-b109-002e67318231");
    }

#if DEBUG
    [Fact]
#else
    [Fact(Skip = "This test should be run locally")]
#endif
    public async Task ThenTheOpenReferralServicesWithTaxonomiesAreRetrieved()
    {
        GetServicesUrlBuilder getServicesUrlBuilder = new GetServicesUrlBuilder();
        string url = getServicesUrlBuilder
                    .WithStatus("active")
                    .WithDelimitedTaxonomies("bccprimaryservicetype:38,bccagegroup:37")
                    .WithPage(1, 10)
                    .Build();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + $"api/services{url}")
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var retVal = await JsonSerializer.DeserializeAsync<PaginatedList<OpenReferralServiceDto>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var item = retVal?.Items.FirstOrDefault(x => x.Id == "4591d551-0d6a-4c0d-b109-002e67318231");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        retVal.Should().NotBeNull();
        item.Should().NotBeNull();
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        item.Id.Should().Be("4591d551-0d6a-4c0d-b109-002e67318231");
    }

#if DEBUG
    [Fact]
#else
    [Fact(Skip = "This test should be run locally")]
#endif
    public async Task ThenTheOpenReferralServiceByIdIsRetrieved()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + "api/services/4591d551-0d6a-4c0d-b109-002e67318231"),

        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var retVal = await JsonSerializer.DeserializeAsync<OpenReferralServiceDto>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        retVal.Should().NotBeNull();
        ArgumentNullException.ThrowIfNull(retVal, nameof(retVal));
        retVal.Id.Should().Be("4591d551-0d6a-4c0d-b109-002e67318231");
    }

#if DEBUG
    [Fact]
#else
    [Fact(Skip = "This test should be run locally")]
#endif
    public async Task ThenTheOpenReferralServicesWithinTheOrganisationAreRetrieved()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + "api/organisationservices/72e653e8-1d05-4821-84e9-9177571a6013"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();


        var retVal = await JsonSerializer.DeserializeAsync<List<OpenReferralServiceDto>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var firstService = retVal?.FirstOrDefault();

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        retVal.Should().NotBeNull();
        firstService.Should().NotBeNull();
        ArgumentNullException.ThrowIfNull(firstService, nameof(firstService));
        firstService.Id.Should().Be("4591d551-0d6a-4c0d-b109-002e67318231");
    }

#if DEBUG
    [Fact]
#else
    [Fact(Skip = "This test should be run locally")]
#endif
    public async Task ThenTheOpenReferralServiceIsUpdated()
    {
        GetServicesUrlBuilder getServicesUrlBuilder = new GetServicesUrlBuilder();
        string url = getServicesUrlBuilder
                    .WithStatus("active")
                    .WithEligibility(0, 99)
                    .WithProximity(52.6312, -1.66526, 1609.34)
                    .WithPage(1, 10)
                    .Build();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress + $"api/services{url}")
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();


        var retVal = await JsonSerializer.DeserializeAsync<PaginatedList<OpenReferralServiceDto>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var item = retVal?.Items.FirstOrDefault(x => x.Id == "4591d551-0d6a-4c0d-b109-002e67318231");
        ArgumentNullException.ThrowIfNull(item, nameof(item));

        item.Name += " Changed";
        item.Description += " Changed";

        var updaterequest = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(_client.BaseAddress + $"api/services/4591d551-0d6a-4c0d-b109-002e67318231"),
            Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"),
        };

        using var updateresponse = await _client.SendAsync(updaterequest);

        updateresponse.EnsureSuccessStatusCode();

        var stringResult = await updateresponse.Content.ReadAsStringAsync();

        updateresponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        stringResult.ToString().Should().Be("4591d551-0d6a-4c0d-b109-002e67318231");

    }

#if DEBUG
    [Fact]
#else
    [Fact(Skip = "This test should be run locally")]
#endif
    public async Task ThenTheOpenReferralServiceIsCreated()
    {
        OpenReferralServiceDto openReferralService = WhenUsingOpenReferralOrganisationApiUnitTests.GetTestCountyCouncilServicesRecord("72e653e8-1d05-4821-84e9-9177571a6013");

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(_client.BaseAddress + $"api/services"),
            Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(openReferralService), Encoding.UTF8, "application/json"),
        };

        using var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var stringResult = await response.Content.ReadAsStringAsync();

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        stringResult.ToString().Should().Be(openReferralService.Id);

    }
}
