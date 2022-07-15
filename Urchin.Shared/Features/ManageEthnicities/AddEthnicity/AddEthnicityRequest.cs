using MediatR;
using Urchin.Shared.Features.ManageEthnicities.Shared;

namespace Urchin.Shared.Features.ManageEthnicities.AddEthnicity;

public record AddEthnicityRequest(EthnicityDto Ethnicity) : IRequest<AddEthnicityRequest.Response>
{
    public const string RouteTemplate = "/api/ethnicities";
    public record Response(int EthnicityId);
}