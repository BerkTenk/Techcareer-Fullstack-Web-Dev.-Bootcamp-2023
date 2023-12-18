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
    [Route("[controller]")]
    public class KampanyaController : Controller
    {
        private readonly DataContext _context;

        public KampanyaController(DataContext context)
        {
            _context = context;
        }

       public async Task<IActionResult> Index()
        {
            return View(await _context.Kampanyalar.ToListAsync());
        }

        
    }
}