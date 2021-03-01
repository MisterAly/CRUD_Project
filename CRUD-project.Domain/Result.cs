namespace CRUD_project.Domain
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }

        public Result(bool error, string message)
        {
            Error = error;
            Message = message;
        }

        public Result(T data, bool error, string message)
        {
            Data = data;
            Error = error;
            Message = message;
        }
    }
    
}
