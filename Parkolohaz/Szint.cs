using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Parkolohaz
{
    internal class Szint
    {
        public string _name;
        public Dictionary<string, int> _szektorok = new Dictionary<string, int>();

        public Szint(string sor)
        {
            var v = sor.Split(';').ToList();
            _name = v[0];
            int db = 0;
            for (int i = 1; i < v.Count; i++)
            {
                 db = int.Parse(v[i]);
                _szektorok.Add($"{i}. szektor", db);
            }
        }

        public override string ToString()
        {
            string text = string.Empty;
            if ( _name.Length < 7) text += _name + ",\t\t";
            else text += _name + ",\t";
            foreach (var szektor in _szektorok)
            {
                text += szektor.Value.ToString() + ",\t";
            }
            return text;
        }
    }
}
