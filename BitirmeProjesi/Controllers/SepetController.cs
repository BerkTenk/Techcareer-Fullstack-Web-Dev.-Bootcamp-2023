using BitirmeProjesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


public class SepetController : Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SepetController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public IActionResult Index()
    {
         var sepet = HttpContext.Session.GetObject<List<SepetItem>>("Sepet") ?? new List<SepetItem>();

       
         decimal toplamFiyat = sepet.Sum(item => item.Fiyat * item.Miktar);

        ViewBag.ToplamFiyat = toplamFiyat;
        return View(sepet);
    }

    public IActionResult UrunEkle(int urunId, string urunAdi, decimal fiyat, int miktar)
    {
        var sepet = HttpContext.Session.GetString("Sepet");
        var sepetItems = JsonConvert.DeserializeObject<List<SepetItem>>(sepet) ?? new List<SepetItem>();

        // Eğer aynı ürün sepete ekleniyorsa, miktarı artır
        var existingItem = sepetItems.FirstOrDefault(item => item.UrunId == urunId);
        if (existingItem != null)
        {
            existingItem.Miktar += miktar;
        }
        else
        {

            var newItem = new SepetItem
            {
                UrunId = urunId,
                UrunAdi = urunAdi,
                Fiyat = fiyat,
                Miktar = miktar
            };
            sepetItems.Add(newItem);
        }

        HttpContext.Session.SetString("Sepet", JsonConvert.SerializeObject(sepetItems));

        return RedirectToAction("Index");
    }
     [HttpPost]
public IActionResult SepeteEkle(int urunId, string urunAdi, decimal fiyat)
{
    var sepet = HttpContext.Session.GetObject<List<SepetItem>>("Sepet") ?? new List<SepetItem>();

    var existingItem = sepet.FirstOrDefault(item => item.UrunId == urunId);
    if (existingItem != null)
    {
        existingItem.Miktar += 1;
    }
    else
    {
        var newItem = new SepetItem
        {
            UrunId = urunId,
            UrunAdi = urunAdi,
            Fiyat = fiyat,
            Miktar = 1
        };
        sepet.Add(newItem);
    }

    HttpContext.Session.SetObject("Sepet", sepet);

    return RedirectToAction("Index", "Sepet");
}
[HttpPost]
    public IActionResult SepetiGuncelle(int urunId, int miktar)
    {
        var sepet = HttpContext.Session.GetObject<List<SepetItem>>("Sepet") ?? new List<SepetItem>();

        var existingItem = sepet.FirstOrDefault(item => item.UrunId == urunId);
        if (existingItem != null)
        {
            if (miktar > 0)
            {
                existingItem.Miktar = miktar;
            }
            else
            {
                sepet.Remove(existingItem);
            }

            HttpContext.Session.SetObject("Sepet", sepet);
        }

        return RedirectToAction("Index");
    }
}