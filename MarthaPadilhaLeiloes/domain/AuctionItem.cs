
namespace domain
{
    public class AuctionItem
    {
        public int Id { get; set; }
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public double PriceNegotiated { get; set; }

        public double SubTotal(){
            return Quantity * PriceNegotiated;
        }


    }
}