namespace Todo.DTOs
{
    public class ReturnObject
    {
        public dynamic? Data { get; set; }
        public string? Message { get; set; }

        public ReturnObject(dynamic? value, string message)
        {
            Data = value;
            Message = message;
        }
    }
}
