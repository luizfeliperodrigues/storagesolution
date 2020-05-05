using Microsoft.EntityFrameworkCore;
using domain;

namespace repository
{
    public class MarthaPadilhaLeiloesContext : DbContext
    {
        public MarthaPadilhaLeiloesContext(DbContextOptions<MarthaPadilhaLeiloesContext> options) : base(options){}
        
        public DbSet<Comitente> Comitentes { get; set; }
        public DbSet<TipoItem> TipoItems { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<AuctionItem> AuctionItems { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Para especificar uma relação n:n de Auction para Item
            modelBuilder.Entity<AuctionItem>()
                .HasKey(PE => new { PE.ItemId, PE.AuctionId });
            
            modelBuilder.Entity<AuctionItem>()
                .HasOne(ai => ai.Item)
                .WithMany(a => a.AuctionItems)
                .HasForeignKey(ai => ai.ItemId);
            
            modelBuilder.Entity<AuctionItem>()
                .HasOne(ai => ai.Auction)
                .WithMany(a => a.AuctionItems)
                .HasForeignKey(ai => ai.AuctionId);
            
            // Para especificar uma relação 1:n de TipoItem para Item
            modelBuilder.Entity<Item>()
                .HasOne(i => i.TipoItem)
                .WithMany(ti => ti.Items)
                .HasForeignKey(i => i.TipoItemId);

            // Para especificar uma relação 1:n de Comitente para Item
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Comitente)
                .WithMany(ti => ti.Items)
                .HasForeignKey(i => i.ComitenteId);
        }
    }
}