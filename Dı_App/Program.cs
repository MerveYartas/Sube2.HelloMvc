using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dı_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Islemler isl = new Islemler(new Ogrenci());
            isl.KayitYap();
        }
       
    }
    class Islemler
    {
        private IKayit _kayit;
        public Islemler(IKayit kayit)
        {
            _kayit = kayit;
        }
        public void KayitYap()
        {
            _kayit.Kaydet();
        }
    }
    interface IKayit
    {
        void Kaydet();
    }
    class Personel : IKayit
    {
        public void Kaydet()
        {
            Console.WriteLine("Personel Kaydedildi");
        }
    }
    class Ogrenci : IKayit
    {
        public void Kaydet()
        {
            Console.WriteLine("Öğrenci Kaydedildi");
        }
    }
    //class Personel
    //{
    //    public void Kaydet()
    //    {
    //        Console.WriteLine(" Personel Kaydedildi");
    //    }
    //}
    //class Ogrenci
    //{
    //    public void Kaydet()
    //    {
    //        Console.WriteLine("Öğremci Kaydedildi")
    //    }
        
    //}
}
