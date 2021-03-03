namespace CRUD_project.Domain
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }

        public Result(bool error, string message)
        {
            IsValid = error;
            Message = message;
        }

        public Result(T data, bool error, string message)
        {
            Data = data;
            IsValid = error;
            Message = message;
        }
    }
    
}
