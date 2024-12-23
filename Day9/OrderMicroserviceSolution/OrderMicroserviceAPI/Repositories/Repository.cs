using OrderMicroserviceAPI.Contexts;
using OrderMicroserviceAPI.Interfaces;
using System.Diagnostics;

namespace OrderMicroserviceAPI.Repositories
{
    public abstract class Repository<T, K> : IRepository<T, K> where T : class
    {
        public abstract Task<ICollection<T>> Get();

        public abstract Task<T> Get(K key);

        protected OrderContext _orderContext;

        public async Task<T> Add(T entity)
        {
            _orderContext.Add(entity);//Take the entity asses its type and add it to the respective collection
            Debug.WriteLine(_orderContext.Entry(entity).State);
            _orderContext.SaveChanges();//Save the changes to the database
            return entity;
        }

        public async Task<T> Delete(K key)
        {
            var entity = await Get(key);
            if (entity != null)
            {
                _orderContext.Remove(entity);
                _orderContext.SaveChanges();
                return entity;
            }
            throw new Exception("Entity not found");
        }

        public async Task<T> Update(K key, T entity)
        {
            var myEntity = await Get(key);
            if (myEntity != null)
            {
                _orderContext.Entry(myEntity).CurrentValues.SetValues(entity);
                _orderContext.SaveChanges();
                return myEntity;
            }
            throw new Exception("Entity not found");
        }
    }
}

