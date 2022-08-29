﻿using Ardalis.GuardClauses;
using FamilyHubs.ServiceDirectory.Shared.Models.Api.OpenReferralServices;
using FamilyHubs.ServiceDirectoryApi.Api.Helper;
using FamilyHubs.ServiceDirectoryApi.Core.Entities.OpenReferralServices;
using FamilyHubs.ServiceDirectoryApi.Infrastructure.Persistence.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FamilyHubs.ServiceDirectoryApi.Api.Queries.GetOpenReferralService;

public class GetOpenReferralServiceByIdQuery : IRequest<OpenReferralServiceDto>
{
    public GetOpenReferralServiceByIdQuery(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
}

public class GetOpenReferralServiceByIdCommandHandler : IRequestHandler<GetOpenReferralServiceByIdQuery, OpenReferralServiceDto>
{
    private readonly ServiceDirectoryDbContext _context;

    public GetOpenReferralServiceByIdCommandHandler(ServiceDirectoryDbContext context)
    {
        _context = context;
    }

    public async Task<OpenReferralServiceDto> Handle(GetOpenReferralServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.OpenReferralServices
            .Include(x => x.ServiceDelivery)
            .Include(x => x.Eligibilitys)
            .Include(x => x.Contacts)
            .ThenInclude(x => x.Phones)
            .Include(x => x.Languages)
            .Include(x => x.Service_areas)
            .Include(x => x.Service_at_locations)
            .ThenInclude(x => x.Location)
            .ThenInclude(x => x.Physical_addresses)
            .Include(x => x.Service_taxonomys)
            .ThenInclude(x => x.Taxonomy)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(OpenReferralService), request.Id);
        }

        var result = OpenReferralDtoHelper.GetOpenReferralServiceDto(entity);
        /*
        var result = new OpenReferralServiceDto(
            entity.Id,
            entity.Name,
            entity.Description,
            entity.Accreditations,
            entity.Assured_date,
            entity.Attending_access,
            entity.Attending_type,
            entity.Deliverable_type,
            entity.Status,
            entity.Url,
            entity.Email,
            entity.Fees,
            new List<IOpenReferralServiceDeliveryExDto>(entity.ServiceDelivery.Select(x => new OpenReferralServiceDeliveryExDto(x.Id, x.ServiceDelivery)).ToList()),
            new List<IOpenReferralEligibilityDto>(entity.Eligibilitys.Select(x => new OpenReferralEligibilityDto(x.Id, x.Eligibility, x.Maximum_age, x.Minimum_age)).ToList()),
            new List<IOpenReferralContactDto>(entity.Contacts.Select(x => new OpenReferralContactDto(x.Id, x.Title, x.Name, new List<IOpenReferralPhoneDto>(x.Phones?.Select(x => new OpenReferralPhoneDto(x.Id, x.Number)).ToList()))).ToList()),
            new List<IOpenReferralCostOptionDto>(entity.Cost_options.Select(x => new OpenReferralCostOptionDto(x.Id, x.Amount_description, x.Amount, x.LinkId, x.Option, x.Valid_from, x.Valid_to)).ToList()),
            new List<IOpenReferralLanguageDto>(entity.Languages.Select(x => new OpenReferralLanguageDto(x.Id, x.Language)).ToList()),
            new List<IOpenReferralServiceAreaDto>(entity.Service_areas.Select(x => new OpenReferralServiceAreaDto(x.Id, x.Service_area, x.Extent, x.Uri)).ToList()),
            new List<IOpenReferralServiceAtLocationDto>(entity.Service_at_locations.Select(x => new OpenReferralServiceAtLocationDto(x.Id, new OpenReferralLocationDto(x.Location.Id, x.Location.Name, x.Location.Description, x.Location.Latitude, x.Location.Longitude, new List<IOpenReferralPhysicalAddressDto>(x.Location?.Physical_addresses?.Select(x => new OpenReferralPhysicalAddressDto(x.Id, x.Address_1, x.City, x.Postal_code, x.Country, x.State_province)).ToList())))).ToList()),
            new List<IOpenReferralServiceTaxonomyDto>(entity.Service_taxonomys.Select(x => new OpenReferralServiceTaxonomyDto(x.Id, x.Taxonomy != null ? new OpenReferralTaxonomyDto(x.Taxonomy.Id, x.Taxonomy.Name, x.Taxonomy.Vocabulary, x.Taxonomy.Parent) : null)).ToList())
            );
        */
        return result;
    }
}
