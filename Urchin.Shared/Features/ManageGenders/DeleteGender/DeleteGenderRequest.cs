using MediatR;

namespace Urchin.Shared.Features.ManageGenders.DeleteGender;

public record DeleteGenderRequest(int GenderId) : IRequest<DeleteGenderRequest.Response>
{
    public const string RouteTemplate = "/api/genders";
    public record Response(bool IsSuccessful);
}