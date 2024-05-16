using System.ComponentModel.DataAnnotations.Schema;

namespace FindIt.Models
{
    [Table("comments")]
    public class CommentModel
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("item_id")]
        public required int ItemId { get; set; }

        [Column("user_id")]
        public required int UserId { get; set; }

        [Column("text")]
        public required string Text { get; set; }

        [Column("date_stamp")]
        public required DateTime DateStamp { get; set; }
    }
}