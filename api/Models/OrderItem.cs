using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("OrderItem")]
    public class OrderItem
    {
        public int Id { get; set; }
        public int LemonadeId { get; set; }
        public int OrderId { get; set; }
        public int Qty { get; set; }
        public decimal Total { get; set; }
    }
}