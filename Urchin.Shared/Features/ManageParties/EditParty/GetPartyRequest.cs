using MediatR;

namespace Urchin.Shared.Features.ManageParties.EditParty;

public record GetPartyRequest(int PartyId) : IRequest<GetPartyRequest.Response>
{
    public const string RouteTemplate = "/api/parties/{partyId}";
    public record Party(int Id, string Name);
    public record Response(Party Party);
}