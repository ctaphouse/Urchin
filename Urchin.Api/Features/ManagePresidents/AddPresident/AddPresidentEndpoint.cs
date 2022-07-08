using Ardalis.ApiEndpoints;
using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using Urchin.Shared.Features.ManagedPresidents.AddPresident;
using Microsoft.AspNetCore.Mvc;
using Urchin.Api.Persistence;
using Urchin.Api.Persistence.Entities;

namespace Urchin.Api.Features.ManagePresidents.AddPresident;

public class AddPresidentEndpoint : EndpointBaseAsync.WithRequest<AddPresidentRequest>.WithActionResult<int>
{
    private readonly UrchinContext _context;

    public AddPresidentEndpoint(UrchinContext context)
    {
        _context = context;
    }

    [HttpPost(AddPresidentRequest.RouteTemplate)]
    public override async Task<ActionResult<int>> HandleAsync(AddPresidentRequest request, CancellationToken cancellationToken = default)
    {
        var president = new President();

        president.FirstName = request.President.FirstName;
        president.LastName = request.President.LastName;
        president.PartyId = request.President.PartyId;

        await _context.AddAsync(president, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(president.Id);
    }
}
