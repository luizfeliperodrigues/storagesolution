using System;
using System.Threading.Tasks;
using domain;

namespace repository
{
    public class Repository : IRepository
    {
        private readonly MarthaPadilhaLeiloesContext _context;

        public Repository(MarthaPadilhaLeiloesContext context)
        {
            _context = context;
        }

        // GERAL
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        // Comitente
        public Task<Comitente[]> GetAllComitenteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Comitente> GetComitenteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        // TipoItem
        public Task<TipoItem[]> GetAllTipoItemAsync()
        {
            throw new NotImplementedException();
        }
        
        public Task<TipoItem> GetTipoItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        // Item
        public Task<Item[]> GetAllItemAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Item[]> GetAllItemByLocalAsync(string local)
        {
            throw new NotImplementedException();
        }

        public Task<Item[]> GetAllItemByTypeAsync(TipoItem type)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemByBusinessCodeAsync(int businessCode)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        // Auction
        public Task<Auction[]> GetAllAuctionByAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Auction> GetAllAuctionByBusinessCodeAsync(int businessCode)
        {
            throw new NotImplementedException();
        }

        public Task<Auction[]> GetAllAuctionByDateAsync(DateTime initialDate, DateTime finalDate)
        {
            throw new NotImplementedException();
        }

        // AuctionItem
        public Task<AuctionItem[]> GetAllAuctionItemAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuctionItem[]> GetAllAuctionItemByAuctionAsync(int auctionId)
        {
            throw new NotImplementedException();
        }

        public Task<AuctionItem[]> GetAllAuctionItemByComitenteAsync(int comitenteId)
        {
            throw new NotImplementedException();
        }

        public Task<AuctionItem> GetAllAuctionItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        

        

        

        

        

        

        public Task<Auction> GetAuctionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Auction[]> GetAuctionByNegotiationAsync(Negotiation negotiation)
        {
            throw new NotImplementedException();
        }

        
        public Task<AuctionItem[]> GetAllAuctionItemByItemAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        

        

        
    }
}