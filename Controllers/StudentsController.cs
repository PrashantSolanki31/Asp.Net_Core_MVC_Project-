using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Week2_Project1.Data;
using MVC_Week2_Project1.Models;

namespace MVC_Week2_Project1.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;
        public StudentsController(AppDbContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public  IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewmodel)
        {
            var student = new Student()
            {
                Name = viewmodel.Name,
                Email = viewmodel.Email,
                Phone = viewmodel.Phone,
                Subscribed = viewmodel.Subscribed,
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

          
            return RedirectToAction("List");
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students =await _context.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var std = await _context.Students.FindAsync(id);

            return View(std);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student studentvm)
        {
            var student = await _context.Students.FindAsync(studentvm.Id);
            if (student != null)
            {
                student.Name = studentvm.Name;
                student.Email = studentvm.Email;
                student.Phone = studentvm.Phone;
                student.Subscribed = studentvm.Subscribed;

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student studentvm)
        {
           var student = await _context.Students.FirstOrDefaultAsync(x=>x.Id == studentvm.Id);
            if (student is not null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }




    }
}
