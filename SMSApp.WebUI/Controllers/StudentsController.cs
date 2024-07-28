using Microsoft.AspNetCore.Mvc;
using SMSApp.DAL.Data;
using SMSApp.DAL.Models;

namespace SMSApp.WebUI.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SmsDbContext _context;

        public StudentsController(SmsDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            if (students.Any())
            {
                ViewBag.HasData = true;
            }
            else
            {
                ViewBag.HasData = false;
                ViewBag.Message = "Sistemde hec bir telebe yoxdur";
                ViewData["Message"] = "Hec bir telebenin sistemde qeydiyyati movcud deyildir";
            }

            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.UpdateDate = DateTime.Now;
                _context.Students.Add(model);
                _context.SaveChanges();
                TempData["Success"] = "Telebe basarili bir sekilde qeydiyyat edildi";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student model)
        {
            if (ModelState.IsValid)
            {
                model.UpdateDate = DateTime.Now;
                _context.Students.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);

       
            return View(student);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var student = _context.Students.Find(id);
            if (student is not null)
            {
                _context.Remove(student);
                _context.SaveChanges() ;
                return RedirectToAction("Index");

            }
            return RedirectToAction("Delete", new { id});
        }
    }
}
