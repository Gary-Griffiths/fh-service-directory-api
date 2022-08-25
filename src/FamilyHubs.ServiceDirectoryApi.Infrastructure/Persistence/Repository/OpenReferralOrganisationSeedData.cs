﻿using FamilyHubs.ServiceDirectory.Shared.Entities;
using FamilyHubs.ServiceDirectory.Shared.Enums;
using fh_service_directory_api.core.Interfaces.Entities;

namespace fh_service_directory_api.infrastructure.Persistence.Repository;

public class OpenReferralOrganisationSeedData
{
    public IReadOnlyCollection<OpenReferralOrganisation> SeedOpenReferralOrganistions()
    {
        List<OpenReferralOrganisation> openReferralOrganistions = new()
        {
            GetBristolCountyCouncil()
        };

        return openReferralOrganistions;
    }

    private OpenReferralOrganisation GetBristolCountyCouncil()
    {
        var bristolCountyCouncil = new OpenReferralOrganisation(
            "72e653e8-1d05-4821-84e9-9177571a6013",
            "Bristol County Council",
            "Bristol County Council",
            null,
            new Uri("https://www.bristol.gov.uk/").ToString(),
            "https://www.bristol.gov.uk/",
            new List<OpenReferralReview>(),
            GetBristolCountyCouncilServices("72e653e8-1d05-4821-84e9-9177571a6013")
            );
        return bristolCountyCouncil;
    }

    private List<OpenReferralService> GetBristolCountyCouncilServices(string parentId)
    {
        return new()
        {
            new OpenReferralService(
                "4591d551-0d6a-4c0d-b109-002e67318231",
                parentId,
                "Aid for Children with Tracheostomies",
                @"Aid for Children with Tracheostomies is a national self help group operating as a registered charity and is run by parents of children with a tracheostomy and by people who sympathise with the needs of such families. ACT as an organisation is non profit making, it links groups and individual members throughout Great Britain and Northern Ireland.",
                null,
                null,
                null,
                null,
                null,
                "active",
                "www.actfortrachykids.com",
                "support@ACTfortrachykids.com",
                null,
                new List<IOpenReferralServiceDelivery>( new List<OpenReferralServiceDelivery>
                {
                    new OpenReferralServiceDelivery("9db7f878-be53-4a45-ac47-472568dfeeea",ServiceDelivery.Online)
                }),
                new List<IOpenReferralEligibility>(new List<OpenReferralEligibility>
                {
                    new OpenReferralEligibility("9109Children","",null,0,13,new List<IOpenReferralTaxonomy>())
                }),
                new List<IOpenReferralFunding>(),
                new List<IOpenReferralHoliday_Schedule>(),
                new List<IOpenReferralLanguage>()
                {
                    new OpenReferralLanguage("724630f7-4c8b-4864-96be-bc74891f2b4a","English")
                },
                new List<IOpenReferralRegular_Schedule>(),
                new List<IOpenReferralReview>(),
                new List<IOpenReferralContact>(new List<OpenReferralContact>()
                {
                    new OpenReferralContact(
                        "1567",
                        "Mr",
                        "John Smith",
                        new List<IOpenReferralPhone>(new List<OpenReferralPhone>()
                        {
                            new OpenReferralPhone("1567", "01827 65778")
                        }
                        ))
                }),
                new List<IOpenReferralCost_Option>(),
                new List<IOpenReferralService_Area>()
                {
                    new OpenReferralService_Area(Guid.NewGuid().ToString(), "National", null, null, "http://statistics.data.gov.uk/id/statistical-geography/K02000001")
                },
                new List<IOpenReferralServiceAtLocation>( new List<OpenReferralServiceAtLocation>()
                {
                    new OpenReferralServiceAtLocation(
                        "1749",
                        new OpenReferralLocation(
                            "256d0b97-d4c4-48e8-9475-bd7d42d1fc69",
                            "",
                            "",
                            52.6312,
                            -1.66526,
                            new List<IOpenReferralPhysical_Address>(new List<OpenReferralPhysical_Address>()
                            {
                                new OpenReferralPhysical_Address(
                                    Guid.NewGuid().ToString(),
                                    "75 Sheepcote Lane",
                                    ", Stathe, Tamworth, Staffordshire, ",
                                    "B77 3JN",
                                    "England",
                                    null
                                    )
                            }),
                            new List<IAccessibility_For_Disabilities>()
                            ),
                        new List<IOpenReferralHoliday_Schedule>(),
                        new List<IOpenReferralRegular_Schedule>()
                        )

                }),
                new List<IOpenReferralService_Taxonomy>( new List<OpenReferralService_Taxonomy>()
                {
                    new OpenReferralService_Taxonomy
                    ("9107",
                    null,
                    new OpenReferralTaxonomy(
                        "bccsource:Organisation",
                        "Organisation",
                        "BCC Data Sources",
                        null
                        )),

                    new OpenReferralService_Taxonomy
                    ("9108",
                    null,
                    new OpenReferralTaxonomy(
                        "bccprimaryservicetype:38",
                        "Support",
                        "BCC Primary Services",
                        null
                        )),

                    new OpenReferralService_Taxonomy
                    ("9109",
                    null,
                    new OpenReferralTaxonomy(
                        "bccagegroup:37",
                        "Children",
                        "BCC Age Groups",
                        null
                        )),

                    new OpenReferralService_Taxonomy
                    ("9110",
                    null,
                    new OpenReferralTaxonomy(
                        "bccusergroup:56",
                        "Long Term Health Conditions",
                        "BCC User Groups",
                        null
                        ))
                }
                ))

        };
    }

    /*
    private OpenReferralOrganisation GetSuffolkCountyCouncil()
    {
        var suffolkCountyCouncil = new OpenReferralOrganisation(
            Guid.NewGuid().ToString(),
            "Suffolk County Council",
            "Suffolk County Council",
            null,
            new Uri("https://www.suffolk.gov.uk/").ToString(),
            "https://www.suffolk.gov.uk/",
            null,
            GetSuffolkCountyCouncilServices()
        );

        return suffolkCountyCouncil;
    }

    private List<OpenReferralService> GetSuffolkCountyCouncilServices()
    {
        return new()
        {
            new OpenReferralService(
                Guid.NewGuid().ToString(),
                "Robins Childcare",
                @"Day nursery

A purpose built childcare establishment for 3 months to 11 years.

Seperate rooms for differing age groups.

2, 3 and 4 year old grant funding available.
Full day care and sessional care.

Wrap around and Out of School Care, including full care available out of term.",
                null,
                null,
                "3 month - 11 years old",
                "3 month - 11 years old",
                "Day Nursery",
                "Active",
                "http://www.robinschildcare.co.uk",
                "info@robinschildcare.co.uk",
                "Please contact the provider directly for cost information or look on their web site.",
                new List<OpenReferralEligibility>
                {
                    new OpenReferralEligibility(
                        Guid.NewGuid().ToString(),
                        "3 months - 11 years old",
                        null,
                        11,
                        1,
                        new List<OpenReferralTaxonomy>
                        {
                            new OpenReferralTaxonomy(
                                Guid.NewGuid().ToString(),
                                "Child Care",
                                "Service",
                                null, //To do
                                null
                                )
                        }

                        )
                    
                },
                new List<OpenReferralFunding>
                )
        };
    }
    */
}