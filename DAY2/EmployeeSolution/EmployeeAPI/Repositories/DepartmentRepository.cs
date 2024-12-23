using System.Diagnostics;
using EmployeeAPI.Contexts;
using EmployeeAPI.Exceptions;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;

namespace EmployeeAPI.Repositories
{
    public class DepartmentRepository : IDepartmentRepository<Department, int>
    {

        //static IDictionary<int, Department> departments = new Dictionary<int, Department>()
        //{
        //    {1, new Department{DepartmentId =1, DepartmentName = "HR"}},
        //    {2, new Department{ DepartmentId =2, DepartmentName = "IT"}},
        //    {3, new Department{DepartmentId =3, DepartmentName = "SALES"}},
        //    {4, new Department{DepartmentId =4, DepartmentName = "PRODUCT"} },

        //};
        private readonly EmployeeContext _ctx;
        public DepartmentRepository(EmployeeContext ctx)
        {
            _ctx = ctx;
        }
        public Department Add(Department entity)
        {

            _ctx.Departments.Add(entity);//Take the entity asses its type and add it to the respective collection
            //Debug.WriteLine(_ctx.Entry(entity).State);
            _ctx.SaveChanges();//Save the changes to the database
            return entity;
        }

        public ICollection<Department> Get()
        {
            var departments = _ctx.Departments.ToList();
            if (departments.Count == 0)
            {
                throw new RepositoryEmptyException("No products found");
            }
            return departments;
        }

        public Department GetDepartmentById(int id)
        {
            if (id == null)
            {
                throw new Exception("id not found");
            }
            //Id->employeeid

            return _ctx.Departments.FirstOrDefault(e => e.DepartmentId == id);
        }
    }
}
