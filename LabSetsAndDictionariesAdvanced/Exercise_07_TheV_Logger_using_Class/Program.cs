using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise_07_TheV_Logger_using_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Vlogger> vloggers = new HashSet<Vlogger>();

            string input;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = info[1];

                switch (cmd)
                {
                    case "joined":
                        string name = info[0];
                        Vlogger newVloger = new Vlogger(name);
                        if (vloggers.Any(x => x.Name == name) == false)
                        {
                            vloggers.Add(newVloger);
                        }
                        break;
                    case "followed":
                        string joinning = info[0];
                        string host = info[info.Length - 1];
                        if (vloggers.Any(x => x.Name == joinning) && vloggers.Any(x => x.Name == host))
                        {
                            Vlogger vlogerJoining = vloggers.Where(x => x.Name == joinning).FirstOrDefault();
                            Vlogger vlogerHost = vloggers.Where(x => x.Name == host).FirstOrDefault();

                            if (vlogerHost.Name != vlogerJoining.Name)
                            {
                                if (vlogerHost.Followers.Contains(joinning) == false)
                                {
                                    vlogerHost.Followers.Add(joinning);
                                    vlogerJoining.Followed.Add(host);
                                }
                            }

                        }
                        break;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            Vlogger bestVlogger = vloggers.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Followed.Count).FirstOrDefault();

            if (bestVlogger.Followers.Count > 0)
            {
                Console.WriteLine($"1. {bestVlogger.Name} : {bestVlogger.Followers.Count} followers, {bestVlogger.Followed.Count} following");
                foreach (var followers in bestVlogger.Followers.OrderBy(x => x).ToList())
                {
                    Console.WriteLine($"*  {followers}");
                }

                int counter = 2;
                vloggers.Remove(bestVlogger);

                foreach (var vlog in vloggers.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Followed.Count))
                {
                    Console.WriteLine($"{counter}. {vlog.Name} : {vlog.Followers.Count} followers, {vlog.Followed.Count} following");
                    counter++;
                }
            }
        }
    }

    public class Vlogger
    {
        public string Name { get; set; }
        public List<string> Followers { get; set; }
        public List<string> Followed { get; set; }

        public Vlogger(string name)
        {
            this.Name = name;
            this.Followers = new List<string>();
            this.Followed = new List<string>();
        }
    }
}
