using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Urchin.Api.Persistence;
using Urchin.Shared.Features.ManageEthnicities.DeleteEthnicity;

namespace Urchin.Api.Features.ManageEthnicities.DeleteEthnicity;

public class DeleteEthnicityEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<bool>
{
    private readonly UrchinContext _context;

    public DeleteEthnicityEndpoint(UrchinContext context)
    {
        _context = context;
    }
    [HttpDelete(DeleteEthnicityRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(int ethnicityId, CancellationToken cancellationToken = default)
    {
        var ethnicity = await _context.Ethnicities.SingleOrDefaultAsync(ethnicity => ethnicity.Id == ethnicityId, cancellationToken);
    
        if(ethnicity is null)
            return BadRequest("Ethnicity could not be found.");

        _context.Remove(ethnicity);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(true);
    }
}