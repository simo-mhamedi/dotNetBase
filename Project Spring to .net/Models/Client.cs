namespace Project_Spring_to_.net.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int ClientCategoryId { get; set; }

        public ClientCategory ClientCategory { get; set; }

    }
}
