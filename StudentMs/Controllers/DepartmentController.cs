using Microsoft.AspNetCore.Mvc;
using StudentMs.Models;
using StudentMs.Repositorys;

namespace StudentMs.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _departmentRepository.GetAllDepartmentsAsync();

            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new Department());
            }
            else
            {
                var data = await _departmentRepository.GetDepartmentByIdAsync(id);
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Department department)
        {
            if (department.Id == 0)
            {
                await _departmentRepository.AddDepartmentAsync(department);
                return RedirectToAction("Index");
            }
            else
            {
                await _departmentRepository.UpdateDepartmentAsync(department);
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _departmentRepository.DeleteDepartmentAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
    }
} 
