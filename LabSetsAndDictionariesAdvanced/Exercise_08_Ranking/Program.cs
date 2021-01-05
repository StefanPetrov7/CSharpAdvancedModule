using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Exercise_08_Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Contest> contests = new HashSet<Contest>();
            string input;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] info = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                Contest newContest = new Contest(info[0], info[1]);

                if (contests.Any(x => x.Name == newContest.Name) == false)
                {
                    contests.Add(newContest);
                }
            }

            HashSet<Candidate> candidates = new HashSet<Candidate>();

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] info = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contestName = info[0];
                string contestPass = info[1];
                string candidateName = info[2];
                int points = int.Parse(info[3]);

                if (contests.Any(x => x.Name == contestName && x.Pass == contestPass))
                {
                    if (candidates.Any(x => x.Name == candidateName) == false)
                    {
                        candidates.Add(new Candidate(candidateName));
                    }

                    Candidate curCandidate = candidates.FirstOrDefault(x => x.Name == candidateName);

                    if (curCandidate.ContestPoints.ContainsKey(contestName) == false)
                    {
                        curCandidate.ContestPoints.Add(contestName, points);
                    }
                    else
                    {
                        if (curCandidate.ContestPoints[contestName] < points)
                        {
                            curCandidate.ContestPoints[contestName] = points;
                        }
                    }
                }
            }

            Candidate bestUser = candidates.OrderByDescending(x => x.ContestPoints.Values.Sum()).FirstOrDefault();
            Console.WriteLine($"Best candidate is {bestUser.Name} with total {bestUser.ContestPoints.Values.Sum()} points.");
            Console.WriteLine($"Ranking:");
            foreach (var candidate in candidates.OrderBy(x => x.Name))
            {
                Console.WriteLine(candidate.Name);
                Console.WriteLine(candidate.ToString());
            }
        }
    }

    public class Contest
    {
        public string Name { get; set; }
        public string Pass { get; set; }

        public Contest(string name, string pass)
        {
            this.Name = name;
            this.Pass = pass;
        }
    }

    public class Candidate
    {
        public string Name { get; set; }
        public Dictionary<string, int> ContestPoints { get; set; }

        public Candidate(string name)
        {
            this.Name = name;
            this.ContestPoints = new Dictionary<string, int>();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            foreach (var contest in ContestPoints.OrderByDescending(x => x.Value))
            {
                output.AppendLine($"#  {contest.Key} -> {contest.Value}");
            }
            return output.ToString().TrimEnd();
        }
    }
}
