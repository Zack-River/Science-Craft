using Microsoft.AspNetCore.Mvc;
using ScienceCraft.DataAccess.Data;
using ScienceCraft.DataAccess.Impl;
using ScienceCraft.Entities.Models;
using ScienceCraft.Entities.Repos;

namespace ScienceCraft.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var courses = _unitOfWork.Course.GetAll();
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
                _unitOfWork.Course.Add(course);
                _unitOfWork.Complete();
                TempData["Create"] = "Course Created Successfully";
                return RedirectToAction("Index");
            }
            return View(course);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var courseInDb = _unitOfWork.Course.GetFirstOrDefault(x => x.Id == id);
            return View(courseInDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Course.Update(course);
                _unitOfWork.Complete();
                TempData["Edit"] = "Course Updated Successfully";
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
            var courseInDb = _unitOfWork.Course.GetFirstOrDefault(x => x.Id == id);
            return View(courseInDb);
        }


        [HttpPost]
        public IActionResult DeleteCourse(int? id)
        {
            var CourseInDb = _unitOfWork.Course.GetFirstOrDefault(x => x.Id == id);
            if (CourseInDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Course.Remove(CourseInDb);
            _unitOfWork.Complete();
            TempData["Delete"] = "Course Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}
