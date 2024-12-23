namespace ProductMicroservice.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        public Task<IEnumerable<T>> GetAll(); //we are testing getall and add methods
        public Task<T> GetById(K id);
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<T> Delete(K id);
    }
}
