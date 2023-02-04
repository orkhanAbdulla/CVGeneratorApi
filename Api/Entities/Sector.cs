namespace CVGeneratorApp.Api.Core.Entities
{
    public class Sector
    {
        public Sector()
        {
            Persons = new HashSet<Person>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Person> Persons { get; set; } 
    }
}
