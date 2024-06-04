using BookManager.Data;
using BookManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        private readonly DatabaseContext _context;
        public BookController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Book> bookList = _context.Books;
            return View(bookList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                TempData["SuccessMsg"] = "Book (" + book.AuthorName + ") created Successfully";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Edit(int? bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(book);
                _context.SaveChanges();
                TempData["SuccessMsg"] = "Book (" + book.AuthorName + ") Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(book);
        }
        public IActionResult Delete(int? bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int? bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book == null)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            TempData["SuccessMsg"] = "book (" + book.AuthorName + ") Removed Successfully";
            return RedirectToAction("Index");

        }
    }
}
