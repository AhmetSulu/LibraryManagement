namespace FinalProjectWeek9.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }  // Unique identifier for the book
        public string Title { get; set; }  // Title of the book
        public string AuthorName { get; set; }  // Name of the book's author
        public string Genre { get; set; }  // Genre of the book
        public DateTime PublishDate { get; set; }  // Publish date of the book
        public string ISBN { get; set; }  // ISBN number of the book
        public int CopiesAvailable { get; set; }  // Number of copies available
    }
}
