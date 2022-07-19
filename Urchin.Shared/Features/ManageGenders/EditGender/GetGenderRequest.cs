using MediatR;

namespace Urchin.Shared.Features.ManageGenders.EditGender;

public record GetGenderRequest(int GenderId) : IRequest<GetGenderRequest.Response>
{
    public const string RouteTemplate = "/api/genders/{genderId}";
    public record Gender(int Id, string Name);
    public record Response(Gender Gender);
}