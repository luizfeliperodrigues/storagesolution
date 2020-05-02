namespace domain
{
    public class Item
    {
        public int Id { get; set; }
        public int BusinessCode { get; set; }
        public string Description { get; set; }
        public double PriceReference { get; set; }
        public string Local { get; set; }
        public TipoItem TipoItem { get; set; }

        public Item(){}

        public Item(int id, int businessCode, string description, TipoItem tipoItem)
        {
            Id = id;
            BusinessCode = businessCode;
            Description = description;
            PriceReference = 0;
            Local = "";
            TipoItem = tipoItem;
        }

        public Item(int id, int businessCode, string description, TipoItem tipoItem, string local) : base(int id, int businessCode, string description, TipoItem tipoItem)
        {
            Local = local;
        }

        
    }
}