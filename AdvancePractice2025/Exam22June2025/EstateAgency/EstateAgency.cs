using System.Text;

namespace EstateAgency
{
    public class EstateAgency
    {
        public EstateAgency(int capacity)
        {
            this.Capacity = capacity;
            this.RealEstates = new List<RealEstate>();
        }

        public int Capacity { get; set; }

        public List<RealEstate> RealEstates { get; set; }

        public int Count => this.RealEstates.Count;

        public void AddRealEstate(RealEstate realEstate)
        {
            if (this.RealEstates.Count == this.Capacity)
                return;
            if (this.RealEstates.Any(x => x.Address == realEstate.Address))
                return;

            this.RealEstates.Add(realEstate);
        }

        public bool RemoveRealEstate(string address)
        {
            var estate = this.RealEstates.FirstOrDefault(x => x.Address == address);
            return this.RealEstates.Remove(estate);
        }

        public List<RealEstate> GetRealEstates(string postalCode)
        {
            var result = new List<RealEstate>();

            result = this.RealEstates.Where(x => x.PostalCode == postalCode).ToList();

            return result;
        }

        public RealEstate GetCheapest() => this.RealEstates.OrderBy(x => x.Price).First();

        public int GetLargest() => (int)this.RealEstates.OrderByDescending(x => x.Size).First().Size;

        public string EstateReport()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Real estates available:");

            foreach (var estate in this.RealEstates)
            {
                result.AppendLine(estate.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
