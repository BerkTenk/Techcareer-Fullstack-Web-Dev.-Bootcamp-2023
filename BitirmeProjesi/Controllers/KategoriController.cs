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
    
    public class KategoriController : Controller
    {
        private readonly DataContext _context;

        public KategoriController(DataContext context)
        {
            _context = context;
        }
        
        
        public IActionResult Details(int? id){
            var kategori = _context.Urunler.Where(u => u.KategoriId == id).ToList();

            if(id == null){
                return NotFound();
            }
            
            return View(kategori);
        }

        
    }
}