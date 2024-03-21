using System.ComponentModel.DataAnnotations.Schema;

namespace FindIt.Models
{
    [Table("items")]
    public class ItemModel
    {
        [Column("id")]
        public required int Id { get; set; }

        [Column("category")]
        public required int Category { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("description")]
        public required string Description { get; set; }

        [Column("location")]
        public required string Location { get; set; }

        [Column("image")]
        public required byte[] Image { get; set; }

        [Column("date_lost")]
        public required DateTime? DateLost { get; set; }

        [Column("status")]
        public required int Status { get; set; }

        [Column("status_updated")]
        public required DateTime? StatusUpdated { get; set; }

        [Column("date_found")]
        public required DateTime? DateFound { get; set; }

        [Column("claimed_by")]
        public required int? ClaimedBy { get; set; }

        [Column("claimed_date")]
        public required DateTime? ClaimedDate { get; set; }
        
        [Column("claimed_notes")]
        public required string ClaimedNotes { get; set; }

        [Column("date_stamp")]
        public DateTime DateStamp { get; set; }
    }
}