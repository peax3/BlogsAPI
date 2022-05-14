
namespace BlogsAPI.Helpers.cs
{
    public class GenericResponse
    {
        public int StatusCode { get; set; }
        //public string Message { get; set; }
        public object Data { get; set; }
    }
}