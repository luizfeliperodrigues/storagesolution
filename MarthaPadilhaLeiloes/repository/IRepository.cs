using System;
using System.Threading.Tasks;
using domain;

namespace repository
{
    public interface IRepository
    {
        // GERAL
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveChangesAsync();

         // Comitente
         Task<Comitente[]> GetAllComitenteAsync();
         Task<Comitente> GetComitenteByIdAsync(int id);

         // TipoItem
         Task<TipoItem[]> GetAllTipoItemAsync();
         Task<TipoItem> GetTipoItemByIdAsync(int id);

         // Item
         Task<Item[]> GetAllItemAsync();
         Task<Item> GetItemByIdAsync(int id);
         Task<Item> GetItemByBusinessCodeAsync(int businessCode);
         Task<Item[]> GetAllItemByLocalAsync(string local);
         Task<Item[]> GetAllItemByTypeAsync(TipoItem type);

         // Auction
         Task<Auction[]> GetAllAuctionByAsync();
         Task<Auction> GetAuctionByIdAsync(int id);
         Task<Auction> GetAuctionByBusinessCodeAsync(int businessCode);
         Task<Auction[]> GetAllAuctionByNegotiationAsync(Negotiation negotiation);
         Task<Auction[]> GetAllAuctionByDateAsync(DateTime initialDate, DateTime? finalDate);

         // AuctionItem
         Task<AuctionItem[]> GetAllAuctionItemAsync();
         Task<AuctionItem> GetAuctionItemByIdAsync(int id);
         Task<AuctionItem[]> GetAllAuctionItemByAuctionAsync(int auctionId);
         Task<AuctionItem[]> GetAllAuctionItemByItemAsync(int itemId);
         
    }
}