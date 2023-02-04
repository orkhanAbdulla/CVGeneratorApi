namespace CVGeneratorApp.Api.Common.Dtos.PersonDtos
{
    public class PersonPostDto
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string MobilePhone { get; set; } = null!;
        public int SectorId { get; set; }
        public IFormFile CVFile { get; set; } = null!;
    }

}
