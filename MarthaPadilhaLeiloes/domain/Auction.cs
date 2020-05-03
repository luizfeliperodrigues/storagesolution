using System;
using System.Collections.Generic;

namespace domain
{
    public class Auction
    {
        public int Id { get; set; }
        public int BusinessCode { get; set; }
        public Negotiation Negotiation { get; set; }
        public DateTime Date { get; set; }
        public List<AuctionItem> AuctionItems { get; } = new List<AuctionItem>(); // Tirado o set para nao dar erro no BD

        public Auction(){}

        public Auction(int id, int businessCode, Negotiation negotiation, DateTime date)
        {
            Id = id;
            BusinessCode = businessCode;
            Negotiation = negotiation;
            Date = date;
        }


    }
}