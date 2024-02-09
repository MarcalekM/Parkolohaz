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
            Console.WriteLine($"\nA szektor, ahol a legkevesebb autó van a {szintek[index]._name}");

            Console.WriteLine("\nSzintek és szektorok, ahol nincsenek autók:\n");
            bool hiba = true;
            foreach (var szint in szintek)
            {
                for (int i = 0; i < szint._szektorok.Count; i++)
                {
                    if (szint._szektorok[$"{i+1}. szektor"] == 0)
                    {
                        Console.WriteLine($"{szint._name}\t{i+1}. szektor");
                        hiba = false;
                    }
                }
            }
            if ( hiba ) Console.WriteLine("Nincs olyan szektor, ahol nem parkol autó");
            Console.ReadLine();
        }
    }
}
