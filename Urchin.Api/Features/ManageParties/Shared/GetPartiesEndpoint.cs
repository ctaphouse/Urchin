using Ardalis.ApiEndpoints;
using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using Urchin.Shared.Features.ManageParties.Shared;
using Urchin.Api.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authentication;
using System.Text;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;

namespace Urchin.Api.Features.ManageParties.Shared;

public class GetPartyEndpoint : EndpointBaseAsync.WithoutRequest.WithActionResult<GetPartiesRequest.Response>
{
    private readonly UrchinContext _context;

    public GetPartyEndpoint(UrchinContext context)
    {
        _context = context;
    }

    [HttpGet(GetPartiesRequest.RouteTemplate)]
    public override async Task<ActionResult<GetPartiesRequest.Response>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var parties = await _context.Parties.ToListAsync();

        var response = new GetPartiesRequest.Response(parties.Select(party => new GetPartiesRequest.Party(
            Id: party.Id, Name: party.Name
        )));

        return Ok(response);
    }
}