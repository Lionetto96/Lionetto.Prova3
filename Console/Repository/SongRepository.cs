using Prova3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova3.Repository
{
    internal class SongRepository : IDbRepository<Song>
    {
        static Song s1 = new Song("Libero", new Author("Fabrizio", "Moro", 1975), GenereEnum.Pop);
        static Song s2 = new Song("sally", new Author("Vasco", "Rossi", 1964), GenereEnum.Rock);
        static Song s3 = new Song("Take five", new Author("Dave", "Brubeck", 1969), GenereEnum.Jazz);
        static List<Song> songs = new List<Song>() { s1,s2,s3};

        public List<Song> Fetch()
        {
           return songs;
        }

        public List<Song> GetByGenere(GenereEnum genere)
        {
            List<Song> ss=new List<Song>();
            ss=songs.Where(s => s.Genere == genere).ToList();
            return ss;
        }
    }
}
