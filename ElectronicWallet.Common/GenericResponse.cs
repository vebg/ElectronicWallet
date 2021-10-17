namespace ElectronicWallet.Common
{
    public class GenericResponse
    {
        public bool Success { get; set; }

        public string[] Errors { get; set; }
        public string Message { get; set; }


        public GenericResponse(bool success = true,string message = "", string[] errors = null)
        {
            Success = success;
            Message = message;
            Errors = errors;
        }
    }

    public class GenericResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }

        public string[] Errors { get; set; }
        public string Message { get; set; }

        public GenericResponse(T data, bool success = true, string message = "", string[] errors = null)
        {
            Success = success;
            Message = message;
            Errors = errors;
            Data = data;
        }

        public GenericResponse(bool success = true, string message = "", string[] errors = null)
        {
            Success = success;
            Message = message;
            Errors = errors;
        }

    }
}
