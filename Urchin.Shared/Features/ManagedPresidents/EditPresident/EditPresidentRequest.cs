using MediatR;
using Urchin.Shared.Features.Home.Shared;

namespace Urchin.Shared.Features.ManagedPresidents.EditPresident;

public record EditPresidentRequest(PresidentDto President) : IRequest<EditPresidentRequest.Response>
{
    public const string RouteTemplate = "/api/presidents";

    public record Response(bool IsSuccessful);
}
