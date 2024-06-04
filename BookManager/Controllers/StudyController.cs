using BookManager.Models;
using BookManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    public class StudyController : Controller
    {
        private readonly DatabaseContext _context;
        public StudyController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Study> studyList = _context.Studies;
            return View(studyList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Study study)
        {
            if (ModelState.IsValid)
            {
                _context.Studies.Add(study);
                _context.SaveChanges();
                TempData["SuccessMsg"] = "Study (" + study.AuthorName + ") Added Successfully";
                return RedirectToAction("Index");
            }
            return View(study);
        }

        public IActionResult Edit(int? studyId)
        {
            var study = _context.Studies.Find(studyId);
            if (study == null)
            {
                return NotFound();
            }
            return View(study);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Study study)
        {
            if (ModelState.IsValid)
            {
                _context.Studies.Update(study);
                _context.SaveChanges();
                TempData["SuccessMsg"] = "Author (" + study.AuthorName + ") Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(study);
        }
        public IActionResult Delete(int? studyId)
        {
            var study = _context.Studies.Find(studyId);
            if (study == null)
            {
                return NotFound();
            }
            return View(study);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAuthor(int? studyId)
        {
            var study = _context.Studies.Find(studyId);
            if (study == null)
            {
                return NotFound();
            }
            _context.Studies.Remove(study);
            _context.SaveChanges();
            TempData["SuccessMsg"] = "Author (" + study.AuthorName + ") Removed Successfully";
            return RedirectToAction("Index");

        }
    }
}
