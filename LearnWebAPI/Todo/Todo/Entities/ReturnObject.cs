namespace Todo.Entities
{
    public class ReturnObject
    {
        public dynamic? Value { get; set; }
        public string? Message { get; set; }

        public ReturnObject(dynamic? value, string message) 
        { 
            Value = value;
            Message = message;
        }
    }
}
