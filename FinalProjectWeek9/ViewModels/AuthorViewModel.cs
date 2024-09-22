namespace FinalProjectWeek9.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }  // Unique identifier for the author
        public string FirstName { get; set; }  // First name of the author
        public string LastName { get; set; }  // Last name of the author
        public DateTime DateOfBirth { get; set; }  // Date of birth of the author
        public string FullName => $"{FirstName} {LastName}";  // Full name of the author (concatenation of first and last name)
    }
}
