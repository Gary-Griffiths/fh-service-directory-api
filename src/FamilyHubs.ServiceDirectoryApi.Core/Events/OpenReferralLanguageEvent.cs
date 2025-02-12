﻿using FamilyHubs.SharedKernel;
using fh_service_directory_api.core.Entities;

namespace fh_service_directory_api.core.Events;

public class OpenReferralLanguageEvent : DomainEventBase
{
    public OpenReferralLanguageEvent(OpenReferralLanguage item)
    {
        Item = item;
    }

    public OpenReferralLanguage Item { get; }
}
