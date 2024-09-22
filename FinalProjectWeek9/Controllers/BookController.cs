using FinalProjectWeek9.Models;
using FinalProjectWeek9.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeek9.Controllers
{
    public class BookController : Controller
    {
        // Static list of books
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Olasılıksız", Author = "Adam Fawer", Genre = "Fiction, Thrilling", PublishDate = new DateTime(2005, 1, 1), ISBN = "9789756006054", CopiesAvailable = 5 },
            new Book { Id = 2, Title = "Sefiller", Author = "Victor Hugo", Genre = "Epic, Historical Fiction", PublishDate = new DateTime(1862, 1, 1), ISBN = "9788526273757", CopiesAvailable = 3 },
            new Book { Id = 3, Title = "Suç ve Ceza", Author = "Fyodor Dostoyevsky", Genre = "Crime", PublishDate = new DateTime(1862, 1, 1), ISBN = "9743526251757", CopiesAvailable = 3 },
            new Book { Id = 4, Title = "Savaş ve Barış", Author = "Leo Tolstoy", Genre = "Historical Fiction, Romance", PublishDate = new DateTime(1862, 1, 1), ISBN = "9786321273757", CopiesAvailable = 3 },
            new Book { Id = 5, Title = "Taht Oyunları", Author = "George R. R. Martin", Genre = "Novel, Fantasy", PublishDate = new DateTime(1862, 1, 1), ISBN = "9788526273757", CopiesAvailable = 3 }
        };


        // GET: /Book/List
        public IActionResult List()
        {
            return View(books);
        }

        // GET: /Book/Details/{id}
        public IActionResult Details(int id)
        {
            var book = books.Find(b => b.Id == id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        // GET: /Book/Create
        public IActionResult Create()
        {
            ViewBag.Owners = AuthorController._authors;
            return View();
        }

        // POST: /Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = books.Max(b => b.Id) + 1;
                book.Author = AuthorController._authors.First(a => a.Id == int.Parse(book.Author)).FullName;
                books.Add(book);
                TempData["SuccessMessage"] = "Book was successfully added.";
                
                return RedirectToAction(nameof(List));           
            }
            ViewBag.Owners = AuthorController._authors;
            return View(book);
        }

        // GET: /Book/Edit/{id}
        public IActionResult Edit(int id)
        {
            var book = books.Find(b => b.Id == id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        // POST: /Book/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book updatedBook)
        {
            var book = books.Find(b => b.Id == id);
            if (book == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Genre = updatedBook.Genre;
                book.PublishDate = updatedBook.PublishDate;
                book.ISBN = updatedBook.ISBN;
                book.CopiesAvailable = updatedBook.CopiesAvailable;

                TempData["SuccessMessage"] = "Book was successfully updated.";
                return RedirectToAction(nameof(List));
            }
            return View(updatedBook);
        }

        // GET: /Book/Delete/{id}
        public IActionResult Delete(int id)
        {
            var book = books.Find(b => b.Id == id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        // POST: /Book/DeleteConfirmed/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = books.Find(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
                TempData["SuccessMessage"] = "Book was successfully deleted.";
            }
            return RedirectToAction(nameof(List));
        }
    }
}
