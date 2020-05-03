using System;
using System.Linq;
using System.Threading.Tasks;
using domain;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class Repository : IRepository
    {
        private readonly MarthaPadilhaLeiloesContext _context;

        public Repository(MarthaPadilhaLeiloesContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
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
        public async Task<Comitente[]> GetAllComitenteAsync()
        {
            return await _context.Comitentes.ToArrayAsync();
        }

        public async Task<Comitente> GetComitenteByIdAsync(int id)
        {
            return await _context.Comitentes.FirstOrDefaultAsync(c => c.Id == id);
        }

        // TipoItem
        public async Task<TipoItem[]> GetAllTipoItemAsync()
        {
            return await _context.TipoItems.ToArrayAsync();
        }
        
        public async Task<TipoItem> GetTipoItemByIdAsync(int id)
        {
            return await _context.TipoItems.FirstOrDefaultAsync(t => t.Id == id);
        }

        // Item
        public async Task<Item[]> GetAllItemAsync()
        {
            return await _context.Items.ToArrayAsync();
        }

        public async Task<Item[]> GetAllItemByLocalAsync(string local)
        {
            return await _context.Items
                .OrderBy(i => i.Local)
                .Where(i => i.Local.ToLower().Contains(local.ToLower()))
                .ToArrayAsync();
        }

        public async Task<Item[]> GetAllItemByTypeAsync(TipoItem type)
        {
            return await _context.Items
                .Where(i => i.TipoItemId == type.Id)
                .OrderBy(i => i.TipoItemId)
                .ToArrayAsync();
        }

        public async Task<Item> GetItemByBusinessCodeAsync(int businessCode)
        {
            return await _context.Items
                .Where(i => i.BusinessCode == businessCode)
                .OrderBy(i => i.BusinessCode)
                .FirstOrDefaultAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _context.Items
                .FirstOrDefaultAsync(i => i.Id == id);
        }
        // Auction
        public async Task<Auction[]> GetAllAuctionByAsync()
        {
            return await _context.Auctions.ToArrayAsync();
        }

        public async Task<Auction> GetAuctionByBusinessCodeAsync(int businessCode)
        {
            return await _context.Auctions.FirstOrDefaultAsync(a => a.BusinessCode == businessCode);
        }

        public async Task<Auction[]> GetAllAuctionByDateAsync(DateTime initialDate, DateTime? finalDate)
        {
            IQueryable<Auction> query = _context.Auctions
                .OrderByDescending(a => a.Date)
                .Where(a => a.Date >= initialDate);
            
            if(finalDate.Value == null)
            {
                return await query.ToArrayAsync();
            }
            else
            {
                query = query.Where(a => a.Date <= finalDate);
                return await query.ToArrayAsync();
            }
        }

        public async Task<Auction> GetAuctionByIdAsync(int id)
        {
            return await _context.Auctions.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Auction[]> GetAllAuctionByNegotiationAsync(Negotiation negotiation)
        {
            return await _context.Auctions
                .Where(a => a.Negotiation == negotiation)
                .ToArrayAsync();
        }

        // AuctionItem
        public async Task<AuctionItem[]> GetAllAuctionItemAsync()
        {
            return await _context.AuctionItems.ToArrayAsync();
        }

        public async Task<AuctionItem[]> GetAllAuctionItemByAuctionAsync(int auctionId)
        {
            return await _context.AuctionItems
                .Where(ai => ai.Id == auctionId)
                .ToArrayAsync();
        }

        public async Task<AuctionItem[]> GetAllAuctionItemByComitenteAsync(int comitenteId)
        {
            return await _context.AuctionItems
                .Where(ai => ai.ComitenteId == comitenteId)
                .ToArrayAsync();
        }

        public async Task<AuctionItem> GetAuctionItemByIdAsync(int id)
        {
            return await _context.AuctionItems.FirstOrDefaultAsync(ai => ai.Id == id);
        }
        
        public async Task<AuctionItem[]> GetAllAuctionItemByItemAsync(int itemId)
        {
            return await _context.AuctionItems
                .Where(ai => ai.ItemId == itemId)
                .ToArrayAsync();
        }
    }
}