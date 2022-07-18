using MediatR;

namespace Urchin.Shared.Features.ManageGenders.Shared;

public record GetGendersRequest() : IRequest<GetGendersRequest.Response>
{
    public const string RouteTemplate = "/api/genders";
    public record Gender(int Id, string Name);
    public record Response(IEnumerable<Gender> Genders);
}