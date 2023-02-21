namespace TestTask210223.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string NameOrder { get; set; }
        public string Client { get; set; }
        public string PhoneNumber { get; set; }
        public List<Product>? Products { get; set; }

    }
}
