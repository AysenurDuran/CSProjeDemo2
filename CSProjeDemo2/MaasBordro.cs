using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public static class MaasBordro
    {
        public static void Olustur(List<Personel> personeller)
        {
            string maasTarihi = DateTime.Now.ToString("MMMM yyyy", CultureInfo.GetCultureInfo("tr-TR"));
            foreach (var personel in personeller)
            {
                // Maaş hesabı yap
                decimal salary = personel.CalculateSalary();

                // Maaş bilgileri JSON formatında oluştur
                var maasBilgisi = new
                {
                    PersonelIsmi = personel.Name,
                    CalismaSaati = personel.WorkHours,
                    AnaOdeme = salary,
                    Mesai = (salary - (personel.HourlyWage * personel.WorkHours)), // Mesai ücreti hesapla
                    ToplamOdeme = salary
                };

                // Maaş bilgilerinin kaydedileceği klasörü oluştur
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MaasBordro", personel.Name);
                Directory.CreateDirectory(folderPath); // Eğer klasör yoksa oluştur

                // Maaş bilgilerini dosyaya kaydet
                string fileName = $"MaasBordro_{maasTarihi}.json";
                string filePath = Path.Combine(folderPath, fileName);
                File.WriteAllText(filePath, JsonConvert.SerializeObject(maasBilgisi, Formatting.Indented));
            }
        }

        public static void AzCalisanlariRaporla(List<Personel> personeller)
        {
            Console.WriteLine("Az Çalışan Personellerin Bilgileri:");
            foreach (var personel in personeller)
            {
                if (personel.WorkHours < 150)
                {
                    Console.WriteLine($"Personel Adı: {personel.Name}, Çalışma Saati: {personel.WorkHours}");
                }
            }
        }
    }
}
    

