using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using Urchin.Api.Persistence;
using Urchin.Shared.Features.ManageParties.DeleteParty;

namespace Urchin.Api.Features.ManageParties.DeleteParty;

public class DeletePartyEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<bool>
{
    private readonly UrchinContext _context;

    public DeletePartyEndpoint(UrchinContext context)
    {
        _context = context;
    }
    [HttpDelete(DeletePartyRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(int partyId, CancellationToken cancellationToken = default)
    {
        var party = await _context.Parties.SingleOrDefaultAsync(party => party.Id == partyId, cancellationToken);

        if(party is null)
            return BadRequest("Party could not be found.");

        _context.Parties.Remove(party);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(true);
    }
}