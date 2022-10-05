using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Size")]
    public class Size
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}