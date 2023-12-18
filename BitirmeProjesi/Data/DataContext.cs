using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){
            
        }
        public DbSet<Urun> Urunler => Set<Urun>();
        public DbSet<Kampanya> Kampanyalar => Set<Kampanya>();
        public DbSet<Kategori> Kategoriler => Set<Kategori>();

    }
}