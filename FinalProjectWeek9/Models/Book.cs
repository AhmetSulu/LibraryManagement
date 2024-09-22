namespace FinalProjectWeek9.Models
{
    public class Book
    {
        public int Id { get; set; }  // Unique identifier for the book
        public string Title { get; set; }  // Title of the book
        public string Author { get; set; }  // Author of the book
        public string Genre { get; set; }  // Genre of the book
        public DateTime PublishDate { get; set; }  // Publish date of the book
        public string ISBN { get; set; }  // ISBN number of the book
        public int CopiesAvailable { get; set; }  // Number of copies available
    }
}
