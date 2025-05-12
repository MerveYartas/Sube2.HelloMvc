namespace Sube2.HelloMvc.Models.ViewModels
{
    public class OgrenciDetayDTO
    {
        public Ogrenci? Ogrenci { get; set; } // NUll olabilir uyarısı kalksın diye soru işareti
       // public Ogretmen? Ogretmen { get; set; }
    }
}

//Birden fazla viewe modelle gönderebilmek için kuulanduığımız bir yöntemdir.
//Viewin ihtiyacı olan verileri bir arada tutmak için kullanılır.
