using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Urchin.Api.Persistence;
using Urchin.Shared.Features.ManageEthnicities.EditEthnicity;

namespace Urchin.Api.Features.ManageEthnicities.EditEthnicity;

public class EditEthnicityEndpoint : EndpointBaseAsync.WithRequest<EditEthnicityRequest>.WithActionResult<bool>
{
    private readonly UrchinContext _context;

    public EditEthnicityEndpoint(UrchinContext context)
    {
        _context = context;
    }
    [HttpPut(EditEthnicityRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditEthnicityRequest request, CancellationToken cancellationToken = default)
    {
        var ethnicity = await _context.Ethnicities.SingleOrDefaultAsync(ethnicity => ethnicity.Id == request.Ethnicity.Id, cancellationToken);

        if(ethnicity is null)
            return BadRequest("Ethnicity could not be found.");

        ethnicity.Name = request.Ethnicity.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(true);
    }
}