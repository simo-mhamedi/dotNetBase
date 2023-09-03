namespace Project_Spring_to_.net.Models.DTO
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Decimal Total { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
    }
}
