using BookManager.Models;
using BookManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    public class AuthorController : Controller
    {
        private readonly DatabaseContext _context;
        public AuthorController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Author> authorList = _context.Authors;
            return View(authorList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Add(author);
                _context.SaveChanges();
                TempData["SuccessMsg"] = "Author (" + author.AuthoName + ") Added Successfully";
                return RedirectToAction("Index");
            }
            return View(author);
        }

        public IActionResult Edit(int? authorId)
        {
            var author = _context.Authors.Find(authorId);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Update(author);
                _context.SaveChanges();
                TempData["SuccessMsg"] = "Author (" + author.AuthoName + ") Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(author);
        }
        public IActionResult Delete(int? authorId)
        {
            var author = _context.Authors.Find(authorId);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAuthor(int? authorId)
        {
            var author = _context.Authors.Find(authorId);
            if (author == null)
            {
                return NotFound();
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
            TempData["SuccessMsg"] = "Author (" + author.AuthoName + ") Removed Successfully";
            return RedirectToAction("Index");

        }
    }
}
