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
            var comitentes = await _context.Comitentes.ToArrayAsync();
            
            foreach (Comitente comitente in comitentes)
            {
                comitente.Items = await _context.Items
                    .Where(i => i.ComitenteId == comitente.Id)
                    .ToListAsync();
            }
            
            return comitentes;
        }

        public async Task<Comitente> GetComitenteByIdAsync(int id)
        {

            var comitente = await _context.Comitentes.FirstOrDefaultAsync(c => c.Id == id);

            comitente.Items = await _context.Items
                    .Where(i => i.ComitenteId == comitente.Id)
                    .ToListAsync();
            
            return comitente;
        }

        // TipoItem
        public async Task<TipoItem[]> GetAllTipoItemAsync()
        {
            var tipoItems = await _context.TipoItems.ToArrayAsync();
            
            foreach (TipoItem tipoItem in tipoItems)
            {
                tipoItem.Items = await _context.Items
                    .Where(i => i.TipoItemId == tipoItem.Id)
                    .ToListAsync();
            }
            
            return tipoItems;
        }
        
        public async Task<TipoItem> GetTipoItemByIdAsync(int id)
        {
            var tipoItem = await _context.TipoItems.FirstOrDefaultAsync(c => c.Id == id);

            tipoItem.Items = await _context.Items
                    .Where(i => i.TipoItemId == tipoItem.Id)
                    .ToListAsync();
            
            return tipoItem;
        }

        // Item
        public async Task<Item[]> GetAllItemAsync()
        {
            var items = await _context.Items.ToArrayAsync();

            foreach (Item item in items)
            {
                item.TipoItem = await _context.TipoItems
                    .FirstOrDefaultAsync(ti => ti.Id == item.TipoItemId);

                item.Comitente = await _context.Comitentes
                    .FirstOrDefaultAsync(ti => ti.Id == item.ComitenteId);
                
                item.AuctionItems = await _context.AuctionItems
                    .Where(ai => ai.ItemId == item.Id)
                    .ToListAsync();
                
                foreach (AuctionItem auctionItem in item.AuctionItems)
                {
                    auctionItem.Auction = await _context.Auctions
                        .FirstOrDefaultAsync(a => a.Id == auctionItem.AuctionId);
                }
            }
            
            return items;
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            var item = await _context.Items
                .FirstOrDefaultAsync(i => i.Id == id);
            
            item.TipoItem = await _context.TipoItems
                    .FirstOrDefaultAsync(ti => ti.Id == item.TipoItemId);

            item.Comitente = await _context.Comitentes
                .FirstOrDefaultAsync(ti => ti.Id == item.ComitenteId);

            item.AuctionItems = await _context.AuctionItems
                .Where(ai => ai.ItemId == item.Id)
                .ToListAsync();
            
            foreach (AuctionItem auctionItem in item.AuctionItems)
                {
                    auctionItem.Auction = await _context.Auctions
                        .FirstOrDefaultAsync(a => a.Id == auctionItem.AuctionId);
                }
            
            return item;
        }

        public async Task<Item[]> GetAllItemByLocalAsync(string local)
        {
            var itemsByLocal = await _context.Items
                .OrderBy(i => i.Local)
                .Where(i => i.Local.ToLower().Contains(local.ToLower()))
                .ToArrayAsync();
            
            foreach (Item item in itemsByLocal)
            {
                item.AuctionItems = await _context.AuctionItems
                    .Where(ai => ai.ItemId == item.Id)
                    .ToListAsync();
            }

            return itemsByLocal;
        }

        public async Task<Item[]> GetAllItemByTypeAsync(TipoItem type)
        {
            var itemsByType = await _context.Items
                .Where(i => i.TipoItemId == type.Id)
                .OrderBy(i => i.TipoItemId)
                .ToArrayAsync();
            
            foreach (Item item in itemsByType)
            {
                item.AuctionItems = await _context.AuctionItems
                    .Where(ai => ai.ItemId == item.Id)
                    .ToListAsync();
            }

            return itemsByType;
        }

        public async Task<Item> GetItemByBusinessCodeAsync(int businessCode)
        {
            var itemByBusinessCode = await _context.Items
                .Where(i => i.BusinessCode == businessCode)
                .FirstOrDefaultAsync();
            
            itemByBusinessCode.AuctionItems = await _context.AuctionItems
                .Where(ai => ai.ItemId == itemByBusinessCode.Id)
                .ToListAsync();


            return itemByBusinessCode;
        }

        // Auction
        public async Task<Auction[]> GetAllAuctionByAsync()
        {
            var auctions = await _context.Auctions.ToArrayAsync();
            
            foreach (Auction auction in auctions)
            {
                auction.AuctionItems = await _context.AuctionItems
                    .Where(ai => ai.AuctionId == auction.Id)
                    .ToListAsync();
                
                foreach (AuctionItem auctionItem in auction.AuctionItems)
                {
                    auctionItem.Item = await _context.Items
                        .FirstOrDefaultAsync(i => i.Id == auctionItem.ItemId);
                }
            }

            return auctions;
        }

        public async Task<Auction> GetAuctionByIdAsync(int id)
        {
            var auction = await _context.Auctions.FirstOrDefaultAsync(a => a.Id == id);

            auction.AuctionItems = await _context.AuctionItems
                    .Where(ai => ai.AuctionId == auction.Id)
                    .ToListAsync();
            
            foreach (AuctionItem auctionItem in auction.AuctionItems)
                {
                    auctionItem.Item = await _context.Items
                        .FirstOrDefaultAsync(i => i.Id == auctionItem.ItemId);
                }

            return auction;
        }

        public async Task<Auction> GetAuctionByBusinessCodeAsync(int businessCode)
        {
            var auction = await _context.Auctions.FirstOrDefaultAsync(a => a.BusinessCode == businessCode);

            auction.AuctionItems = await _context.AuctionItems
                    .Where(ai => ai.AuctionId == auction.Id)
                    .ToListAsync();
            
            foreach (AuctionItem auctionItem in auction.AuctionItems)
                {
                    auctionItem.Item = await _context.Items
                        .FirstOrDefaultAsync(i => i.Id == auctionItem.ItemId);
                }

            return auction;
        }

        public async Task<Auction[]> GetAllAuctionByDateAsync(DateTime initialDate, DateTime? finalDate)
        {
            var auctions = _context.Auctions
                .OrderByDescending(a => a.Date)
                .Where(a => a.Date >= initialDate);

            foreach (Auction auction in auctions)
            {
                auction.AuctionItems = await _context.AuctionItems
                    .Where(ai => ai.AuctionId == auction.Id)
                    .ToListAsync();
                
                foreach (AuctionItem auctionItem in auction.AuctionItems)
                {
                    auctionItem.Item = await _context.Items
                        .FirstOrDefaultAsync(i => i.Id == auctionItem.ItemId);
                }
            }
            
            if(finalDate.Value == null)
            {
                return await auctions.ToArrayAsync();
            }
            else
            {
                auctions = auctions.Where(a => a.Date <= finalDate);
                return await auctions.ToArrayAsync();
            }
        }

        public async Task<Auction[]> GetAllAuctionByNegotiationAsync(Negotiation negotiation)
        {
            var auctions = await _context.Auctions
                .Where(a => a.Negotiation == negotiation)
                .ToArrayAsync();
            
            foreach (Auction auction in auctions)
            {
                auction.AuctionItems = await _context.AuctionItems
                    .Where(ai => ai.AuctionId == auction.Id)
                    .ToListAsync();
                
                foreach (AuctionItem auctionItem in auction.AuctionItems)
                {
                    auctionItem.Item = await _context.Items
                        .FirstOrDefaultAsync(i => i.Id == auctionItem.ItemId);
                }
            }

            return auctions;
        }

        // AuctionItem
        public async Task<AuctionItem[]> GetAllAuctionItemAsync()
        {
            return await _context.AuctionItems.ToArrayAsync();
        }

        public async Task<AuctionItem> GetAuctionItemByIdAsync(int id)
        {
            var auctionItem = await _context.AuctionItems.FirstOrDefaultAsync(ai => ai.Id == id);
            
            auctionItem.Item = await _context.Items.FirstOrDefaultAsync(i => i.Id == auctionItem.ItemId);

            return auctionItem;
        }

        public async Task<AuctionItem[]> GetAllAuctionItemByAuctionAsync(int auctionId)
        {
            return await _context.AuctionItems
                .Where(ai => ai.AuctionId == auctionId)
                .ToArrayAsync();
        }
        public async Task<AuctionItem[]> GetAllAuctionItemByItemAsync(int itemId)
        {
            return await _context.AuctionItems
                .Where(ai => ai.ItemId == itemId)
                .ToArrayAsync();
        }
    }
}