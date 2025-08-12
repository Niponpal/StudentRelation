using Microsoft.EntityFrameworkCore;
using StudentMs.Models;

namespace StudentMs.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Students)
                .WithOne(s => s.Department)
                .HasForeignKey(s => s.DepartmentId);

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Department>()
          .HasMany(d => d.Courses)
         .WithOne(c => c.Department)
         .HasForeignKey(c => c.DepartmentId);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
