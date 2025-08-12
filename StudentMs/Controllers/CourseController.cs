using Microsoft.AspNetCore.Mvc;
using StudentMs.Models;
using StudentMs.Repositorys;

namespace StudentMs.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        private readonly IDepartmentRepository _departmentRepository;
     
        public CourseController(ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _courseRepository.GetAllCoursesAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int? id)
        {
            if (id == null)
            {
                ViewData["DepartmentId"] = _departmentRepository.Dropdown();
                return View(new Course());
            }
            else
            {
                ViewData["DepartmentId"] = _departmentRepository.Dropdown();
                var course = await _courseRepository.GetCourseByIdAsync(id.Value);
                return View(course);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(int id,Course course)
        {

            if (course.Id == 0)
            {
                await _courseRepository.AddCourseAsync(course);
                return RedirectToAction("Index");
            }
            else
            {   
                await _courseRepository.UpdateCourseAsync(course);
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            if (course != null)
            {
                return View(course);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult?> Details(int id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            if (course != null)
            {
                return View(course);
            }
            return RedirectToAction("Index");

        }
    }
}
