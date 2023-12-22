// using BitirmeProjesi.Data;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace BitirmeProjesi.Controllers
// {
//     public class SiparisController : Controller
//     {
//     private readonly DataContext _sepetService; 

//     public SiparisController(DataContext sepetService)
//     {
//         _sepetService = sepetService;
//     }

//     [HttpGet]
//     public IActionResult Create()
//     {
//         var siparisModel = new Siparis
//     {
//         Sepet = ,
//         ToplamFiyat = /* Toplam fiyatı al */,
//     };
//     }

//     [HttpPost]
//     public IActionResult Create([FromBody] Siparis siparis)
//     {
        
//         return View("Tesekkur");
//     }
//     // private List<Urun> GetUrunler(){
//     //     var sepetService = new SepetItem();
//     //     var Urunler = sepetService.GetSepetModel()?.Urunler;
//     //     return Urunler ?? new List<Urun>;
//     // }
//     }
// }