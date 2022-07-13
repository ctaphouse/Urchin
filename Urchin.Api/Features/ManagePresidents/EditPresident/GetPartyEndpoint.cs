using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using Urchin.Api.Persistence;
using Urchin.Shared.Features.ManageParties.EditParty;

public class GetPartyEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<GetPartyRequest.Response>
{
    private readonly UrchinContext _context;

    public GetPartyEndpoint(UrchinContext context)
    {
        _context = context;
    }
    [HttpGet(GetPartyRequest.RouteTemplate)]
    public override async Task<ActionResult<GetPartyRequest.Response>> HandleAsync(int partyId, CancellationToken cancellationToken = default)
    {
        var party = await _context.Parties.SingleOrDefaultAsync(party => party.Id == partyId, cancellationToken);

        if(party is null)
            return BadRequest("Party could not be found.");

        return new GetPartyRequest.Response(new GetPartyRequest.Party(Id: party.Id, Name: party.Name));
    }
}