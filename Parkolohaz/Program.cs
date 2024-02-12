using Parkolohaz;
using System.Text;

namespace Parkolohaz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Szint> szintek = new();
            using StreamReader sr = new(
                path: @"..\..\..\src\parkolohaz.txt",
                encoding: System.Text.Encoding.UTF8);
            while(!sr.EndOfStream) szintek.Add(new(sr.ReadLine()));
            foreach (var szint in szintek)
            {
                Console.WriteLine(szint.ToString());
            }
            Console.WriteLine("\n8. felatat:");
            int min = szintek[0]._szektorok.Values.Sum();
            int index = 0;
            for (int i = 1; i < szintek.Count; i++)
            {
                if (szintek[i]._szektorok.Values.Sum()  < min)
                {
                    min = szintek[i]._szektorok.Values.Sum();
                    index = i;
                }
            }
            Console.WriteLine($"\tA szektor, ahol a legkevesebb autó van a {szintek[index]._name}");

            Console.WriteLine("\n9. feladat:");
            Console.WriteLine("Szintek és szektorok, ahol nincsenek autók:");
            bool hiba = true;
            foreach (var szint in szintek)
            {
                for (int i = 0; i < szint._szektorok.Count; i++)
                {
                    if (szint._szektorok[$"{i+1}. szektor"] == 0)
                    {
                        Console.WriteLine($"\t{szint._name}\t{i+1}. szektor");
                        hiba = false;
                    }
                }
            }
            if ( hiba ) Console.WriteLine("Nincs olyan szektor, ahol nem parkol autó");

            Console.WriteLine("\n10. feladat:");
            double atlag = 0;
            for (int i = 0; i < szintek.Count; i++)
            {
                atlag += szintek[i]._szektorok.Values.Sum();
            }
            atlag /= szintek.Count * 6;
            atlag = Math.Round(atlag);
            int atlagos = 0;
            int atlagAlatt = 0;
            int atlagFelett = 0;
            foreach (var szint in szintek)
            {
                for (int i = 1; i < szint._szektorok.Count; i++)
                {
                    if (szint._szektorok[$"{i}. szektor"] == atlag)  atlagos++;
                    else if(szint._szektorok[$"{i}. szektor"] < atlag) atlagAlatt++;
                    else atlagFelett++;
                }
            }
            Console.WriteLine($"Az átlagos autók száma:  {atlag}\n\t{atlagos} db szektorban van átlagos darabszámú autó\n\t{atlagAlatt} db szektorban van átlagosnál kevesebb darabszámú autó\n\t{atlagFelett}  db szektorban van átlagosnál nagyobb darabszámú autó");
            Console.ReadLine();
        }
    }
}
