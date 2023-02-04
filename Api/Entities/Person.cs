namespace CVGeneratorApp.Api.Core.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int SectorId { get; set; }
        public string MobilePhone { get; set; } = null!;
        public string CVFileName { get; set; } = null!;
        public string CVFilePath { get; set; } = null!;
        public Sector Sector { get; set; } = null!;

        public DateTime Created { get; set; }

    }
}
