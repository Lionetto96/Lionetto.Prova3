using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova3.Entities
{
    internal abstract class MultimedialFile
    {
        public string Title { get; set; }
        public Author Author { get; set; }

        public MultimedialFile(string title,Author author)
        {
            Title = title;
            Author = author;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"titolo:{Title} autore:{Author.Name},{Author.LastName},{Author.YearBorn}");
        }
    }
}
