using AuditLogMicroservice.Contexts;
using AuditLogMicroservice.Interfaces;
using System.Diagnostics;

namespace AuditLogMicroservice.Repositories
{

    public abstract class Repository<T, K> : IRepository<T, K> where T : class
    {
        public abstract ICollection<T> Get();

        protected AuditContext _auditContext;

        public T Add(T entity)
        {
            _auditContext.Add(entity);//Take the entity asses its type and add it to the respective collection
            Debug.WriteLine(_auditContext.Entry(entity).State);
            _auditContext.SaveChanges();//Save the changes to the database
            return entity;
        }

        public T Delete(K key)
        {
            var entity = _auditContext.Find<T>(key);
            if (entity != null)
            {
                _auditContext.Remove(entity);
                _auditContext.SaveChanges();
                return entity;
            }
            throw new Exception("Entity not found");
        }


    }
}
