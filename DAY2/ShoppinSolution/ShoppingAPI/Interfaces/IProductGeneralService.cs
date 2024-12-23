using ShoppingAPI.Models;

namespace ShoppingAPI.Interfaces
{
    //this is the parent interface, we will have children interface for supplier as well
    public interface IProductGeneralService
    {
        public List<Product> GetProducts(); //common to both customer and  supplier
    }
}
