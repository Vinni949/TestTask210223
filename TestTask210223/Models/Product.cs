namespace TestTask210223.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Order? orders {get; set; }
    }
}
