using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using Urchin.Api.Persistence;
using Urchin.Api.Persistence.Entities;
using Urchin.Shared.Features.ManageParties.AddParty;

namespace Urchin.Api.Features.ManageParties.AddParty;

public class AddPartyEndpoint : EndpointBaseAsync.WithRequest<AddPartyRequest>.WithActionResult<bool>
{
    private readonly UrchinContext _context;

    public AddPartyEndpoint(UrchinContext context)
    {
        _context = context;
    }
    [HttpPost(AddPartyRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(AddPartyRequest request, CancellationToken cancellationToken = default)
    {
        var party = new Party{Name = request.Party.Name};

        await _context.Parties.AddAsync(party, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(party.Id);
    }
}