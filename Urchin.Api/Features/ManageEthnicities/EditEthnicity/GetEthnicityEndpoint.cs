using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Urchin.Api.Persistence;
using Urchin.Shared.Features.ManageEthnicities.EditEthnicity;

namespace Urchin.Api.Features.ManageEthnicities.EditEthnicity;

public class GetEthnicityEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<GetEthnicityRequest.Response>
{
    private readonly UrchinContext _context;

    public GetEthnicityEndpoint(UrchinContext context)
    {
        _context = context;
    }
    [HttpGet(GetEthnicityRequest.RouteTemplate)]
    public override async Task<ActionResult<GetEthnicityRequest.Response>> HandleAsync(int ethnicityId, CancellationToken cancellationToken = default)
    {
        var ethnicity = await _context.Ethnicities.SingleOrDefaultAsync(e => e.Id == ethnicityId, cancellationToken);

        if(ethnicity is null)
            return BadRequest("Ethnicity could not be found.");

        var response = new GetEthnicityRequest.Response(new GetEthnicityRequest.Ethnicity(Id: ethnicity.Id, Name: ethnicity.Name));

        return Ok(response);
    }
}