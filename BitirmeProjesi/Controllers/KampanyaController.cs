using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BitirmeProjesi.Controllers
{
    [Route("[controller]")]
    public class KampanyaController : Controller
    {
        private readonly ILogger<KampanyaController> _logger;

        public KampanyaController(ILogger<KampanyaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}