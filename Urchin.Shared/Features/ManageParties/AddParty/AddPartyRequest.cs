using MediatR;
using Urchin.Shared.Features.ManageParties.Shared;

namespace Urchin.Shared.Features.ManageParties.AddParty;

public record AddPartyRequest(PartyDto Party) : IRequest<AddPartyRequest.Response>
{
    public const string RouteTemplate = "/api/parties";
    public record Response(int PartyId);
}