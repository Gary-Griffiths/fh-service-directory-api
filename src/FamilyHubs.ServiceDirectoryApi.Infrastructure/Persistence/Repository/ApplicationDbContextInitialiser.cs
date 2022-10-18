using fh_service_directory_api.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace fh_service_directory_api.infrastructure.Persistence.Repository;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;      
    }

    public async Task InitialiseAsync(IConfiguration configuration)
    {
        try
        {
            if (_context.Database.IsSqlServer() || _context.Database.IsNpgsql())
            {
                if (configuration.GetValue<bool>("RecreateDbOnStartup"))
                {
                    _context.Database.EnsureDeleted();
                    _context.Database.EnsureCreated();
                }
                else
                    await _context.Database.MigrateAsync();
            }
            //else
            //{
            //    _context.Database.EnsureDeleted();
            //}
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedServiceDeliveriesAsync();
            await TrySeedTaxonomiesAsync();
            await TrySeedOrganisationsAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedOrganisationsAsync()
    {
        if (_context.OpenReferralOrganisations.Any())
            return;

        var openReferralOrganisationSeedData = new OpenReferralOrganisationSeedData(_context);

        IReadOnlyCollection<OpenReferralOrganisation> openReferralOrganisations = openReferralOrganisationSeedData.SeedOpenReferralOrganistions();

        foreach (var openReferralOrganisation in openReferralOrganisations)
        {
            _context.OpenReferralOrganisations.Add(openReferralOrganisation);
        }

        await _context.SaveChangesAsync();

    }

    private async Task TrySeedTaxonomiesAsync()
    {
        if (_context.OpenReferralTaxonomies.Any())
            return;

        var openReferralTaxonomiesSeedData = new OpenReferralTaxonomiesSeedData();

        IReadOnlyCollection<OpenReferralTaxonomy> openReferralTaxonomies = openReferralTaxonomiesSeedData.SeedOpenReferralTaxonomies();

        foreach (var openReferralTaxonomy in openReferralTaxonomies)
        {
            _context.OpenReferralTaxonomies.Add(openReferralTaxonomy);
        }

        await _context.SaveChangesAsync();
    }

    private async Task TrySeedServiceDeliveriesAsync()
    {
        if (_context.OpenReferralServiceDeliveries.Any())
            return;

        var openReferralServiceDeliveriesSeedData = new OpenReferralServiceDeliveriesSeedData();

        IReadOnlyCollection<OpenReferralServiceDelivery> openReferralServiceDeliveries = openReferralServiceDeliveriesSeedData.SeedOpenReferralServiceDeliveries();

        foreach (var openReferralServiceDelivery in openReferralServiceDeliveries)
        {
            _context.OpenReferralServiceDeliveries.Add(openReferralServiceDelivery);
        }

        await _context.SaveChangesAsync();
    }
}
