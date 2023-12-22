using BitirmeProjesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


public class SepetController : Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly DataContext _context;

    public SepetController(IHttpContextAccessor httpContextAccessor, DataContext context)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = context;
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
    var urun = _context.Urunler.Find(urunId);

     if (urun == null)
    {
        return NotFound();
    }
    var toplamMiktarSepette = SepetMiktariniHesapla(urunId, sepet);

    
    if (toplamMiktarSepette >= urun.StockQuantity)
    {
        
        ModelState.AddModelError("Stok", "Stok miktarını aşıyorsunuz.");
        return RedirectToAction("Index", "Sepet");
    }

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
private int SepetMiktariniHesapla(int urunId, List<SepetItem> sepet)
{
    
    int toplamMiktar = sepet.Where(item => item.UrunId == urunId).Sum(item => item.Miktar);

    return toplamMiktar;
}
[HttpPost]
    public IActionResult SepetiGuncelle(int urunId, int miktar)
    {
        var sepet = HttpContext.Session.GetObject<List<SepetItem>>("Sepet") ?? new List<SepetItem>();

        var existingItem = sepet.FirstOrDefault(item => item.UrunId == urunId);
        if (existingItem != null)
        {

            var urun = _context.Urunler.FirstOrDefault(u => u.UrunId == urunId);
        if (urun == null)
        {
            return NotFound();
        }

        
        if (miktar > urun.StockQuantity)
        {
            
            ModelState.AddModelError("Sepet", "Stok miktarını aşıyorsunuz.");
            
            
            return RedirectToAction("Index");
        }

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