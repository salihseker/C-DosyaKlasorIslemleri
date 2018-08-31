using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DosyaKlasorIslemleri
{
    class Program
    {
        //www.salihseker.com - Salih ŞEKER
        static void Main(string[] args)
        {

            ////************ KLASÖR İŞLEMLERİ ************//
            //KlasorOlusturmaIslemi();
            //KlasorKontrolu();
            //GetCurrentDirectory();
            //DirectoryInfoKullanımı();
            //KlasorTasima();
            //KlasorSilme();
            //SistemSurucuListesi();
            //KlasorListele();

            ////************ DOSYA İŞLEMLERİ ************//
            //DosyaOlusturma();
            //DosyaKontrolIslemleri();
            //DosyaVeriYaz();
            //DosyaVeriOku();
            //DosyaTasima();
            //DosyaKopyalama();
            //DosyaSilme();
            //DosyaListele();
            //FileInfoKullanımı();

        }

        //************ KLASÖR İŞLEMLERİ ************////www.salihseker.com - Salih ŞEKER
        private static void KlasorOlusturmaIslemi()
        {
            Directory.CreateDirectory(@"C:\Salih\DirectorySinifi");//C sürücüsü altında klasör oluşturma
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"Salih\DirectorySinifi");//Projenin Exe sinin bulunduğu kısımda klasör oluşturma.
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Salih\DirectorySinifi2");//Projenin Exe sinin bulunduğu kısımda klasör oluşturma.
        }

        //www.salihseker.com - Salih ŞEKER
        private static void KlasorKontrolu()
        {
            bool Kontrol = Directory.Exists(@"C:\Salih\DirectorySinifi");//Exists klasör yolu verilen dizin i kontrol edip true veya false döner
            if (Kontrol)
            {
                Console.WriteLine("Belirtilen dizinde klasör mevcut");
            }
            else
            {
                Console.WriteLine("Belirtilen dizinde klasör bulunamadı");
            }
        }

        private static void GetCurrentDirectory()
        {
            string path = Directory.GetCurrentDirectory();//Exe nin bulunduğu dizin i getirme
            Console.WriteLine(path);
            Directory.SetCurrentDirectory(@"C:\Salih");//Uygulama çalışırken uygulama çalışma yolunu değiştirme
            path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);
        }
        //www.salihseker.com - Salih ŞEKER
        private static void DirectoryInfoKullanımı()
        {
            DirectoryInfo DI = new DirectoryInfo(@"C:\Salih");
            
            Console.WriteLine("Bulunduğu dizin adı :" + DI.Parent.FullName);
            Console.WriteLine("Oluşturma Tarih :" + DI.CreationTime.ToString("dd.MM.yyyy hh:mm"));
            Console.WriteLine("Tam Yol Bilgisi : " + DI.FullName);
            Console.WriteLine("Son Erişim Tarih" + DI.LastAccessTime.ToString("dd.MM.yyyy hh:mm"));
            DI.CreateSubdirectory("AltKlasor");

            DirectoryInfo[] Liste = DI.GetDirectories();//Klasör içindeki alt klasörleri listesi 
            foreach (var item in Liste)
            {
                Console.WriteLine(item.FullName);
            }
        }

        private static void KlasorTasima()
        {
            Directory.Move(@"C:\Salih\A", @"C:\Seker\A");
        }

        private static void KlasorSilme()
        {
            Directory.Delete(@"C:\Seker",true);//Klasör içi dolu olsa dahi silinmesi için ikinci parametre true olmalı.
        }
        //www.salihseker.com - Salih ŞEKER

        private static void SistemSurucuListesi()
        {
            string[] SistemSuruculeri = Directory.GetLogicalDrives();
            foreach (var item in SistemSuruculeri)
            {
                Console.WriteLine("Sürücü Adı : " + item);
            }
            Console.ReadLine();
        }

        private static void KlasorListele()
        {
            string[] Liste = Directory.GetDirectories(@"C:\Program Files\");
            foreach (var item in Liste)
            {
                Console.WriteLine(item);
            }

        }

        //************ DOSYA İŞLEMLERİ ************////www.salihseker.com - Salih ŞEKER

        private static void DosyaOlusturma()
        {
            FileStream fs = File.Create(@"C:\Salih\Merhaba.txt");//Salih Klasörü altında Merhaba isminde bir txt oluşturulur.
            fs.Close();//Oluşturulan dosyayı kapatmamız gerekir.

        }
        //www.salihseker.com - Salih ŞEKER
        private static void DosyaKontrolIslemleri()
        {
            bool Kontrol = File.Exists(@"C:\Salih\Merhaba.txt");
            if (Kontrol)
            {
                Console.WriteLine("Dosya sistemde mevcut.");
            }
            else
            {
                Console.WriteLine("Dosya sistemde bulunamadı.");
            }

        }

        private static void DosyaVeriYaz()
        {
            StreamWriter sw = new StreamWriter(@"C:\Salih\Merhaba.txt");
            sw.WriteLine("Merhaba Dünya!");
            sw.Close();
        }
        //www.salihseker.com - Salih ŞEKER
        private static void DosyaVeriOku()
        {
            StreamReader sr = new StreamReader(@"C:\Salih\Merhaba.txt");
            string Veri = sr.ReadToEnd();
            sr.Close();
            Console.WriteLine(Veri);
            Console.ReadLine();
        }

        private static void DosyaTasima()
        {
            File.Move(@"C:\Salih\Merhaba.txt", @"C:\Seker\Merhaba.txt");//Dosya kopyalanmaz komple taşınır.
        }

        private static void DosyaKopyalama()
        {
            for (int i = 0; i < 5; i++)//5 kere Kopyalamak için Merhaba1.txt,Merhaba2.txt,...,Merhaba5.txt
            {
                string DosyaIsim = "Merhaba" + i.ToString() + ".txt";
                File.Copy(@"C:\Salih\Merhaba.txt", @"C:\Salih\Tasinan\" + DosyaIsim);
            }

        }
        //www.salihseker.com - Salih ŞEKER
        private static void DosyaSilme()
        {
            File.Delete(@"C:\Salih\Tasinan\Merhaba1.txt");
            
        }

        private static void DosyaListele()
        {
            string[] Dosyalarim = Directory.GetFiles(@"C:\Salih\Tasinan\");
            for (int i = 0; i < Dosyalarim.Length; i++)
            {
                Console.WriteLine("Dosya Yolu:" + Dosyalarim[i]);
            }

            Console.ReadLine();

        }
        //www.salihseker.com - Salih ŞEKER
        private static void FileInfoKullanımı()
        {
            FileInfo FI = new FileInfo(@"C:\Salih\Tasinan\Merhaba0.txt");


            DirectoryInfo DI = FI.Directory;//Bulunduğu klasör.
            FileInfo[] DirectoryInfoList = DI.GetFiles();//dosyanın bulunduğu klasördeki dosyaların listesi.

            Console.WriteLine("Dosya Olusturma Zamani : " + FI.CreationTime.ToString("dd.MM.yyyy hh:ss"));
            Console.WriteLine("Tam Yol Bilgisi : " + FI.FullName);
            Console.WriteLine("Dosya Uzantisi : " + FI.Extension);
            Console.WriteLine("Byte Uzunluk : " + FI.Length.ToString());
            Console.WriteLine("Dosya Adi : " + FI.Name);
            Console.WriteLine("Klasor Adi : " + FI.DirectoryName);
            foreach (var item in DI.GetFiles())
            {
                Console.WriteLine("Klasör --> "+ FI.DirectoryName + " - Dosya Adi -->" + item.Name);
            }

            Console.ReadLine();

        }
    }
}
