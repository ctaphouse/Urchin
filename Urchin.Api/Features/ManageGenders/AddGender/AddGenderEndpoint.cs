using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Urchin.Api.Persistence;
using Urchin.Api.Persistence.Entities;
using Urchin.Shared.Features.ManageGenders.AddGender;

namespace Urchin.Api.Features.ManageGenders.AddGender;

public class AddGenderEndpoint : EndpointBaseAsync.WithRequest<AddGenderRequest>.WithActionResult<int>
{
    private readonly UrchinContext _context;

    public AddGenderEndpoint(UrchinContext context)
    {
        _context = context;
    }
    [HttpPost(AddGenderRequest.RouteTemplate)]
    public override async Task<ActionResult<int>> HandleAsync(AddGenderRequest request, CancellationToken cancellationToken = default)
    {
        var gender = new Gender {Name = request.Gender.Name};

        await _context.Genders.AddAsync(gender, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(gender.Id);
    }
}