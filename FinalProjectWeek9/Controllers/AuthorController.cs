using FinalProjectWeek9.Models;
using FinalProjectWeek9.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWeek9.Controllers
{
    public class AuthorController : Controller
    {
        // Static list of authors
        public static List<AuthorViewModel> _authors = new List<AuthorViewModel>
            {
                new AuthorViewModel { Id = 1, FirstName = "Victor", LastName = "Hugo", DateOfBirth = new DateTime(1802, 2, 26) },
                new AuthorViewModel { Id = 2, FirstName = "Adam", LastName = "Fawer", DateOfBirth = new DateTime(1970, 5, 5) },
                new AuthorViewModel { Id = 3, FirstName = "Fyodor", LastName = "Dostoyevsky", DateOfBirth = new DateTime(1821, 11, 11) },
                new AuthorViewModel { Id = 4, FirstName = "Lev", LastName = "Tolstoy", DateOfBirth = new DateTime(1828, 9, 9) },
                new AuthorViewModel { Id = 5, FirstName = "George R. R.", LastName = "Martin", DateOfBirth = new DateTime(1948, 9, 20) }
            };

        // GET: /Author/List
        public IActionResult List()
        {
            return View(_authors);
        }

        // GET: /Author/Details/{id}
        public IActionResult Details(int id)
        {
            var author = GetAuthorById(id);
            if (author == null)
                return NotFound();

            return View(author);
        }

        // GET: /Author/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AuthorViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Assign new ID and add to the list
            model.Id = _authors.Any() ? _authors.Max(a => a.Id) + 1 : 1;
            _authors.Add(model);

            TempData["SuccessMessage"] = "Author was successfully added.";
            return RedirectToAction("List");
        }

        // GET: /Author/Edit/{id}
        public IActionResult Edit(int id)
        {
            var author = GetAuthorById(id);
            if (author == null)
                return NotFound();

            return View(author);
        }

        // POST: /Author/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, AuthorViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var author = GetAuthorById(id);
            if (author == null)
                return NotFound();

            // Update author information
            author.FirstName = model.FirstName;
            author.LastName = model.LastName;
            author.DateOfBirth = model.DateOfBirth;

            TempData["SuccessMessage"] = "Author was successfully updated.";
            return RedirectToAction("List");
        }

        // GET: /Author/Delete/{id}
        public IActionResult Delete(int id)
        {
            var author = GetAuthorById(id);
            if (author == null)
                return NotFound();

            return View(author);
        }

        // POST: /Author/DeleteConfirmed/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = GetAuthorById(id);
            if (author == null)
                return NotFound();

            // Remove author from the list
            _authors.Remove(author);

            TempData["SuccessMessage"] = "Author was successfully deleted.";
            return RedirectToAction("List");
        }

        // Helper method to get author by ID
        private AuthorViewModel GetAuthorById(int id)
        {
            return _authors.Find(a => a.Id == id);
        }
    }
}
