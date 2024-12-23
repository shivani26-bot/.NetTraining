namespace ShoppingAPI.Exceptions
{
    public class EntityNotFoundException:Exception
    {

        string msg;
        public EntityNotFoundException()
        {
            msg = "The repository is empty";
        }
        public EntityNotFoundException(string message)
        {
            msg = message;
        }
        public override string Message => msg;
    }
}
