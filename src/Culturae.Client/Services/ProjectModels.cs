namespace Culturae.Client.Services;

public record ProjectDto(
    Guid Id,
    string Name,
    string Description,
    decimal AmountNeeded,
    DateTime PublicationDate
);

public record PagedResult<T>(
    List<T> Items,
    int TotalCount,
    int Page,
    int PageSize,
    int TotalPages,
    bool HasPrevious,
    bool HasNext
);
