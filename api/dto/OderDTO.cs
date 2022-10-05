using api.Models;

namespace api.dto
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public OrderItem[] Items { get; set; }
        public decimal Total { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }    
}