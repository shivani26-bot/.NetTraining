namespace OrderMicroserviceAPI.Interfaces
{
    public interface IRepository<T, K> where T : class
    {
        Task<T> Add(T entity);
        Task<ICollection<T>> Get();
        Task<T> Get(K key);
        Task<T> Update(K key, T entity);
        Task<T> Delete(K key);
    }
}
