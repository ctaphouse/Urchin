using MediatR;

public record GetPresidentsRequest() : IRequest<GetPresidentsRequest.Response>
{
    public const string RouteTemplate = "/api/presidents";

    public record President(int Id, string FirstName, string LastName, int PartyId);

    public record Response(IEnumerable<President> Presidents);
} 
