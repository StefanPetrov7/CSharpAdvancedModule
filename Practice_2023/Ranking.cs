using System.Text;

namespace Practice_2023;

class Ranking
{
    static void Main(string[] args)
    {


        HashSet<Contest> contests = new HashSet<Contest>();
        HashSet<User> users = new HashSet<User>();

        string input;

        while ((input = Console.ReadLine()) != "end of contests")
        {
            string[] arg = input.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string contestName = arg[0];
            string contestPass = arg[1];
            Contest contest = contests.FirstOrDefault(c => c.Name == contestName);

            if (contest == null)
            {
                contests.Add(new Contest(contestName, contestPass));
            }
        }

        while ((input = Console.ReadLine()) != "end of submissions")
        {
            string[] arg = input.Split("=>").ToArray();
            string contestName = arg[0];
            string contestPass = arg[1];
            string userName = arg[2];
            int points = int.Parse(arg[3]);

            Contest curContest;

            if (contests.Any(x => x.Name == contestName && x.Pass == contestPass))
            {
                curContest = new Contest(contestName, contestPass);
                curContest.Points = points;
            }
            else
            {
                continue;
            }

            User user = users.FirstOrDefault(u => u.Name == userName);

            if (user == null)
            {
                user = new User(userName);
                user.Contests.Add(curContest);
                users.Add(user);
                continue;
            }

            Contest prevContest = user.Contests.FirstOrDefault(x => x.Name == curContest.Name);

            if (prevContest == null)
            {
                user.Contests.Add(curContest);
            }
            else if (prevContest.Points < curContest.Points)
            {
                user.Contests.Where(x => x.Name == curContest.Name).FirstOrDefault().Points = curContest.Points;
            }

        }

        User bestUser = users.OrderByDescending(x => x.TotalPoints).First();

        Console.WriteLine($"Best candidate is {bestUser.Name} with total {bestUser.TotalPoints} points.\nRanking: ");

        foreach (User user in users.OrderBy(x => x.Name))
        {
            Console.WriteLine(user.ToString());
        }
    }

    class User
    {
        public User(string name)
        {
            this.Name = name;
            this.Contests = new List<Contest>();
        }

        public string Name { get; set; }

        public List<Contest> Contests { get; set; }

        public int TotalPoints => Contests.Sum(x => x.Points);

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(this.Name);

            foreach (var contest in this.Contests.OrderByDescending(x => x.Points))
            {
                result.AppendLine($"#  {contest.Name} -> {contest.Points}");
            }

            return result.ToString().TrimEnd();
        }

    }

    class Contest
    {
        public Contest(string name, string pass)
        {
            this.Name = name;
            this.Pass = pass;
        }

        public string Name { get; set; }

        public string Pass { get; set; }

        public int Points { get; set; }

    }
}