using Microsoft.EntityFrameworkCore;

namespace Sube2.HelloMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

           builder.Services.AddDbContext<OgrenciDbContext>(options =>
           options.UseSqlServer("Server=localhost;Database=OgrenciDb;Trusted_Connection=True;TrustServerCertificate=True;"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //Burada defauld model yönlendiriliyor. Ýd'nin yanýndaki ? null daolabilir yazmyabilirsin demek

            app.Run();
        }
    }
}
