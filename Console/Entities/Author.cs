using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova3.Entities
{
    internal class Author
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public int YearBorn { get; set; }

        public Author(string name,string lastName,int year)
        {
            Name = name;
            LastName = lastName;
            YearBorn = year;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"nome:{Name} cognome:{LastName} anni di nascita: {YearBorn}");
        }
    }
}
