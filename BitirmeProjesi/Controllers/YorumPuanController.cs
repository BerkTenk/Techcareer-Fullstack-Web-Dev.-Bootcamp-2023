// using BitirmeProjesi.Data;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;

// namespace BitirmeProjesi.Controllers
// {
//     public class YorumPuanController : Controller
//     {
//          private readonly DataContext _context;
//     private readonly UserManager<IdentityUser> _userManager; 

//     public YorumPuanController(DataContext context, UserManager<IdentityUser> userManager)
//     {
//         _context = context;
//         _userManager = userManager; 
//     }
//      [HttpPost]
//     public async Task<IActionResult> YorumYap(int urunId, string yorumMetni)
//     {
//         var user = await _userManager.GetUserAsync(User);
//         if (user == null)
//         {
//             return RedirectToAction("Login"); 
//         }

//         var urun = await _context.Urunler.FindAsync(urunId);
//         if (urun == null)
//         {
//             return NotFound(); 
//         }

//         var yorum = new Yorum
//         {
//             KullaniciAdi = user.UserName,
//             YorumMetni = yorumMetni,
//             UrunId = urunId
//         };

//         _context.Yorumlar.Add(yorum);
//         await _context.SaveChangesAsync();

//         return RedirectToAction("UrunDetay", new { id = urunId });
//     }

//     [HttpPost]
//     public async Task<IActionResult> PuanVer(int urunId, int puanDegeri)
//     {
//         var user = await _userManager.GetUserAsync(User);
//         if (user == null)
//         {
//             return RedirectToAction("Login"); 
//         }

//         var urun = await _context.Urunler.FindAsync(urunId);
//         if (urun == null)
//         {
//             return NotFound(); 
//         }

//         var puan = new Puan
//         {
//             PuanDegeri = puanDegeri,
//             UrunId = urunId
//         };

//         _context.Puanlar.Add(puan);
//         await _context.SaveChangesAsync();

//         return RedirectToAction("UrunDetay", new { id = urunId });
//     }



//     }
// }