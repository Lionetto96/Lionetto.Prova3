using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova3.Entities
{
    internal class Episode
    {
        public string Title { get; set; }
        public Durata Durata { get; set; }

        public bool Reproduced { get; set; }

        public Episode(string title,Durata durata,bool rep)
        {
            Title = title;
            Durata = durata;
            Reproduced = false;
        }

        public Episode() { }
        public  void PrintInfo()
        {
            Console.WriteLine($"titolo:{Title} durata:{Durata.Ore},{Durata.Minuti},{Durata.Secondi} riprodotto:{Reproduced}");
        }
    }


    public struct Durata
    {
        public int Ore { get; set; }
        public int Minuti { get; set; }
        public int Secondi { get; set; }

        public Durata(int ore, int min, int sec)
        {
            Ore = ore;
            Minuti = min;
            Secondi = sec;
        }
    }
}
