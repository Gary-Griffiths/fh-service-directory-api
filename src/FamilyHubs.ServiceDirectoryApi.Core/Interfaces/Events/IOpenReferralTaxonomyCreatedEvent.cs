﻿using fh_service_directory_api.core.Entities;

namespace fh_service_directory_api.core.Interfaces.Events;

public interface IOpenReferralTaxonomyCreatedEvent
{
    OpenReferralTaxonomy Item { get; }
}
