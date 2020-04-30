namespace MarthaPadilhaLeiloes.Model
{
    public class Comitente
    {
        public int ComitenteId { get; set; }
        public string ComitenteName { get; set; }
        

        public Comitente(){}

        public Comitente(int comitenteId, string comitenteName)
        {
            ComitenteId = comitenteId;
            ComitenteName = comitenteName;
        }
    }
}