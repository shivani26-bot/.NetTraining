namespace EmployeeAPI.Exceptions
{
    public class RepositoryEmptyException : Exception
    {
        string msg;
        public RepositoryEmptyException()
        {
            msg = "The repository is empty";
        }
        public RepositoryEmptyException(string message)
        {
            msg = message;
        }
        public override string Message => msg;
    }
}
