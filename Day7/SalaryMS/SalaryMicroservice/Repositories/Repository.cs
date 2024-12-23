using Microsoft.AspNetCore.Components.Forms;
using SalaryMicroservice.Contexts;
using SalaryMicroservice.Interfaces;
using System.Diagnostics;

namespace SalaryMicroservice.Repositories
{
    public abstract  class Repository<T, K> : IRepository<T, K> where T : class
    {
        public abstract ICollection<T> Get();
        protected SalaryContext _salaryContext;

        public T Add(T entity)
        {
            _salaryContext.Add(entity);//Take the entity asses its type and add it to the respective collection
            //Debug.WriteLine(_salaryContext.Entry(entity).State);
            _salaryContext.SaveChanges();//Save the changes to the database
            return entity;
        }

        //public T Delete(K key)
        //{
        //    var entity = _auditContext.Find<T>(key);
        //    if (entity != null)
        //    {
        //        _auditContext.Remove(entity);
        //        _auditContext.SaveChanges();
        //        return entity;
        //    }
        //    throw new Exception("Entity not found");
        //}
    }


 
}
