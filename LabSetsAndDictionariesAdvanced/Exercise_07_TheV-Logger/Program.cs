using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_07_TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> vlogInfo = new Dictionary<string, Dictionary<string, List<string>>>();
            string input;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] arg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string curVlogger = arg[0];
                string cmd = arg[1];
                string vloggerToJoin = arg[arg.Length - 1];

                switch (cmd)
                {
                    case "joined":
                        if (vlogInfo.ContainsKey(curVlogger) == false)
                        {
                            vlogInfo.Add(curVlogger, new Dictionary<string, List<string>>()
                            {
                                ["followers"] = new List<string>(),
                                ["following"] = new List<string>()
                            });
                        }
                        else continue;
                        break;
                    case "followed":
                        if (vlogInfo.ContainsKey(vloggerToJoin) == false && vlogInfo.ContainsKey(curVlogger) == false)
                        {
                            continue;
                        }
                        if (vlogInfo[vloggerToJoin]["followers"].Exists(x => x == curVlogger))
                        {
                            continue;
                        }
                        if (vlogInfo[curVlogger] == vlogInfo[vloggerToJoin])
                        {
                            continue;
                        }
                        vlogInfo[vloggerToJoin]["followers"].Add(curVlogger);
                        vlogInfo[curVlogger]["following"].Add(vloggerToJoin);
                        break;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vlogInfo.Count} vloggers in its logs.");
            int counter = 0;

            if (vlogInfo.Any(x => x.Value["followers"].Count > 0))
            {
                foreach (KeyValuePair<string, Dictionary<string, List<string>>> vlogers in vlogInfo
               .OrderByDescending(x => x.Value["followers"].Count)
               .ThenBy(x => x.Value["following"].Count))
                {
                    counter++;
                    string curVloger = vlogers.Key;
                    List<string> followers = vlogers.Value["followers"];
                    List<string> following = vlogers.Value["following"];
                    int curFollowers = followers.Count;
                    int curFollowing = following.Count;
                    Console.WriteLine($"{counter}. {vlogers.Key} : {curFollowers} followers, {curFollowing} following");

                    if (counter == 1)
                    {
                        foreach (var followedBy in followers.OrderBy(x => x))
                        {
                            Console.WriteLine($"*  {followedBy}");
                        }
                    }
                }
            }
        }
    }
}
