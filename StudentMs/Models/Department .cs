namespace StudentMs.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public string OfficeLocation { get; set; }
        public string PhoneExtension { get; set; }
        public string HeadOfDepartment { get; set; }
        public int EstablishedYear { get; set; }
        public int NumberOfProfessors { get; set; }
        public string WebsiteUrl { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Course> Courses { get; set; }

    }
}

