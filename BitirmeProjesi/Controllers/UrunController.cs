using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BitirmeProjesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BitirmeProjesi.Controllers
{
    
    public class UrunController : Controller
    {
        private readonly DataContext _context;

        public UrunController(DataContext context)
        {
            _context = context;
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
        [Route("urun/{id}")]
        public IActionResult Details(int? id){
            var urun = _context.Urunler.FirstOrDefault(u => u.UrunId == id);

            if(id == null){
                return Redirect("Home/Index");
            }
            
            return View(urun);
        }

        
    }
}