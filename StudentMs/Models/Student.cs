namespace StudentMs.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }


        // Foreign key to Department
        public int DepartmentId { get; set; }

        // Navigation property
        public Department Department { get; set; }
    }
}

