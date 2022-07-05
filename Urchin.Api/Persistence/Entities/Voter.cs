namespace Urchin.Api.Persistence.Entities;

public class Voter
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public IEnumerable<President> Presidents { get; set; } = new List<President>();
}