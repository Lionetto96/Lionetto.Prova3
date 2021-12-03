using Prova3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova3.Repository
{
    internal class PodcastRepository : IDbRepository<Podcast>
    {
        static Episode e1=new Episode("episodio1",new Durata(1,30,05),false);
        static Episode e2 = new Episode("episodio2", new Durata(1, 25, 00), false);
        static List<Episode> episodesCC=new List<Episode>() { e1,e2};
        static Podcast p1=new Podcast("da costa a costa",new Author("Francesco","Costa",1980),"politica e società americana",episodesCC);
        
        static Episode e3 = new Episode("episodio1", new Durata(2, 20, 05), false);
        static Episode e4 = new Episode("episodio2", new Durata(1, 55, 00), false);
        static List<Episode> episodesSR =new List<Episode>() { e3,e4};
        static Podcast p2 = new Podcast("senza rossetto", new Author("Alberto", "b", 2016), "figura della donna ", episodesSR);
        
        static List<Podcast> podcasts = new List<Podcast>() { p1,p2};
        public List<Podcast> Fetch()
        {
            return podcasts;
        }
        public List<Episode> FetchEpisodeCC()
        {
            return episodesCC;
        }
        public List<Episode> FetchEpisodeSR()
        {
            return episodesSR;
        }
        public  List<Episode> FetchEpisode()
        {
            List<Episode> list = new List<Episode>();
            List<Episode> listCC = FetchEpisodeCC();
            List<Episode> listSR = FetchEpisodeSR();

            list.AddRange(listCC);
            list.AddRange(listSR);
            return list;
        }

        public List<Episode> GetByTitle(string Title)
        {
            List<Podcast> pp = Fetch();
            
            pp=podcasts.Where(p => p.Title == Title).ToList();
            Podcast p=pp.FirstOrDefault();
            return p.Episodes;
        }
        public List<Episode> GetByDurata(Durata durata)
        {
            
            //List<Podcast> pp = Fetch();
            List<Episode> episodes = FetchEpisode();
            List<Episode> epi=new List<Episode>();
            foreach(var e in episodes)
            {
                if (e.Durata.Ore < durata.Ore)
                {
                    epi.Add(e);
                }
                else if (e.Durata.Ore == durata.Ore)
                {
                    if (e.Durata.Minuti < durata.Minuti)
                    {
                        epi.Add(e);
                    }
                    else if (e.Durata.Minuti == durata.Minuti)
                    {
                        if (e.Durata.Secondi <= durata.Secondi)
                        {
                            epi.Add(e);
                        }
                    }
                }
            }
            return epi;
            
        
            
            
        }
       
        
    }
}
