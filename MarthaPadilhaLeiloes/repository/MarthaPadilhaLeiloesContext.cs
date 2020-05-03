using Microsoft.EntityFrameworkCore;
using domain;

namespace repository
{
    public class MarthaPadilhaLeiloesContext : DbContext
    {
        public MarthaPadilhaLeiloesContext(DbContextOptions<MarthaPadilhaLeiloesContext> options) : base(options){}
        
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionItem> AuctionItems { get; set; }
        public DbSet<Comitente> Comitentes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<TipoItem> TipoItems { get; set; }

        // Para especificar uma relação n:n
        // protected override void OnModelCreating(ModelBuilder modelBuilder){
        //     modelBuilder.Entity<AuctionItem>()
        //         .HasKey(PE => new { PE.Auction, PE.Item });
        // }
    }
}