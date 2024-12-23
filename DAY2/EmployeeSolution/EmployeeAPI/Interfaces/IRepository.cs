namespace EmployeeAPI.Interfaces
{
    public interface IRepository<T, K> where T : class
    {
        T Add(T entity);
        ICollection<T> Get();
        //T Get(K key);

        T GetEmployeeById(K key);
        T Update(K key, T entity); // for given id we will update
        T UpdateEmployee(T entity);
        //T Delete(K key);
    }
}
