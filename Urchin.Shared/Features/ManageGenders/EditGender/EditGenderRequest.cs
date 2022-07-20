using MediatR;
using Urchin.Shared.Features.ManageGenders.Shared;

namespace Urchin.Shared.Features.ManageGenders.EditGender;

public record EditGenderRequest(GenderDto Gender) : IRequest<EditGenderRequest.Response>
{
    public const string RouteTemplate = "/api/genders";
    public record Response(bool IsSuccessful);
}