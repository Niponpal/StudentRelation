namespace StudentMs.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public string Description { get; set; }
        public string CourseCode { get; set; }
        public string Semester { get; set; }
        public int MaxStudents { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsElective { get; set; }

        public int DepartmentId { get; set; }

        // Navigation property
        public Department Department { get; set; }
    }
}



