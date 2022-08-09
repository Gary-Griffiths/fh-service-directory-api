﻿using fh_service_directory_api.core.Interfaces.Entities.Aggregates;
using MediatR;

namespace fh_service_directory_api.core.Concretions.Features.Organisations.Commands.Create;

public class CreateOrganisationCommand : IRequest<string>
{
    public IOrganisation Organisation { get; init; }

    public CreateOrganisationCommand(IOrganisation organisation)
    {
        Organisation = organisation;
    }

}

public class CreateOrganisationCommandHandler : IRequestHandler<CreateOrganisationCommand, string>
{
    private readonly DBContext _context;

    public CreateOrOrganisationCommandHandler(ILAHubDbContext context)
    {
        _context = context;
    }
    public async Task<string> Handle(Create request, CancellationToken cancellationToken)
    {
        var entity = request.OrOrganisation;

        try
        {
            entity.AddDomainEvent(new OrganisationCreatedEvent(entity));

            _context.OpenReferralOrOrganisations.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

        if (entity is not null)
            return entity.Id;
        else
            return string.Empty;
    }
}
