namespace DenounceBeasts.API.Models.Dtos
{
    public class ApiResponse<T> //where T : class
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; } 
        public T Data { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, string message = "", int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                StatusCode = statusCode,
                Data = data
            };
        }

        public static ApiResponse<T> ErrorResponse(string message, int statusCode = 500)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                StatusCode = statusCode
            };
        }
    }
}
