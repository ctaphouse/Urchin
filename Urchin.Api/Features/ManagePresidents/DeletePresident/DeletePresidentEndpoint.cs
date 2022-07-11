using Ardalis.ApiEndpoints;
using Microsoft.EntityFrameworkCore;
using Urchin.Api.Persistence;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Urchin.Shared.Features.ManagedPresidents.DeletePresident;

namespace Urchin.Api.Features.ManagePresidents.DeletePresident;

public class DeletePresidentEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<bool>
{
    private readonly UrchinContext _context;

    public DeletePresidentEndpoint(UrchinContext context)
    {
        _context = context;
    }

    [HttpDelete(DeletePresidentRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(int presidentId, CancellationToken cancellationToken = default)
    {
        var president = await _context.Presidents.FirstOrDefaultAsync(president => president.Id == presidentId, cancellationToken);

        if(president is null)
            return BadRequest("President could not be found.");

        _context.Presidents.Remove(president);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(true);
    }
}