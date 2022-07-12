using MediatR;

namespace Urchin.Shared.Features.ManageParties.Shared;

public record GetPartiesRequest() : IRequest<GetPartiesRequest.Response>
{
    public const string RouteTemplate = "/api/parties";
    public record Party(int Id, string Name);
    public record Response(IEnumerable<Party> Party);
}