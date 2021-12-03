using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova3.Entities
{
    internal class Podcast : MultimedialFile
    {
     
        public string Description { get; set; }

        public List<Episode> Episodes { get; set; }

        public Podcast(string title,Author author,string descr,List<Episode> episodes)
            : base(title, author)
        {
            
            Description = descr;
            Episodes = episodes;

        }
        
        public override void PrintInfo()
        {
            Console.WriteLine($"titolo:{Title} autore:{Author.Name},{Author.LastName},{Author.YearBorn} descrizione:{Description}");
        }

        ////per stampare solo titolo ed episodi, ma non l'ho usato 
        //public void PrintInfo2()
        //{
        //    Console.WriteLine($"titolo:{Title} ");
        //    foreach(var episode in Episodes) { episode.PrintInfo(); }
        //}

    }
}
