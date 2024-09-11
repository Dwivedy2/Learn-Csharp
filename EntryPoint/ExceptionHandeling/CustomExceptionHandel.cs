namespace EntryPoint.ExceptionHandeling
{
    public class CustomExceptionHandel : Exception
    {
        public string CustomMessage;
        public CustomExceptionHandel(string ErrorMessage) 
        {
            CustomMessage = ErrorMessage;
        }
    }
}
