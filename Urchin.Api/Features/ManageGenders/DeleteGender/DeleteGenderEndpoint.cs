using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Urchin.Api.Persistence;
using Urchin.Shared.Features.ManageGenders.DeleteGender;

namespace Urchin.Api.Features.ManageGenders.DeleteGender;

public class DeleteGenderEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<bool>
{
    private readonly UrchinContext _context;

    public DeleteGenderEndpoint(UrchinContext context)
    {
        _context = context;
    }
    [HttpDelete(DeleteGenderRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(int genderId, CancellationToken cancellationToken = default)
    {
        var gender = await _context.Genders.SingleOrDefaultAsync(gender => gender.Id == genderId, cancellationToken);

        if(gender is null)
            return BadRequest("Gender could not be found.");

        _context.Remove(gender);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(true);
    }
}