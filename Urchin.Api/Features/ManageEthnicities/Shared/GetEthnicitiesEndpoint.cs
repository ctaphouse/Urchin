using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Urchin.Api.Persistence;
using Urchin.Shared.Features.ManageEthnicities.Shared;

namespace Urchin.Api.Features.ManageEthnicities.Shared;

public class GetEthnicitiesEndpoint : EndpointBaseAsync.WithoutRequest.WithActionResult<GetEthnicitiesRequest.Response>
{
    private readonly UrchinContext _context;

    public GetEthnicitiesEndpoint(UrchinContext context)
    {
        _context = context;
    }
    [HttpGet(GetEthnicitiesRequest.RouteTemplate)]
    public override async Task<ActionResult<GetEthnicitiesRequest.Response>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var ethnicities = await _context.Ethnicities.ToListAsync(cancellationToken);

        var response = new GetEthnicitiesRequest.Response(ethnicities.Select(e => new GetEthnicitiesRequest.Ethncity(Id: e.Id, Name: e.Name)));

        return Ok(response);
    }
}