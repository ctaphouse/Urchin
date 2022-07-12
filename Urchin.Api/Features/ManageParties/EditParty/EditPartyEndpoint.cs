using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using Urchin.Api.Persistence;
using Urchin.Shared.Features.ManageParties.EditParty;

namespace Urchin.Api.Features.ManageParties.EditParty;

public class EditPartyEndpoint : EndpointBaseAsync.WithRequest<EditPartyRequest>.WithActionResult<bool>
{
    private readonly UrchinContext _context;

    public EditPartyEndpoint(UrchinContext context)
    {
        _context = context;
    }
    [HttpPut(EditPartyRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditPartyRequest request, CancellationToken cancellationToken = default)
    {
        var party = await _context.Parties.SingleOrDefaultAsync(party => party.Id == request.Party.Id, cancellationToken);

        if(party is null)
            return BadRequest("Party could not be found.");

        party.Name = request.Party.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(true);
    }
}