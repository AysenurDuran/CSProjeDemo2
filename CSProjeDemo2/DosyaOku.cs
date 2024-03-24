using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public static class DosyaOku
    {
        public static List<Personel> Oku(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var jArray = JArray.Parse(json);
            var personelListesi = new List<Personel>();

            foreach (var jToken in jArray)
            {
                var jObject = (JObject)jToken;
                string title = jObject["title"].ToString();
                string name = jObject["name"].ToString();

                // Personel tipine göre nesne oluştur
                Personel personel = null;
                if (title == "Yonetici")
                {
                    personel = new Yonetici();
                }
                else if (title == "Memur")
                {
                    personel = new Memur(1); 
                }

                // Personelin adını ve çalışma saatlerini ayarla
                if (personel != null)
                {
                    personel.Name = name;
                    personel.WorkHours = 0; // Çalışma saatlerini isteğe bağlı olarak ayarla
                    personelListesi.Add(personel);
                }
            }

            return personelListesi;
        }
    }

}
