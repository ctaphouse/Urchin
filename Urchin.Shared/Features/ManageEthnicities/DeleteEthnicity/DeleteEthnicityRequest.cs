using MediatR;

namespace Urchin.Shared.Features.ManageEthnicities.DeleteEthnicity;

public record DeleteEthnicityRequest(int EthnicityId) : IRequest<DeleteEthnicityRequest.Response>
{
    public const string RouteTemplate = "/api/ethnicities";
    public record Response(bool IsSuccessful);
}