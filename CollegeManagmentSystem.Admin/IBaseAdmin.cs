using CollegeManagementSystem.Core;
using System.Collections.Generic;

namespace CollegeManagmentSystem.Admin
{
    public interface IBaseAdmin<T> where T : BaseEntity
    {
        IList<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
