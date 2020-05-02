using System.Collection.Generic;

namespace domain
{
    public class AuctionItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double PriceNegotiated { get; set; }
        public Auction Auction { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Comitente> Comitentes { get; set; } = new List<Comitente>();


        public AuctionItem(){}

        public AuctionItem(int id, int quantity, double priceNegotiated, Auction auction)
        {
            Id = id;
            Quantity = quantity;
            PriceNegotiated = priceNegotiated;
            Auction = auction;
        }

        public double SubTotal(){
            return Quantity * PriceNegotiated;
        }


    }
}