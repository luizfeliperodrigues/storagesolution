namespace MarthaPadilhaLeiloes.Model
{
    public class TipoItem
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public TipoItem() { }

        public TipoItem(int typeId, string typeName)
        {
            TypeId = typeId;
            TypeName = typeName;
        }

        public override string ToString(){
            return "Id do tipo: " + TypeId
                    + "\nNome Tipo: " + TypeName;
        }
    }
}