namespace domain
{
    public class Comitente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        

        public Comitente(){}

        public Comitente(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}