using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace sweeft_7
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Subject { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
    public class SchoolContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasMany<Student>(t => t.Students)
                .WithMany(s => s.Teachers)
                .Map(ts =>
                {
                    ts.MapLeftKey("TeacherId");
                    ts.MapRightKey("StudentId");
                    ts.ToTable("TeacherStudent");
                });
        }
    }

    internal class Program
    {
        public Teacher[] GetAllTeachersByStudent(string studentName)
        {
            using (var context = new SchoolContext())
            {
                return context.Teachers
                    .Where(t => t.Students.Any(s => s.FirstName == studentName))
                    .ToArray();
            }
        }
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                var student1 = new Student { FirstName = "George", LastName = "Smith", Gender = "Male", Class = "10A" };
                var student2 = new Student { FirstName = "Emily", LastName = "Jones", Gender = "Female", Class = "10A" };

                var teacher1 = new Teacher { Name = "John", Surname = "Doe", Gender = "Male", Subject = "Math", Students = new List<Student> { student1, student2 } };
                var teacher2 = new Teacher { Name = "Mary", Surname = "Smith", Gender = "Female", Subject = "English", Students = new List<Student> { student1 } };

                context.Students.Add(student1);
                context.Students.Add(student2);
                context.Teachers.Add(teacher1);
                context.Teachers.Add(teacher2);

                context.SaveChanges();

                var teachers = GetAllTeachersByStudent("George");
                foreach (var teacher in teachers)
                {
                    Console.WriteLine("{0} {1} teaches {2}", teacher.Name, teacher.Surname, teacher.Subject);
                }
            }
        }
    }
}
