using Microsoft.EntityFrameworkCore;
using StudentMs.Data;
using StudentMs.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentMs.Repositorys
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
      
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
           await _context.Courses.AddAsync(course);
              await _context.SaveChangesAsync();
              return course;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
          var data = await _context.Courses.FindAsync(id);
           
            if(data !=null)
            {
                _context.Courses.Remove(data);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
           var courses = await _context.Courses.ToListAsync();
           return courses;
        }

        public async Task<Course?> GetCourseByIdAsync(int id)
        {
           var course =  await _context.Courses.FindAsync(id);
           return course;
        }

        public async Task<Course> GetUrlHandlAsync(string urlHandle)
        {
           var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseCode == urlHandle);
            return course;
        }

        public async Task<Course?> UpdateCourseAsync(Course course)
        {
            var data = await _context.Courses.FindAsync(course.Id);
           if(data == null)
           {
               return null; // or throw an exception
            }
            data.Title = course.Title;
            data.Description = course.Description;
            data.CourseCode = course.CourseCode;
            data.StartDate = course.StartDate;
            data.Title = data.Title;
            data.Credits = data.Credits;
            data.Description = data.Description;
            data.CourseCode = data.CourseCode;
            data.Semester = data.Semester;
            data.MaxStudents = data.MaxStudents;
            data.StartDate = data.StartDate;
            data.IsElective = data.IsElective;
            _context.Courses.Update(data);
            await _context.SaveChangesAsync();
            return data;

        }
        public Task UpdateCourseAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

