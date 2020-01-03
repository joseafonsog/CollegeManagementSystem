using CollegeManagementSystem.Core;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CollegeManagmentSystem.Infrastructure.Data
{
    public class CollegeContext : DbContext, ICollegeContext
    {
        public CollegeContext(string connectionString) : base(connectionString) 
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<StudentSubject> StudentSubjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Course>().HasMany(c => c.Subjects).WithRequired(s => s.Course);
            
            modelBuilder.Entity<Subject>().HasRequired(c => c.Course).WithMany(s => s.Subjects);
            modelBuilder.Entity<Subject>().HasRequired(s => s.Teacher);
            modelBuilder.Entity<Subject>().HasMany(s => s.StudentSubjects).WithRequired(ss => ss.Subject);

            modelBuilder.Entity<Teacher>().HasOptional(t => t.Subject);
            
            modelBuilder.Entity<Student>().HasMany(s => s.StudentSubjects).WithRequired(ss => ss.Student);

            modelBuilder.Entity<StudentSubject>().HasKey(ss => new { ss.StudentId, ss.SubjectId });
            modelBuilder.Entity<StudentSubject>().HasRequired(ss => ss.Subject).WithMany(s => s.StudentSubjects);
            modelBuilder.Entity<StudentSubject>().HasRequired(ss => ss.Student).WithMany(s => s.StudentSubjects);
        }
    }
}
