﻿using fh_service_directory_api.core.Entities;

namespace fh_service_directory_api.core.Interfaces.Entities
{
    public interface IOpenReferralTaxonomy : IEntityBase<string>
    {
        ICollection<OpenReferralLinktaxonomycollection>? LinkTaxonomyCollection { get; init; }
        string Name { get; set; }
        string? Parent { get; set; }
        string? Vocabulary { get; set; }
    }
}