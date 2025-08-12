using Microsoft.AspNetCore.Mvc;
using StudentMs.Models;
using StudentMs.Repositorys;

namespace StudentMs.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
       
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _studentRepository.GetAllStudentsAsync();  
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new Student());
            }
            else
            {
                var data = await _studentRepository.GetStudentByIdAsync(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Student student)
        {
            if (student.Id == 0)
            {
                await _studentRepository.AddStudentAsync(student);
                return RedirectToAction("Index");
            }
            else
            {
                await _studentRepository.UpdateStudentAsync(student);
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _studentRepository.DeleteStudentAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _studentRepository.GetStudentByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);

        }
    }
}
