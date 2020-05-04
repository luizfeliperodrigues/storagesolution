using System.Collections.Generic;

namespace domain
{
    public class Comitente
    {
        public int Id { get; set; }
        public int BusinessCode { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }
        

        // public Comitente(){}

        // public Comitente(int id, string name)
        // {
        //     Id = id;
        //     Name = name;
        // }
    }
}