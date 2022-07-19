using MediatR;
using Urchin.Shared.Features.ManageGenders.Shared;

namespace Urchin.Shared.Features.ManageGenders.AddGender;

public record AddGenderRequest(GenderDto Gender) : IRequest<AddGenderRequest.Response>
{
    public const string RouteTemplate = "/api/genders";
    public record Response(int GenderId);
}