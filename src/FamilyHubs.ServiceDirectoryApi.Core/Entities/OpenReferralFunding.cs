﻿using FamilyHubs.SharedKernel;
using fh_service_directory_api.core.Interfaces.Entities;

namespace fh_service_directory_api.core.Entities;

public class OpenReferralFunding : EntityBase<string>, IOpenReferralFunding
{
    private OpenReferralFunding() { }
    public OpenReferralFunding(string id, string source)
    {
        Id = id;
        Source = source;
    }
    public string Source { get; init; } = default!;
}
