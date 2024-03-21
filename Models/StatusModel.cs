using System.ComponentModel.DataAnnotations.Schema;

namespace FindIt.Models
{
    [Table("status")]
    public class StatusModel
    {
        [Column("id")]
        public required int Id { get; set; }
        
        [Column("name")]
        public required string Name { get; set; }
    }
}