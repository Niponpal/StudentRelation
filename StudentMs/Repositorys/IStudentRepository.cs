using StudentMs.Models;

namespace StudentMs.Repositorys
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> AddStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task<Student> DeleteStudentAsync(int id);
        Task<Student> GetUrlHandleasync(string urlHandle);
    }
}
