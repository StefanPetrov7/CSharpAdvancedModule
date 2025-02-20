namespace EstateAgency
{
    public class RealEstate
    {
        public RealEstate(string address, string postalCode, decimal price, double size)
        {
            this .Address = address;    
            this .PostalCode = postalCode;  
            this .Price = price;    
            this .Size = size;  
        }

        public string Address  { get; set; }

        public string PostalCode { get; set; }

        public decimal Price { get; set; }

        public double Size { get; set; }

        public override string ToString()
        {
            return $"Address: {this.Address}, PostalCode: {this.PostalCode}, Price: ${this.Price}, Size: {this.Size} sq.m.";
        }
    }
}
