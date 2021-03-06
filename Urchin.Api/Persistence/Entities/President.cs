namespace Urchin.Api.Persistence.Entities;

public class President
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int PartyId { get; set; }
    public Party Party { get; set; } = default!;
    public int EthnicityId { get; set; } = default!;
    public Ethnicity Ethnicity { get; set; } = default!;
    public int GenderId { get; set; }
    public Gender Gender { get; set; } = default!;
     public IEnumerable<Voter> Voters { get; set; } = new List<Voter>();
}