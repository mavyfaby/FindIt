using System.ComponentModel.DataAnnotations.Schema;

namespace FindIt.Models
{
    [Table("categories")]
    public class CategoryModel
    {
        [Column("id")]
        public required int Id { get; set; }
        
        [Column("parent_id")]
        public required int ParentId { get; set; }

        [Column("name")]
        public required string Name { get; set; }
    }
}