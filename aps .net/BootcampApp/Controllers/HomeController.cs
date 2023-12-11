using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BootcampApp.Models;

namespace BootcampApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var kurs = new Bootcamp();
        kurs.Id = 1;
        kurs.Title = "İlk Kurs";
        kurs.Image = "1.jpeg";
        kurs.Description = "İlk kursun açıklaması.";
        return View(kurs);
    }

}