namespace CVGeneratorApp.Api.Common.Dtos.PersonDtos
{
    public record PersonsGetFilteredDto
    {
        public int? SectorId { get; init; }
        public string? Search { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 3;
    }
}
