
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

        public ViewResult Index() //action
        {
            dynamic ogr = new Ogrenci();
            ogr.Ad = "Ali";
            //Program çalışırken tipi teslim edileceğinden. Hatalar çalışma sırasında tespit edilir. ViewBag de aynı bu şekil çalışır.
            return View("Anasayfa"); //Index methodunun html olarak düzenlenmesi için view döndürmesi gerek.
        }

        //public ViewResult OgrenciDetay(int id)
        //{

        //    Ogrenci ogr = _context.Ogrenciler.FirstOrDefault(o => o.Ogrenciid == id);

        //    ViewData["ogr"] = ogr.Ad;

        //    return View(ogr);
        //}


        public ViewResult OgrenciListe()
        {
            var lst = _context.Ogrenciler.ToList(); // Veritabanından öğrencileri çekiyoruz.
            return View(lst);
        }
     


        [HttpGet]
        public ViewResult OgrenciEkle()
        {
            //Db'ye ekleme işlemleri
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
                    // Öğrenciyi ekleyelim
                    _context.Ogrenciler.Add(ogr);
                    _context.SaveChanges();
                    sonuc = true;  // Eğer işlem başarılıysa
                }
                catch (Exception)
                {
                    sonuc = false;  // Bir hata oluşursa
                }
            }

            // AJAX isteği için JSON olarak döneceğiz
            return Json(new { success = sonuc });
        }


        //[HttpGet]: Yazsan da yazmasan da var
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
                // Başarılı olursa bir mesaj ve yönlendirme adresi gönderiyoruz
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
//ViewResult ve RedirectActionResult arasındaki kesişim IActionResulttur. Yani IActionResult hespini karşılar o yüzden tüm methotlara yazılabilir
//Controller'dan View'e veri taşıma
//1-ViewData: Key-Value Collection. Key'ler mutlaka tekil olmalıdır.Key'ler string, Value'lar object'dir. Type-safe değildir.!
//2-ViewBag: Arka planda ViewData dictionary'sini kullanır. Bu durumda daha önce ViewData'larda kullanılan key'ler kullanılamaz.
//ViewBag'ler dynamic yapılardır ve içindeki türler RunTime sırasında tespit edilir. 
//3-Model: Yukarıda veri tipi açık açık belirtildiği için daha güvenlidir ve daha çok tercih edilir..
//4-TempData**:

//NOt: Biz viewbag ile yaptığımızda RunTime sırasında tür kontrolü yapılır. Modelle taşınan verinin ise tipi en başta belirlenir. Bu yüzden model daha güvenlidir.

//Not: Generic olmayan collection'ların tip güvenliği olmaz.

//Not: İki classın ortak noktası diyince aklımıza base gelmeli. 

//<T> Generic yapılar. Tip güvenliği sağlar

//Araştır:
//IList <T> interface'dir. List<T> class'dır. List<T> class'ı IList<T> interface'ini implemente eder.
//ICollection<T> interface'dir. List<T> class'ı ICollection<T> interface'ini implemente eder.
//IEnumerable<T> interface'dir. List<T> class'ı IEnumerable<T> interface'ini implemente eder.
//Model bainder ile uygun isimlendirme yapılarak birbirine işler(Post sırasında)