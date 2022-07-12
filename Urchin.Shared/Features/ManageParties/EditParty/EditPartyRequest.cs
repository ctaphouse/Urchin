using MediatR;
using Urchin.Shared.Features.ManageParties.Shared;

namespace Urchin.Shared.Features.ManageParties.EditParty;

public record EditPartyRequest(PartyDto Party) : IRequest<EditPartyRequest.Response>
{
    public const string RouteTemplate = "/api/parties";
    public record Response(bool IsSuccessful);
}