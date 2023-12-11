using BootcampApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BootcampApp.Controllers;

    public class BootcampController : Controller{
        public IActionResult List()
        {
            var kurslar = new List<Bootcamp>(){
                new Bootcamp(){Id = 1, Title = "İlk Kurs", Image = "1.jpeg", Description = "İlk kursun açıklaması."},
                new Bootcamp(){Id = 2, Title = "İkinci Kurs", Image = "2.jpeg", Description = "İkincikursun açıklaması."},
                new Bootcamp(){Id = 3, Title = "Üçüncü Kurs", Image = "3.jpeg", Description = "Üçüncü kursun açıklaması."},
                new Bootcamp(){Id = 4, Title = "Dördüncü Kurs", Image = "4.jpeg", Description = "Dördüncü kursun açıklaması."},
            };
            return View(kurslar);
        }
    }
