using System.ComponentModel.DataAnnotations.Schema;

namespace FindIt.Models
{
    [Table("users")]
    public class UserModel
    {
        [Column("id")]
        public required int Id { get; set; }

        [Column("first_name")]
        public required string FirstName { get; set; }

        [Column("last_name")]
        public required string LastName { get; set; }

        [Column("username")]
        public required string Username { get; set; }

        [Column("password")]
        public required string Password { get; set; }

        [Column("email")]
        public required string Email { get; set; }

        [Column("phone_number")]
        public required string PhoneNumber { get; set; }

        [Column("date_stamp")]
        public DateTime? DateStamp { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}