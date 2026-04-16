namespace Culturae.API.Entities;

public class Project
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal AmountNeeded { get; set; }
    public DateTime PublicationDate { get; set; }
}
