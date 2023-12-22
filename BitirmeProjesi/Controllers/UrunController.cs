using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BitirmeProjesi.Data;
using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BitirmeProjesi.Controllers
{
    
    public class UrunController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<IdentityUser> _userManager; 

        public UrunController(DataContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;     
        }
        [Route("urun")]
       public IActionResult Index(string searchTerm)
        {
            var urun = _context.Urunler.ToList();
            if(!string.IsNullOrEmpty(searchTerm)){
                urun = urun.Where(u=>u.UrunAdi.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)||
                u.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View(urun);
        }
        
        [HttpPost]
        [Route("urun/UpdateFeatures")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateFeatures(int urunId, bool isHome, bool isActive)
        {
            var urun = _context.Urunler.Find(urunId);

            if (urun != null)
            {
                urun.IsHome = isHome;
                urun.IsActive = isActive;
                
                _context.SaveChanges();
            } 
            return RedirectToAction("Index");
        }

        [Route("urun/{id}")]
        public async Task<IActionResult> Details(int? id){
            
            if(id == null){
                return Redirect("Home/Index");
            }
            var urun = await _context.Urunler
            .Include(u=>u.Kategori)
            .Include(u=>u.Yorumlar)
            .Include(u=>u.Puanlar)
            .FirstOrDefaultAsync(u => u.UrunId == id);

            if (urun == null)
        {
            return NotFound();
        }
            
            var viewModel = new YorumUrunViewModel
    {
        UrunId = urun.UrunId,
        UrunAdi = urun.UrunAdi,
        Description = urun.Description,
        Image = urun.Image,
        Price = urun.Price,
        StockQuantity = urun.StockQuantity,
        IsActive = urun.IsActive,
        IsHome = urun.IsHome,
        CreatedAt = urun.CreatedAt,
        KategoriId = urun.KategoriId,
        Kategori = urun.Kategori,
        Yorumlar = urun.Yorumlar.ToList(),
        Puanlar = urun.Puanlar
        .Select(p => new PuanViewModel
        {
            PuanDegeri = p.PuanDegeri,
            KullaniciAdi = p.KullaniciAdi
        })
        .ToList()
       
    };

    return View(viewModel);
        }

        [HttpPost]
        [Route("urun/YorumYap")]
        [Authorize]
    public async Task<IActionResult> YorumYap(int urunId, string yorumMetni)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login"); 
        }

        var urun = await _context.Urunler.FindAsync(urunId);
        if (urun == null)
        {
            return NotFound(); 
        }

        var yorum = new Yorum
        {
            KullaniciAdi = user.UserName,
            YorumMetni = yorumMetni,
            UrunId = urunId
        };

        _context.Yorumlar.Add(yorum);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpPost]
    [Route("urun/PuanVer")]
    [Authorize]
    public async Task<IActionResult> PuanVer(int urunId, int puanDegeri)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login"); 
        }

        var urun = await _context.Urunler.FindAsync(urunId);
        if (urun == null)
        {
            return NotFound(); 
        }

        
        var puan = new Puan
        {   KullaniciAdi = user.UserName,
            PuanDegeri = puanDegeri,
            UrunId = urunId
        };

        _context.Puanlar.Add(puan);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

        
    }
}