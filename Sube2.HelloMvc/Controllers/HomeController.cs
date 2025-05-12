using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sube2.HelloMvc.Models;

namespace Sube2.HelloMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OgrenciDbContext _context;

        public HomeController(ILogger<HomeController> logger, OgrenciDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        // �statistikleri d�nd�ren metod
        [HttpGet]
        public IActionResult GetStatistics()
        {
            var totalStudents = _context.Ogrenciler.Count();

            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var newThisMonth = _context.Ogrenciler.Count(o => o.CreatedAt  >= firstDayOfMonth);

            // S�n�f verisi olmad���ndan bo� dizi d�nd�r�yoruz
            var classDistribution = new List<object>();
            var monthlyAdditions = new List<object>(); // �stersen eklenebilir

            return Json(new
            {
                totalStudents,
                newThisMonth,
                classDistribution,
                monthlyAdditions
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
