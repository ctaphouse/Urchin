using MediatR;

namespace Urchin.Shared.Features.ManagedPresidents.EditPresident;

public record GetPresidentRequest(int PresidentId) : IRequest<GetPresidentsRequest.Response>
{
    public const string RouteTemplate = "/api/presidents/{presidentId}";

    public record President(int Id, string FirstName, string LastName, int PartyId);

    public record Response(President President);
}