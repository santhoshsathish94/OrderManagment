namespace OrderManagment.API.Models
{
    public class APIResponseModel
    {
        public string Status { get; set; }
        public int StatusCode { get; set; }     
        public object Result { get; set; }
        public string Message { get; set; }
        public object ErrorMessage { get; set; }
    }
}
