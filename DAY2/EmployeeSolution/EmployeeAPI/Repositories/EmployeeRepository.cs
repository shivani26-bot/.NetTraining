using System.Diagnostics;
using EmployeeAPI.Contexts;
using EmployeeAPI.Exceptions;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;

namespace EmployeeAPI.Repositories
{
  

    public class EmployeeRepository : IRepository<Employee, int>
    {
        //static IDictionary<int, Employee> employees = new Dictionary<int, Employee>()
        //{
        //    {101, new Employee{Id = 101, Name = "Aditya", Age = 30,     PhoneNumber="9873489344", Salary=50000}},
        //    {102, new Employee{Id = 102, Name = "Payal", Age = 28,       PhoneNumber="9873435364", Salary=40000}},
        //    {103, new Employee{Id = 103, Name = "Pranay", Age = 35,    PhoneNumber="9866689347", Salary=80000}},
        //    {104, new Employee{Id = 104, Name = "Kavita", Age = 32,  PhoneNumber="9879999341", Salary=70000} },
        //    {105, new Employee{Id = 105, Name = "Reema", Age = 25, PhoneNumber="9873489234", Salary=90000 } }
        //};
        //public Employee Add(Employee entity)
        //{
        //    if (employees.Values.Contains(entity))
        //    {
        //        throw new DuplicateEntityException("Product already exists in the repository");
        //    }
        //    int pid = GenerateEmployeeID();
        //    entity.Id = pid;
        //    employees.Add(pid, entity);
        //    return entity;
        //}


        //private int GenerateEmployeeID()
        //{
        //    if (employees.Count == 0)
        //    {
        //        return 101;
        //    }
        //    return employees.Keys.Max() + 1;
        //}

        //public Employee Delete(int key)
        //{
        //    var employee = Get(key);
        //    if (employee == null)
        //    {
        //        throw new EntityNotFoundException("Product not found in the repository");
        //    }
        //    employees.Remove(key);
        //    return employee;
        //}

        private readonly EmployeeContext _ctx;
        public EmployeeRepository(EmployeeContext ctx)
        {
            _ctx = ctx;
        }

        public Employee Add(Employee entity)
        {
            _ctx.Add(entity);//Take the entity asses its type and add it to the respective collection
            //Debug.WriteLine(_shoppingContext.Entry(entity).State);
            _ctx.SaveChanges();//Save the changes to the database
            return entity;
        }

        public ICollection<Employee> Get()
        {
            var employees = _ctx.Employees.ToList();
            if (employees.Count == 0)
            {
                throw new RepositoryEmptyException("No products found");
            }
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            //Id->employeeid
            return _ctx.Employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(int key, Employee entity)
        {
            var myEntity = GetEmployeeById(key);
            if (myEntity != null)
            {
                _ctx.Entry(myEntity).CurrentValues.SetValues(entity);
                _ctx.SaveChanges();
                return myEntity;
            }
            throw new EntityNotFoundException("Entity not found");
        }

        public Employee UpdateEmployee(Employee entity)
        {
            _ctx.Employees.Update(entity);
            _ctx.SaveChanges();
            return entity;
        }
        //public Employee Get(int key)
        //{
        //    Employee? employee = employees.Keys.Contains(key) ? employees[key] : null;
        //    if (employee == null)
        //    {
        //        throw new EntityNotFoundException("Product not found in the repository");
        //    }
        //    return employee;
        //}

        //public Employee Update(int key, Employee entity)
        //{
        //    var employee = Get(key);
        //    if (employee == null)
        //    {
        //        throw new EntityNotFoundException("Product not found in the repository");
        //    }
        //    employees[key] = entity;
        //    return entity;
        //}
    }
    //    public ICollection<Employee> Get()
    //    {
    //        if (employees.Count == 0)
    //        {
    //            throw new RepositoryEmptyException("No products found in the repository");
    //        }
    //        return employees.Values;
    //    }

    //    public Employee Get(int key)
    //    {
    //        Employee? employee = employees.Keys.Contains(key) ? employees[key] : null;
    //        if (employee == null)
    //        {
    //            throw new EntityNotFoundException("Product not found in the repository");
    //        }
    //        return employee;
    //    }

    //    public Employee Update(int key, Employee entity)
    //    {
    //        var employee = Get(key);
    //        if (employee == null)
    //        {
    //            throw new EntityNotFoundException("Product not found in the repository");
    //        }
    //        employees[key] = entity;
    //        return entity;
    //    }
    //}
}
