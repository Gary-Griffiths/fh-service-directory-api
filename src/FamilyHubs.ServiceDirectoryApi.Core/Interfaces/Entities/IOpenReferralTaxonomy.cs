﻿using fh_service_directory_api.core.Entities;

namespace fh_service_directory_api.core.Interfaces.Entities
{
    public interface IOpenReferralTaxonomy
    {
        ICollection<OpenReferralLinktaxonomycollection>? LinkTaxonomyCollection { get; init; }
        string Name { get; init; }
        string? Parent { get; init; }
        string? Vocabulary { get; init; }
    }
}