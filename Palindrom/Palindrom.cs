using System;

namespace Palindrom
{
    /*
     * Program Palindrom sluzi za proveru da li je data rec palindrom ili ne
     * Najpre izbacuje testiranje funkcije, a potom proverava da li je rec koju
     * je korisnik uneo palindrom ili ne.
     * 
     * U prvobitnoj verziji su sva testiranja bila u Main metodi programa.
     * Potom sam ubacio i interakciju sa korisnikom, koristeci input
     * Zatim je usledila ideja da iskoristim while petlju kako bi se program ponovo izvrsavao,
     * a za to je bila potrebna promenljiva 'nastavak'
     * Onda sam smestio vecinu koda iz main metode u zasebne funkcije.
     * 
     * Ovo je finalna verzija.
     */
    internal class Palindrom
    {
        static void Main()
        {
            Testiranje();

            //InterakcijaSaKorisnikom();

            // moguce dalje nadogradnje: while petlja za ponavljanje unosa i pokretanja funkcije.

            string nastavak = "d";

            while (nastavak == "d")
            {
                InterakcijaSaKorisnikom();
                Console.WriteLine("\nZelite li ponovo (d/n)? ");
                nastavak = Console.ReadLine().ToLower();
            }
            
            //Console.ReadKey();
        }

        // Funkcija ProveraPalindroma vraca string i koristi string kao parametar
        public static string ProveraPalindroma(string str)
        {
            // Prvo pretvoriti sva slova u mala
            str = str.ToLower();
            // deklaracija indeksa stringa (i je pocetni index, j je krajnji)
            int i = 0;
            int j = str.Length - 1;
            // indeks polovine stringa za slucaj stringa sa parnim brojem slova (palindromi su u sustini neparne duzine)
            int srednjiIndeks = (int) (str.Length - 1) / 2;
            // Potencijalni odgovori, buduci da je moguc true ili false odgovor, a string je formatiran zbog srpskog jezika
            string jeste = $"Rec {str} jeste palindrom";
            string nije = $"Rec {str} nije palindrom";

            // while petlja za iteraciju kroz string i uporedjivanje pojedinacnih slova
            while (i != j && i <= srednjiIndeks) // uslov da i nije jednak j I da je i manje od polovine duzine stringa
            {
                if (str[i] == str[j])
                {
                    // Komentirani su ispisi za testiranje broja indeksa i njihovog kretanja do nalazenja resenja
                    //Console.WriteLine("Index i pre povecanja: {0}, index j pre smanjenja: {1}", i, j);

                    // Kad je uslov da su slova sa simetricnim indeksima sa pocetka i kraja stringa isti,
                    // pocetni indeks se povecava, a krajnji smanjuje.
                    i++;
                    j--;
                    //Console.WriteLine("Index i posle povecanja: {0}, index j posle smanjenja: {1}", i, j);
                }
                // Ukoliko slova nisu jednaka na zadatim indeksima, pokrece se else blok koji vraca odgovor u promenljivoj 'nije'
                else
                    return nije;
            }
            // Kada se zavrsi while petlja, indeksi su ili isti ili simetricni oko centra, npr. i=j=8 ili i=8, j=9
            // Vraca se poredjenje slova posle petlje i ispis shodan rezultatu poredjenja.
            return (str[i] == str[j]) ? jeste : nije;
        }

        public static void Testiranje()
        {
            // Test case za ProveraPalindroma funkciju
            string test1 = "AnaVoliMilovana";
            string test2 = "Palindrom";
            string test3 = "Palindromordnilap";
            string test4 = "Palindrommordnilap";

            // Konzolni ispis funkcije ProveraPalindroma
            Console.WriteLine(ProveraPalindroma(test1));
            Console.WriteLine(ProveraPalindroma(test2));
            Console.WriteLine(ProveraPalindroma(test3));
            Console.WriteLine(ProveraPalindroma(test4));
        }

        public static void InterakcijaSaKorisnikom()
        {
            // Deo za testiranje interakcije sa korisnikom -- dodatni task radi testiranja razumevanja C# sintakse
            // Separator
            Console.WriteLine("\n-----------------------------------------------------------\n");
            Console.WriteLine("Unesite rec: ");
            // Unos se snima u promenljivoj
            string rec = Console.ReadLine();
            // Ispis rezultata funkcije sa unosom kao parametrom
            Console.WriteLine($"\n{ProveraPalindroma(rec)}");
        }
    }
}
