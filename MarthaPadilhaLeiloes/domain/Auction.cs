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
        public List<AuctionItem> AuctionItems { get; set; } = new List<AuctionItem>();

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