using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Data
{
    public class Kategori{
        [Key]
        public int KategoriId {get; set;}
        public string? Baslik {get; set;}

    }
}