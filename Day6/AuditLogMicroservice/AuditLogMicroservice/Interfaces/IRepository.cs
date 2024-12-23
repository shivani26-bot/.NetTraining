namespace AuditLogMicroservice.Interfaces
{


    public interface IRepository<T, K> where T : class
    {
        T Add(T entity);
        ICollection<T> Get();
        T Delete(K key);
    }
}
