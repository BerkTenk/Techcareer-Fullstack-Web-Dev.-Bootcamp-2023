using System.IO.Compression;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Data
{
    public class DataContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){
            
        }
        public DbSet<Urun> Urunler => Set<Urun>();
        public DbSet<Kampanya> Kampanyalar => Set<Kampanya>();
        public DbSet<Kategori> Kategoriler => Set<Kategori>();
        // public DbSet<Siparis> Siparisler => Set<Siparis>();
        public DbSet<Yorum> Yorumlar => Set<Yorum>();
        public DbSet<Puan> Puanlar => Set<Puan>();

    }
}