using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Urchin.Api.Persistence;
using Urchin.Shared.Features.ManageGenders.Shared;

namespace Urchin.Api.Features.ManageGenders.Shared;

public class GetGendersEndpoint : EndpointBaseAsync.WithoutRequest.WithActionResult<GetGendersRequest.Response>
{
    private readonly UrchinContext _context;

    public GetGendersEndpoint(UrchinContext context)
    {
        _context = context;
    }
    [HttpGet(GetGendersRequest.RouteTemplate)]
    public override async Task<Microsoft.AspNetCore.Mvc.ActionResult<GetGendersRequest.Response>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var genders = await _context.Genders.ToListAsync(cancellationToken);

        var response = new GetGendersRequest.Response(genders.Select(gender => new GetGendersRequest.Gender(Id:gender.Id, Name: gender.Name)));

        return Ok(response);
    }
}