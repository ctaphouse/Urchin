using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Urchin.Api.Persistence;
using Urchin.Shared.Features.ManageGenders.EditGender;

public class EditGenderEndpoint : EndpointBaseAsync.WithRequest<EditGenderRequest>.WithActionResult<bool>
{
    private readonly UrchinContext _context;

    public EditGenderEndpoint(UrchinContext context)
    {
        _context = context;
    }
    [HttpPut(EditGenderRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditGenderRequest request, CancellationToken cancellationToken = default)
    {
        var gender = await _context.Genders.SingleOrDefaultAsync(gender => gender.Id == request.Gender.Id,cancellationToken);

        if(gender is null)
            return BadRequest("Gender could not be found.");

        gender.Name = request.Gender.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(true);
    }
}