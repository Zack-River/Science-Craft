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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
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
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var courseInDb = _context.Courses.Find(id);   
            return View(courseInDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Update(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var CourseInDb = _context.Courses.Find(id);
            if (CourseInDb == null)
            {
                return NotFound();
            }
            return View(CourseInDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCourse(int? id)
        {
            var CourseInDb = _context.Courses.Find(id);
            if (CourseInDb == null)
            {
                NotFound();
            }
            _context.Courses.Remove(CourseInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var CourseInDb = _context.Courses.Find(id);
            if (CourseInDb == null)
            {
                return NotFound();
            }
            return View(CourseInDb);
        }

    }
}
