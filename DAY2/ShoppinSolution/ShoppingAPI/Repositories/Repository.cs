using ShoppingAPI.Contexts;
using ShoppingAPI.Exceptions;
using ShoppingAPI.Interfaces;
using System.Diagnostics;

namespace ShoppingAPI.Repositories
{
    //public class Repository
    //{
    //}

    public abstract class Repository<T, K> : IRepository<T, K> where T : class
    {
        public abstract ICollection<T> Get();

        public abstract T Get(K key);

        protected ShoppingContext _shoppingContext;

        public T Add(T entity)
        {
            _shoppingContext.Add(entity);//Take the entity asses its type and add it to the respective collection
            Debug.WriteLine(_shoppingContext.Entry(entity).State);
            _shoppingContext.SaveChanges();//Save the changes to the database
            return entity;
        }

        public T Delete(K key)
        {
            var entity = Get(key);
            if (entity != null)
            {
                _shoppingContext.Remove(entity);
                _shoppingContext.SaveChanges();
                return entity;
            }
            throw new EntityNotFoundException("Entity not found");
        }

        public T Update(K key, T entity)
        {
            var myEntity = Get(key);
            if (myEntity != null)
            {
                _shoppingContext.Entry(myEntity).CurrentValues.SetValues(entity);
                _shoppingContext.SaveChanges();
                return myEntity;
            }
            throw new EntityNotFoundException("Entity not found");
        }
    }

}
