using CollegeManagementSystem.Core;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CollegeManagmentSystem.Infrastructure.Data
{
    public interface ICollegeContext : IDisposable
    {
        DbSet<Course> Courses { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<StudentSubject> StudentSubjects { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
