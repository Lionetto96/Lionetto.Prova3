using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova3.Entities
{
    internal class Song :MultimedialFile
    {
        public GenereEnum Genere { get; set; }
        public Song(string title, Author author,GenereEnum genere) 
            : base(title, author)
        {
            Genere = genere;
        }

        

        
       
        public override void PrintInfo()
        {
            Console.WriteLine($"titolo:{Title}  autore:{Author.Name},{Author.LastName},{Author.YearBorn} genere:{Genere}");
            

        }




     

    }
    internal enum GenereEnum
    {
        Rock=1,
        Jazz=2,
        Pop=3
    }





   
}

