using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Urchin.Api.Persistence;
using Urchin.Shared.Features.ManagedPresidents.EditPresident;
using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;

namespace Urchin.Api.Features.ManagePresidents.EditPresident;

public class GetPresidentEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<GetPresidentRequest.Response>
{
    private readonly UrchinContext _context;

    public GetPresidentEndpoint(UrchinContext context)
    {
        _context = context;
    }

    [HttpGet(GetPresidentRequest.RouteTemplate)]
    public override async Task<ActionResult<GetPresidentRequest.Response>> HandleAsync(int presidentId, CancellationToken cancellationToken = default)
    {
        var president = await _context.Presidents.SingleOrDefaultAsync(president => president.Id == presidentId, cancellationToken);
    
        if(president is null)
            return BadRequest("President could not be found.");

        var response = new GetPresidentRequest.Response(new GetPresidentRequest.President(
            Id: president.Id, FirstName: president.FirstName, LastName: president.LastName, PartyId: president.PartyId
        ));

        return Ok(response);
    }
}