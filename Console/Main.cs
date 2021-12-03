using Prova3.Entities;
using Prova3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova3
{
    internal class Main
    {
        static PodcastRepository pod = new PodcastRepository();
        static SongRepository son = new SongRepository();
        internal static void Start()
        {
            char choice;
            do
            {
                Console.WriteLine("scegli opzione:" +
                    "\n[1] visualizza tutte le canzoni" +
                    "\n[2] visualizza tutti i podcast" +
                    "\n[3] visualizza canzoni in base al genere" +
                    "\n[4] visualizza episodi di un certo podcast" +
                    "\n[5] visualizza episodi con una certa durata " +
                    "\n[6] crea playlist" +
                    "\n[7] scegli episodio da riprodurre e aggiorna il flag" +
                    "\n[Q] esci");
                choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        List<Song> list = son.Fetch();
                        foreach (Song song in list)
                        {
                            song.PrintInfo();
                        }
                        break;
                    case '2':
                        List<Podcast> list1 = pod.Fetch();
                        foreach(Podcast podcast in list1)
                        {
                            podcast.PrintInfo();
                        }
                        break;
                    case '3':
                        
                        string genere;
                        do
                        {
                            Console.WriteLine($"scegli genere:   {GenereEnum.Rock} \n {GenereEnum.Pop} \n {GenereEnum.Jazz}");

                            genere = Console.ReadLine();

                        } while (genere != "Rock" && genere != "Pop" && genere != "Jazz");
                        GenereEnum genereEnum = (GenereEnum)Enum.Parse(typeof(GenereEnum), genere);
                        List<Song> list2 = son.GetByGenere(genereEnum);
                        foreach (Song song in list2)
                        {
                            song.PrintInfo();
                        }
                        break;
                    case '4':
                        string title;
                        do
                        {
                            Console.WriteLine("inserisci il titolo del podcast");
                            title = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(title));
                        
                        List <Episode> pod3 = pod.GetByTitle(title);
                        foreach (Episode episode in pod3)
                        {
                            episode.PrintInfo();
                        }

                        break;
                    case '5':
                        Durata d = ChiediDurata();
                        List<Episode> list4=pod.GetByDurata(d);
                        List<Podcast> list5 = pod.Fetch();  
                        foreach(var podcast in list5)
                        {
                            foreach(var ep in list4)
                            {
                                
                                Console.WriteLine($"podcast:{podcast.Title}, Episodi: episodio:{ep.Title} durata:{ep.Durata.Ore} {ep.Durata.Minuti} {ep.Durata.Secondi}");
                            }
                            

                        }
                        
                        break;
                    case '6':
                        Song s=InsertSong();
                        bool exist = CheckSong(s.Title);
                        if (exist)
                        {
                            Console.WriteLine("questa canzone è già presente nella playlist");
                        }
                        else
                        {
                            List<Song> myPlaylist = CreatePlaylist(s);
                            foreach (var song in myPlaylist)
                            {
                                song.PrintInfo();
                            }
                        }

                        break;
                    case 'Q':
                        break;
                    default:
                        Console.WriteLine("scelta non valida");
                        break;


                }

            } while (choice != 'Q');

        }

        private static Durata ChiediDurata()
        {
            Durata d = new Durata();

            int ore;
            do
            {
                Console.WriteLine("Inserisci le ore di durata dell'episodio");
            } while (!int.TryParse(Console.ReadLine(), out ore));
            d.Ore = ore;

            int min;
            do
            {
                Console.WriteLine("Inserisci i minuti");
            } while (!int.TryParse(Console.ReadLine(), out min));
            d.Minuti = min;

            int sec;
            do
            {
                Console.WriteLine("Inserisci i secondi");
            } while (!int.TryParse(Console.ReadLine(), out sec));
            d.Secondi = sec;

            return d;
        }
        private static List<Song> CreatePlaylist(Song song)
        {
            List<Song> myPlaylist = new List<Song>();
            myPlaylist.Add(song);
            return myPlaylist;
        }

        private static Song InsertSong()
        {
            string title;
            do
            {
                Console.WriteLine("inserisci titolo della canzone");
                title = Console.ReadLine();
            }while(string.IsNullOrEmpty(title));
            string nome;
            do
            {
                Console.WriteLine("inserisci nome autore");
                nome = Console.ReadLine();
            }while(string.IsNullOrEmpty(nome));
            string cognome;
            do
            {
                Console.WriteLine("inserisci cognome autore");
                cognome = Console.ReadLine();
            } while (string.IsNullOrEmpty(cognome));
            int anno;
            do
            {
                Console.WriteLine("inserisci anno di nascita dell'autore");
                
            }while(!int.TryParse(Console.ReadLine(),out anno));
            string genere;
            do
            {
                Console.WriteLine($"scegli genere:   {GenereEnum.Rock} \n {GenereEnum.Pop} \n {GenereEnum.Jazz}");

                genere = Console.ReadLine();

            } while (genere != "Rock" && genere != "Pop" && genere != "Jazz");
            GenereEnum genereEnum = (GenereEnum)Enum.Parse(typeof(GenereEnum), genere);
            Song s=new Song(title,new Author(nome,cognome,anno),genereEnum);
            return s;
        }
        private static bool CheckSong(string  title)
        {
            List<Song> list = new List<Song>();
            foreach (Song s2 in list)
            {
                if(s2.Title == title)
                {
                    return true;
                }

            }
            return false;
        }

        
    }
}
