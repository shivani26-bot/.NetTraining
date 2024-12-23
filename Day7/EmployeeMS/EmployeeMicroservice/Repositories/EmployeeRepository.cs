using EmployeeMicroservice.Contexts;
using EmployeeMicroservice.Interfaces;
using EmployeeMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMicroservice.Repositories
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee entity)
        {
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

      

        public async Task<IEnumerable<Employee>> GetAll()
        {
            if (_context.Employees.Any())
            {
                return await _context.Employees.ToListAsync();
            }
            throw new Exception("No products found");
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(p => p.EId == id);
            if (employee == null)
                throw new Exception("No Product found with the given id");
            return employee;
        }

        //public async Task<Product> Update(Product entity)
        //{
        //    var product = await GetById(entity.Id);
        //    if (product != null)
        //    {
        //        _context.Products.Update(entity);
        //        await _context.SaveChangesAsync();
        //        return entity;
        //    }
        //    throw new Exception("No Product found with the given id");
        //}
        //public async Task<Product> Delete(int id)
        //{
        //    var product = await GetById(id);
        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();
        //    return product;
        //}
    }
}
