
using System.Runtime.InteropServices.Marshalling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sube2.HelloMvc.Models;
using Sube2.HelloMvc.Models.ViewModels;

namespace Sube2.HelloMvc.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly OgrenciDbContext _context;
        public OgrenciController(OgrenciDbContext context)
        {
            _context = context;
        }

        public ViewResult Index() 
        {
            dynamic ogr = new Ogrenci();
            ogr.Ad = "Ali";
            return View("Anasayfa"); 
        }

        public ViewResult OgrenciListe()
        {
            var lst = _context.Ogrenciler.ToList(); 
            return View(lst);
        }
     
        [HttpGet]
        public ViewResult OgrenciEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OgrenciEkle(Ogrenci ogr)
        {
            bool sonuc = false;

            if (ogr != null)
            {
                try
                {
                    _context.Ogrenciler.Add(ogr);
                    _context.SaveChanges();
                    sonuc = true;  
                }
                catch (Exception)
                {
                    sonuc = false;  
                }
            }
            return Json(new { success = sonuc });
        }

        public IActionResult OgrenciDetay(int id)
        {
            var lst =_context.Ogrenciler.Find(id);
            return View(lst);
        }
        [HttpPost]
        public IActionResult OgrenciDetay([FromBody] Ogrenci ogr)
        {
            if (ogr != null)
            {
                _context.Entry(ogr).State = EntityState.Modified;
                _context.SaveChanges();
                return Json(new
                {
                    success = true,
                    redirectUrl = Url.Action("OgrenciListe", "Ogrenci")
                });
            }

            return BadRequest("Geçersiz veri");
        }


        [HttpPost]
        public IActionResult OgrenciSil(int id)
        {
            var ogrenci = _context.Ogrenciler.Find(id);
            if (ogrenci != null)
            {
                _context.Ogrenciler.Remove(ogrenci);
                _context.SaveChanges();
            }
            return Json(new { success = true });
        }

    }
}
