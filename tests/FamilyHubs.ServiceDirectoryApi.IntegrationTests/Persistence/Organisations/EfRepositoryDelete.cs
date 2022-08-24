﻿//using AutoFixture;
//using FamilyHubs.ServiceDirectoryApi.IntegrationTests.Persistence;
//using fh_service_directory_api.core.OpenReferralOrganisationAggregate.Entities;
//using Xunit;

//namespace FamilyHubs.ServiceDirectoryApi.IntegrationTests.Persistence.OpenReferralOrganisations;

//public class EfRepositoryDelete : BaseEfRepositoryTestFixture
//{
//    private readonly Fixture _fixture = new Fixture();

//    [Fact]
//    public async Task DeletesOrOganisationAfterAddingIt()
//    {
//        // Arrange
//        var newOpenReferralOrganisation = _fixture.Create<OpenReferralOrganisation>();
//        ArgumentNullException.ThrowIfNull(newOpenReferralOrganisation, nameof(newOpenReferralOrganisation));
//        var OpenReferralOrganisationId = newOpenReferralOrganisation.Id;
//        var repository = GetRepository<OpenReferralOrganisation>();
//        ArgumentNullException.ThrowIfNull(repository, nameof(repository));
//        await repository.AddAsync(newOpenReferralOrganisation);

//        // Act
//        await repository.DeleteAsync(newOpenReferralOrganisation);

//        // Assert
//        Assert.DoesNotContain(await repository.ListAsync(),
//            newOpenReferralOrganisation => newOpenReferralOrganisation.Id == OpenReferralOrganisationId);
//    }
//}