using FamilyHubs.ServiceDirectory.Shared.Enums;
using fh_service_directory_api.core.Entities;

namespace fh_service_directory_api.infrastructure.Persistence.Repository;

public class OpenReferralServiceDeliveriesSeedData
{
    public IReadOnlyCollection<OpenReferralServiceDelivery> SeedOpenReferralServiceDeliveries()
    {
        List<OpenReferralServiceDelivery> openReferralServiceDeliveries = new List<OpenReferralServiceDelivery>(new List<OpenReferralServiceDelivery>()
                {
                    new OpenReferralServiceDelivery("d6216ae3-44c0-4a43-b815-967205fbb0da",ServiceDelivery.Online),
                    new OpenReferralServiceDelivery("a13fc959-ee91-4961-a354-d735957c84f6",ServiceDelivery.InPerson),
                    new OpenReferralServiceDelivery("f7b0cb9e-2a4c-4869-8bdd-b1609b1cf640",ServiceDelivery.Telephone),
                    new OpenReferralServiceDelivery("93fbebac-3dd1-4f48-b6fb-67cf6cc0075e",ServiceDelivery.NotEntered),

                });

        return openReferralServiceDeliveries;
    }
}