﻿using FamilyHubs.ServiceDirectoryApi.Core.Entities.OpenReferralReviews;
using FamilyHubs.ServiceDirectoryApi.Core.Entities.OpenReferralServices;
using FamilyHubs.SharedKernel;
using FamilyHubs.SharedKernel.Interfaces;

namespace FamilyHubs.ServiceDirectoryApi.Core.Entities.OpenReferralOrganisations;

public class OpenReferralOrganisation : EntityBase<string>, IAggregateRoot, IOpenReferralOrganisation
{
    private OpenReferralOrganisation() { }

    public OpenReferralOrganisation(
        string id,
        string name = default!,
        string? description = default!,
        string? logo = default!,
        string? uri = default!,
        string? url = default!,
        ICollection<OpenReferralReview>? reviews = default!,
        ICollection<OpenReferralService>? services = default!
    )
    {
        Id = id;
        Name = name ?? default!;
        Description = description ?? string.Empty;
        Logo = logo ?? string.Empty;
        Uri = uri ?? string.Empty;
        Url = url ?? string.Empty;
        Reviews = reviews ?? default!;
        Services = services ?? default!;
        //_reviews = (IList<IOpenReferralReview>)(reviews ?? new List<IOpenReferralReview>());
        //_services = (IList<IOpenReferralService>)(services ?? new List<IOpenReferralService>());
    }

    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; } = string.Empty;
    public string? Logo { get; private set; } = string.Empty;
    public string? Uri { get; private set; } = string.Empty;
    public string? Url { get; private set; } = string.Empty;
    public virtual ICollection<OpenReferralReview>? Reviews { get; set; } = new List<OpenReferralReview>();
    public virtual ICollection<OpenReferralService>? Services { get; set; } = new List<OpenReferralService>();

    public void Update(IOpenReferralOrganisation openReferralOpenReferralOrganisation)
    {
        Name = openReferralOpenReferralOrganisation.Name;
        Description = openReferralOpenReferralOrganisation.Description;
        Logo = openReferralOpenReferralOrganisation.Logo;
        Uri = openReferralOpenReferralOrganisation.Uri;
        Url = openReferralOpenReferralOrganisation.Url;
    }
}
