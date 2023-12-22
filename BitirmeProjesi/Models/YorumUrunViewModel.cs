using BitirmeProjesi.Data;

namespace BitirmeProjesi.Models
{
    public class YorumUrunViewModel
    {
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
        public List<Yorum> Yorumlar { get; set; } = new List<Yorum>();
    
        public int Id { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? YorumMetni { get; set; }
        public int PuanDegeri { get; set; }
        public List<PuanViewModel> Puanlar { get; set; } = new List<PuanViewModel>();
    }
    public class PuanViewModel
    {
        public int PuanDegeri { get; set; }
        public string KullaniciAdi { get; set; }
    }
}