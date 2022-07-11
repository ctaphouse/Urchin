using MediatR;

namespace Urchin.Shared.Features.ManagedPresidents.DeletePresident;

public record DeletePresidentRequest(int PresidentId) : IRequest<DeletePresidentRequest.Response>
{
    public const string RouteTemplate = "/api/presidents";

    public record Response(bool IsSuccessful);
}