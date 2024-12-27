using UserManagementAPI.Models;

namespace UserManagementAPI.Interfaces
{
    public interface IUserRepository<K, T> where T : class
    {
      
        Task<T> GetUserById(K key);
        Task<ICollection<T>> GetAll();
        Task<T> AddUser(T entity);
        

    }
}
