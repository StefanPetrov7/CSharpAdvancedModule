using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(x => x.Name == name);

            if (player == null)
            {
                return false;
            }
            return this.roster.Remove(player);
        }

        public void PromotePlayer(string name)
        {
            this.roster.FirstOrDefault(x => x.Name == name).Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            this.roster.FirstOrDefault(x => x.Name == name).Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] players = this.roster.Where(x => x.Class == @class).ToArray();
            this.roster = this.roster.Where(x => x.Class != @class).ToList();
            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
