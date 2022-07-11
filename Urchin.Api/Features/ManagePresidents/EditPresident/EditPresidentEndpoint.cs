using System.Security.Claims;
using System.Text;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Net.Http.Headers;
using Urchin.Api.Persistence;
using Urchin.Shared.Features.ManagedPresidents.EditPresident;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace Urchin.Api.Features.ManagePresidents.EditPresident;

public class EditPresidentEndpoint : EndpointBaseAsync.WithRequest<EditPresidentRequest>.WithActionResult<bool>
{
    private readonly UrchinContext _context;

    public EditPresidentEndpoint(UrchinContext context)
    {
        _context = context;
    }

    [HttpPut(EditPresidentRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditPresidentRequest request, CancellationToken cancellationToken = default)
    {
        var president = await _context.Presidents.FirstOrDefaultAsync(president => president.Id == request.President.Id, cancellationToken);

        if(president is null)
            return BadRequest("President could not be found.");

        president.FirstName = request.President.FirstName;
        president.LastName = request.President.LastName;
        president.PartyId = request.President.PartyId;

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(true);
    }
}
