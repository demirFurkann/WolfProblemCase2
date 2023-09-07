
using System.Text;

class Program
{

    static void Main(string[] args)
    {
        int num;

        do
        {
            // sayi girişi kontrolü

            Console.WriteLine("Kurt sayısını girin(5 ile 200000 arasinda pozitif tam sayı olmalıdır)");
        } while (!int.TryParse(Console.ReadLine(), out num) || num < 5 || num > 200000);

        // Sayilar oluşuyor list tipinde
        List<int> kurtTurleri = GenerateRandomWolfTypes(num);

        Console.WriteLine($"{num} Random Kurt Türleri Oluşturuldu");

        foreach (var item in kurtTurleri)
            Console.Write(item + " ");

        Console.WriteLine();

        int enFazlaOlanTuru = FindMostCommonWolfType(kurtTurleri);
        int enFazlaOlanTurSayisi = CountOccurrences(kurtTurleri, enFazlaOlanTuru);

        Console.WriteLine($"En fazla olan kurt türü: {enFazlaOlanTuru}, Toplam: {enFazlaOlanTurSayisi} adet");


        Console.ReadLine();
    }

    static List<int> GenerateRandomWolfTypes(int count)
    {
        Random rnd = new Random();
        List<int> kurtTurleri = new List<int>();

        for (int i = 0; i < count; i++)
        {
            int random = rnd.Next(1, 6);
            kurtTurleri.Add(random);
        }
        return kurtTurleri;
        // Bu mettotda  kurt türleri oluşturuyoruz ve koleksiyona ekliyoruz...
    }

    static int FindMostCommonWolfType(List<int> kurtTurleri)
    {
        Dictionary<int, int> turSayilari = new Dictionary<int, int>();

        foreach (var tur in kurtTurleri)
        {
            if (turSayilari.ContainsKey(tur))
            {
                turSayilari[tur]++;
            }
            else
            {
                turSayilari[tur] = 1; // türün ilk turu  örn {1,2,3,3 } 3 2 kayıt olurken 1 ve 2 ilk turlarında   
            }
        }
        int enFazlaOlanTur = 0; // En fazla tekrarlanan kurt türü numarasini saklamak için
        int enfazlaOlanTursayisi = 0; //  Buda tekrar sayisi  

        foreach (var item in turSayilari)
        {
            if (item.Value > enfazlaOlanTursayisi)
            {
                enFazlaOlanTur = item.Key;
                enfazlaOlanTursayisi = item.Value;
            }
        }
        return enFazlaOlanTur;

    }

    static int CountOccurrences(List<int> kurtTurleri, int tur)
    {
        int count = 0;
        foreach (var item in kurtTurleri)
        {
            if (item == tur)
            {
                count++;
            }
        }
        return count;
        // bu mettota count sayacı karşılastıgı türün adedini arttirir..
    }

}