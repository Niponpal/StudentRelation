using Microsoft.AspNetCore.Mvc.Rendering;
using StudentMs.Models;

namespace StudentMs.Repositorys
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<Department> AddDepartmentAsync(Department department);
        Task<Department> UpdateDepartmentAsync(Department department);
        Task<Department> DeleteDepartmentAsync(int id);
        Task<Department> GetUrlHandleasync(string urlHandle);
        IEnumerable<SelectListItem> Dropdown();

        // This method returns a list of departments for dropdowns in views

        //  This can use this method Department and Course table relationship
       // IEnumerable<SelectListItem> Dropdowns();
    }
}
