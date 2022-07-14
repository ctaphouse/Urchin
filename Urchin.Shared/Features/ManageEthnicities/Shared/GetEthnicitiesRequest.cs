using MediatR;

namespace Urchin.Shared.Features.ManageEthnicities.Shared;

public record GetEthnicitiesRequest : IRequest<GetEthnicitiesRequest.Response>
{
    public const string RouteTemplate = "/api/ethnicities";
    public record Ethncity(int Id, string Name);
    public record Response(IEnumerable<Ethncity> Ethncities);
}