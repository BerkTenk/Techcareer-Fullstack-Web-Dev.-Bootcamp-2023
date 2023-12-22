using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace BitirmeProjesi.Data
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }
        public string? UrunAdi { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedAt { get; set; }
        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; }
        public ICollection<Yorum> Yorumlar { get; set; } = new List<Yorum>();
        public ICollection<Puan> Puanlar { get; set; } = new List<Puan>();
    }

    public class Yorum
    {
        public int Id { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? YorumMetni { get; set; }

        public int UrunId { get; set; }
        public Urun Urun { get; set; }
    }

    public class Puan
    {
        public int Id { get; set; }
        public int PuanDegeri { get; set; }
        public string? KullaniciAdi { get; set; }
        public int UrunId { get; set; }
        public Urun Urun { get; set; }

    }

    public class SepetItem
    {
        public int UrunId { get; set; }
        public string? UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int Miktar { get; set; }
        public Urun Urun {get; set;}
        public List<Urun> Urunler {get; set;}
    }
}