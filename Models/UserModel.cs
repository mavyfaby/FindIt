namespace FindIt.Models
{
    public class UserModel
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string DateStamp { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}