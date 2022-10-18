using FamilyHubs.ServiceDirectory.Shared.Enums;
using fh_service_directory_api.core.Entities;

namespace fh_service_directory_api.infrastructure.Persistence.Repository;

public class OpenReferralTaxonomiesSeedData
{
    public IReadOnlyCollection<OpenReferralTaxonomy> SeedOpenReferralTaxonomies()
    {
        List<OpenReferralTaxonomy> openReferralTaxonomies = new List<OpenReferralTaxonomy>(new List<OpenReferralTaxonomy>()
                {
                    new OpenReferralTaxonomy(
                        "bccsource:Organisation",
                        "Organisation",
                        "BCC Data Sources",
                        null
                        ),
                    new OpenReferralTaxonomy(
                        "bccprimaryservicetype:38",
                        "Support",
                        "BCC Primary Services",
                        null
                        ),
                    new OpenReferralTaxonomy(
                        "bccagegroup:37",
                        "Children",
                        "BCC Age Groups",
                        null
                        ),
                    new OpenReferralTaxonomy(
                        "bccusergroup:56",
                        "Long Term Health Conditions",
                        "BCC User Groups",
                        null
                        ),
                    new OpenReferralTaxonomy(
                        "bccusergroupTestDelete:56",
                        "Test Conditions",
                        "BCC User Groups",
                        null
                        )
                });

        return openReferralTaxonomies;
    }
}