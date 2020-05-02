namespace domain
{
    public class TipoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TipoItem() { }

        public TipoItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString(){
            return "Id do tipo: " + Id
                    + "\nNome Tipo: " + Name;
        }
    }
}