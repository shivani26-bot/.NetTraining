using EmployeeAPI.Models;

namespace EmployeeAPI.Interfaces
{
    public interface IDepartmentRepository<T, K> where T : class
    {
        ICollection<T> Get();
        T GetDepartmentById(K key);
        //T Get(K key);

        T Add(T entity);
        //T Update(K key, T entity);
        //Department Add(string departmentName);
    }
}
