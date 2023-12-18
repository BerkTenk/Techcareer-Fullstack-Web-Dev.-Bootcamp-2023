using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Data
{
    public class Kampanya{
        [Key]
        public int KampanyaId {get; set;}
        public string? KampanyaAdi {get; set;}
        public string? Description {get; set;}
        public decimal? DiscountPercentage { get; set; }
        public bool IsActive { get; set; }
    }
}