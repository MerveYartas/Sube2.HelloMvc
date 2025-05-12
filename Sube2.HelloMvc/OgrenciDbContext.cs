using Microsoft.EntityFrameworkCore;
using Sube2.HelloMvc.Models;

namespace Sube2.HelloMvc
{
    public class OgrenciDbContext : DbContext
    {
        public OgrenciDbContext(DbContextOptions<OgrenciDbContext> options) : base(options)
        {
        }
        public DbSet<Ogrenci> Ogrenciler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");

            modelBuilder.Entity<Ogrenci>()
                .Property(o => o.Ad)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Ogrenci>()
                .Property(o => o.Soyad)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();
            ;
        }
    }
}
