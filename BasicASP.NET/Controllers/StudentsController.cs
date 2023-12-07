using BasicASP.NET.Data;
using BasicASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicASP.NET.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDBContext _db;

        public StudentsController(ApplicationDBContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            Response.Headers.Add("Content-Type", "text/html; charset=utf-8");
            IEnumerable<Student> AllStudents = _db.Students;
            return View(AllStudents);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Edit(int? id)
        {
            Response.Headers.Add("Content-Type", "text/html; charset=utf-8");
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Students.Find(id);
                if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student obj)
        {

            if (ModelState.IsValid)
            {
                _db.Students.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //ส่วนหการค้นข้อมูลในdb
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Students.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
