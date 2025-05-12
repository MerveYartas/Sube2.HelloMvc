using System.ComponentModel.DataAnnotations;

namespace Sube2.HelloMvc.Models
{
    public class Ogrenci
    {
        [Key]
        public int Ogrenciid{ get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
