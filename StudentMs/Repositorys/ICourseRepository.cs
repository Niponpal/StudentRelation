using StudentMs.Models;

namespace StudentMs.Repositorys
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course?> GetCourseByIdAsync(int id);
        Task<Course> AddCourseAsync(Course course);
        Task<Course?> UpdateCourseAsync(Course course);
        Task<bool> DeleteCourseAsync(int id);
        Task<Course> GetUrlHandlAsync(string urlHandle);
       
    }
}
