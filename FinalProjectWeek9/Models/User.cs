namespace FinalProjectWeek9.Models
{
    public class User
    {
        public int Id { get; set; }  // Unique identifier for the user
        public string FullName { get; set; }  // User's full name
        public string Email { get; set; }  // User's email address
        public string Password { get; set; }  // User's password
        public string PhoneNumber { get; set; }  // User's phone number
        public DateTime JoinDate { get; set; }  // Date when the user joined
    }
}
