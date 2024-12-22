using Microsoft.AspNetCore.Mvc;
using ScienceCraft.Web.Data;
using ScienceCraft.Web.Models;

namespace ScienceCraft.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null | id == 0)
            {
                return NotFound();
            }
            var categoryInDb = _context.Categories.Find(id);   
            return View(categoryInDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit()
        {
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null | id == 0)
            {
                return NotFound();
            }
            var categoryInDb = _context.Categories.Find(id);
            return View(categoryInDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Course course)
        {
            return View();
        }


    }
}
