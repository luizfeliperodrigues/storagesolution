using MarthaPadilhaLeiloes.Model;
using Microsoft.EntityFrameworkCore;

namespace MarthaPadilhaLeiloes.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        
        public DbSet<Comitente> Comitentes { get; set; }
    }
}