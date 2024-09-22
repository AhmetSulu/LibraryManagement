namespace FinalProjectWeek9.Models
{
    public class Author
    {
        public int Id { get; set; }  // Unique identifier for the author
        public string FirstName { get; set; }  // Author's first name
        public string LastName { get; set; }  // Author's last name
        public DateTime DateOfBirth { get; set; }  // Author's date of birth
    }
}
