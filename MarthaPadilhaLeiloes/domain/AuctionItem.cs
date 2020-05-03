
namespace domain
{
    public class AuctionItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double PriceNegotiated { get; set; }
        
        public int AuctionId { get; set; }
        public Auction Auction { get; }

        public int ItemId { get; set; }
        public Item Item { get; }

        public int ComitenteId { get; set; }
        public Comitente Comitente { get; }


        public AuctionItem(){}

        public double SubTotal(){
            return Quantity * PriceNegotiated;
        }


    }
}