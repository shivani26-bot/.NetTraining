using Microsoft.VisualBasic;

namespace ShoppingAPI.Exceptions
{
    public class DuplicateEntityException:Exception
    {
        string msg;
        public DuplicateEntityException() 
        {
           msg = "An entity with the same key already exists in the repository";
        }
        public DuplicateEntityException(string message)
        {
            msg = message;
        }
        public override string Message => msg;
    }
}
