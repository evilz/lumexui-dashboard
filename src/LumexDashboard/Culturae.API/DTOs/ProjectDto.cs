namespace Culturae.API.DTOs;

public record ProjectDto(
    Guid Id,
    string Name,
    string Description,
    decimal AmountNeeded,
    DateTime PublicationDate
);
