using Microsoft.EntityFrameworkCore;
using StudentMs.Data;
using StudentMs.Models;

namespace StudentMs.Repositorys
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Student> AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudentAsync(int id)
        {
            var data = await _context.Students.FindAsync(id);
            if (data == null)
            {
                return null;
            }
            _context.Students.Remove(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            var data = await _context.Students.ToListAsync();
            return data;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var data = await _context.Students.FindAsync(id);
            return data;
        }

        public async Task<Student> GetUrlHandleasync(string urlHandle)
        {
            var data = await _context.Students
                 .FirstOrDefaultAsync(s => s.Email == urlHandle); // Assuming Email is used as a unique identifier
            return data;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            var data = await _context.Students.FindAsync(student.Id);
            if (data != null)
            {
                data.Name = student.Name;
                data.Email = student.Email;
                data.EnrollmentDate = student.EnrollmentDate;
                data.PhoneNumber = student.PhoneNumber;
                data.DateOfBirth = student.DateOfBirth;
                data.Address = student.Address;
                data.City = student.City;
                data.Region = student.Region;
                _context.Students.Update(data);
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }
    }
}
