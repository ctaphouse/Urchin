using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Urchin.Api.Persistence;
using Urchin.Shared.Features.ManageGenders.EditGender;

namespace Urchin.Api.Features.ManageGenders.EditGender;

public class GetGenderEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<GetGenderRequest.Response>
{
    private readonly UrchinContext _context;

    public GetGenderEndpoint(UrchinContext context)
    {
        _context = context;
    }
    [HttpGet(GetGenderRequest.RouteTemplate)]
    public override async Task<ActionResult<GetGenderRequest.Response>> HandleAsync(int genderId, CancellationToken cancellationToken = default)
    {
        var gender = await _context.Genders.SingleOrDefaultAsync(gender => gender.Id == genderId, cancellationToken);
    
        if(gender is null)
            return BadRequest("Gender could not be found.");

        return Ok(gender);
    }
}