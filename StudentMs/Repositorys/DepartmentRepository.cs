using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentMs.Data;
using StudentMs.Models;

namespace StudentMs.Repositorys
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Department> AddDepartmentAsync(Department department)
        {
              await _context.Departments.AddAsync(department);
              await _context.SaveChangesAsync();
              return department;
        }

        public async Task<Department> DeleteDepartmentAsync(int id)
        {
           var data = await _context.Departments.FindAsync(id);
              if (data == null)
              {
                return null; // or throw an exception
              }
              _context.Departments.Remove(data);
                await _context.SaveChangesAsync();
                return data;
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
            var data = _context.Departments.Select(x => new SelectListItem
            {
                Text = x.HeadOfDepartment,
                Value = x.Id.ToString()
            }).ToList();
            return data;
        }

     

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
           var data = await _context.Departments.ToListAsync();
            return data;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var data = await _context.Departments.FindAsync(id);
            return data;
        }

        public async Task<Department> GetUrlHandleasync(string urlHandle)
        {
           var data = await _context.Departments
                .FirstOrDefaultAsync(d => d.WebsiteUrl == urlHandle);
            return data;
        }

        public async Task<Department> UpdateDepartmentAsync(Department department)
        {
           var data = await _context.Departments.FindAsync(department.Id);
            if (data == null)
            {
                return null; // or throw an exception
            }
            data.Name = department.Name;
            data.Budget = department.Budget;
            data.OfficeLocation = department.OfficeLocation;
            data.PhoneExtension = department.PhoneExtension;
            data.HeadOfDepartment = department.HeadOfDepartment;
            data.EstablishedYear = department.EstablishedYear;
            data.NumberOfProfessors = department.NumberOfProfessors;
            data.WebsiteUrl = department.WebsiteUrl;
            data.IsActive = department.IsActive;
            _context.Departments.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
