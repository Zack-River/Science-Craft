using Microsoft.AspNetCore.Mvc;
using ScienceCraft.Entities.Models;
using ScienceCraft.Entities.Viewmodels;
using ScienceCraft.Entities.Repos;

namespace ScienceCraft.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SessionController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public SessionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(int? id)
        {
            CourseSessions cs = new CourseSessions()
            {
                course = _unitOfWork.Course.GetFirstOrDefault(x => x.Id == id),
                Sessions = _unitOfWork.Session.GetAll().Where(x => x.CourseId == id)
            };
            
            return View(cs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Session session)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Session.Add(session);
                _unitOfWork.Complete();
                TempData["Create"] = "Session Created Successfully";
                return RedirectToAction("Index");
            }
            return View(session);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var courseInDb = _unitOfWork.Session.GetFirstOrDefault(x => x.Id == id);
            return View(courseInDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Session session)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Session.Update(session);
                _unitOfWork.Complete();
                TempData["Edit"] = "Session Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(session);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var courseInDb = _unitOfWork.Session.GetFirstOrDefault(x => x.Id == id);
            return View(courseInDb);
        }


        [HttpPost]
        public IActionResult DeleteCourse(int? id)
        {
            var SessionInDb = _unitOfWork.Session.GetFirstOrDefault(x => x.Id == id);
            if (SessionInDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Session.Remove(SessionInDb);
            _unitOfWork.Complete();
            TempData["Delete"] = "Session Deleted Successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var SessionInDb = _unitOfWork.Session.GetFirstOrDefault(x => x.Id == id);
            if (SessionInDb == null)
            {
                return NotFound();
            }
            return View(SessionInDb);
        }
    }
}
