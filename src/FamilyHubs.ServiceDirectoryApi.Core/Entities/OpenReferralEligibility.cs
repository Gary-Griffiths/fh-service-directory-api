﻿using FamilyHubs.SharedKernel;
using FamilyHubs.SharedKernel.Interfaces;
using fh_service_directory_api.core.Interfaces.Entities;

namespace FamilyHubs.ServiceDirectory.Shared.Entities;

public class OpenReferralEligibility : EntityBase<string>, IOpenReferralEligibility, IAggregateRoot
{
    private OpenReferralEligibility() { }
    public OpenReferralEligibility(string id, string eligibility, string? linkId, int maximum_age, int minimum_age, ICollection<IOpenReferralTaxonomy>? taxonomys)
    {
        Id = id;
        Eligibility = eligibility;
        LinkId = linkId;
        Maximum_age = maximum_age;
        Minimum_age = minimum_age;
        Taxonomys = taxonomys as ICollection<OpenReferralTaxonomy>;
    }
    public string Eligibility { get; init; } = default!;
    public string? LinkId { get; init; }
    public int Maximum_age { get; init; }
    public int Minimum_age { get; init; }
    public ICollection<OpenReferralTaxonomy>? Taxonomys { get; set; }
}
