namespace TestesComBanco.Models
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Agency()
        {
            Id = 0;
            Name = string.Empty;
        }

        public Agency(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id} | {Name}";
        }
    }
}
