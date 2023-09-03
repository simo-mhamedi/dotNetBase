namespace Project_Spring_to_.net.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Decimal Total { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
