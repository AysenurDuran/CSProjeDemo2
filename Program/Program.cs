using CSProjeDemo2;

class Program
{
    static void Main(string[] args)
    {
        // JSON dosyasından personel bilgilerini oku
        List<Personel> personeller = DosyaOku.Oku(@"C:\Users\aysenur\Desktop\personel.json");

        // Maaş bordrosu oluştur
        MaasBordro.Olustur(personeller);

        // Az çalışan personelleri raporla
        MaasBordro.AzCalisanlariRaporla(personeller);

        Console.ReadLine();


    }
}