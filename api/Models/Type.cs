using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Type")]
    public class Type
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}