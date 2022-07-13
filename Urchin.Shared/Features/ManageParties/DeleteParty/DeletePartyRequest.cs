using MediatR;

namespace Urchin.Shared.Features.ManageParties.DeleteParty;

public record DeletePartyRequest(int PartyId) : IRequest<DeletePartyRequest.Response>
{
    public const string RouteTemplate = "/api/parties";
    public record Response(bool IsSuccessful);
}