﻿using Prova3.Entities;
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
                        //List<Podcast> list5 = pod.Fetch();  // volevo prendere il titolo del podcast associato agli episodi 
                        foreach (Episode episode in list4)
                        {
                            episode.PrintInfo();
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

        
    }
}