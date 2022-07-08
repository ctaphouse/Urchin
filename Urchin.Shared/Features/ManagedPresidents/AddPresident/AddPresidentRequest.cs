using MediatR;
using Urchin.Shared.Features.Home.Shared;

namespace Urchin.Shared.Features.ManagedPresidents.AddPresident;

public record AddPresidentRequest(PresidentDto President) : IRequest<AddPresidentRequest.Response>
{
    public const string RouteTemplate = "/api/presidents";

    public record Response(int PresidentId);
}
