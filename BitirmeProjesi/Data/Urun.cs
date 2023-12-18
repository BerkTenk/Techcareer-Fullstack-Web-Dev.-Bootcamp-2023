using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Data
{
    public class Urun{
        [Key]
        public int UrunId {get; set;}
        public string? UrunAdi {get; set;}
        public string? Description { get; set; }
        public string? Image {get; set;}
        public decimal Price {get; set;}
        public int StockQuantity {get; set;}
        public bool IsActive { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedAt {get; set;}
        public int KategoriId {get; set;}
        public Kategori? Kategori {get; set;}
    }
}