using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Urchin.Api.Persistence;
using Urchin.Api.Persistence.Entities;
using Urchin.Shared.Features.ManageEthnicities.AddEthnicity;

namespace Urchin.Api.Features.ManageEthnicities.AddEthnicity;

public class AddEthnicityEndpoint : EndpointBaseAsync.WithRequest<AddEthnicityRequest>.WithActionResult<int>
{
    private readonly UrchinContext _context;

    public AddEthnicityEndpoint(UrchinContext context)
    {
        _context = context;
    }
    [HttpPost(AddEthnicityRequest.RouteTemplate)]
    public override async Task<ActionResult<int>> HandleAsync(AddEthnicityRequest request, CancellationToken cancellationToken = default)
    {
        var ethnicity = new Ethnicity{Name = request.Ethnicity.Name};

        await _context.AddAsync(ethnicity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(ethnicity.Id);
    }
}