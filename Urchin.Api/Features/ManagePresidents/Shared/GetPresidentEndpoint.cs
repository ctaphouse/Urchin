using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using Urchin.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Urchin.Api.Features.ManagePresidents.Shared;

public class GetPresidentsEndpoint : EndpointBaseAsync.WithoutRequest.WithActionResult<GetPresidentsRequest.Response>
{
    private readonly UrchinContext _context;

    public GetPresidentsEndpoint(UrchinContext context)
    {
        _context = context;
    }

    [HttpGet(GetPresidentsRequest.RouteTemplate)]
    public override async Task<ActionResult<GetPresidentsRequest.Response>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var presidents = await _context.Presidents.ToListAsync(cancellationToken);

        var response = new GetPresidentsRequest.Response(presidents.Select(p => new GetPresidentsRequest.President(
            p.Id, p.FirstName, p.LastName, p.PartyId)
        ));

        return Ok(response);
    }
}
