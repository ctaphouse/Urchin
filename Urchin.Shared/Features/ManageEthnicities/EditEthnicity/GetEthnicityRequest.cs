using MediatR;

namespace Urchin.Shared.Features.ManageEthnicities.EditEthnicity;

public record GetEthnicityRequest(int EthnicityId) : IRequest<GetEthnicityRequest.Response>
{
    public const string RouteTemplate = "/api/ethnicities/{ethnicityId}";
    public record Ethnicity(int Id, string Name);
    public record Response(Ethnicity Ethnicity);
}