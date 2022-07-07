namespace Urchin.Shared.Features.Home.Shared;

public class PresidentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int PartyId { get; set; }
}