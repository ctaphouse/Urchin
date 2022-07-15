using MediatR;
using Urchin.Shared.Features.ManageEthnicities.Shared;

namespace Urchin.Shared.Features.ManageEthnicities.EditEthnicity;

public record EditEthnicityRequest(EthnicityDto Ethnicity) : IRequest<EditEthnicityRequest.Response>
{
    public const string RouteTemplate = "/api/ethnicities";
    public record Response(bool IsSuccessful);
}