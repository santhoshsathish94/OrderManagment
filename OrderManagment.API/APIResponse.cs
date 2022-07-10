using OrderManagment.API.Models;
using System.Net;

namespace OrderManagment.API
{
    public static class APIResponse
    {
        public static APIResponseModel Success(object data, HttpStatusCode statusCode = HttpStatusCode.OK, string status = "ok")
        {
            return new APIResponseModel
            {
                Message = statusCode.ToString(),
                Status = status,
                StatusCode = (int)statusCode,
                Result = data
            };
        }

        public static APIResponseModel Created(string msg = "Created Successfully", HttpStatusCode statusCode = HttpStatusCode.Created, string status = "ok")
        {
            return new APIResponseModel
            {
                Message = msg,
                Status = status,
                StatusCode = (int)statusCode,
            };
        }
        public static APIResponseModel Updated(string msg = "Updated Successfully", HttpStatusCode statusCode = HttpStatusCode.OK, string status = "ok")
        {
            return new APIResponseModel
            {
                Message = msg,
                Status = status,
                StatusCode = (int)statusCode,
            };
        }
        public static APIResponseModel Deleted(string msg = "Deleted Successfully", HttpStatusCode statusCode = HttpStatusCode.OK, string status = "ok")
        {
            return new APIResponseModel
            {
                Message = msg,
                Status = status,
                StatusCode = (int)statusCode,
            };
        }

        public static APIResponseModel Error(object errorMsg = null, HttpStatusCode statusCode = HttpStatusCode.InternalServerError, object data = null, string status = "error")
        {
            return new APIResponseModel
            {
                Message = statusCode.ToString(),
                Status = status,
                StatusCode = (int)statusCode,
                Result = data,
                ErrorMessage = errorMsg
            };
        }

        public static APIResponseModel BadRequest(object errorMsg, HttpStatusCode statusCode = HttpStatusCode.BadRequest, object data = null, string status = "error")
        {
            return new APIResponseModel
            {
                Message = statusCode.ToString(),
                Status = status,
                StatusCode = (int)statusCode,
                Result = data,
                ErrorMessage = errorMsg
            };
        }

        public static APIResponseModel ExpectationFailed(object errorMsg, HttpStatusCode statusCode = HttpStatusCode.ExpectationFailed, object data = null, string status = "error")
        {
            return new APIResponseModel
            {
                Message = statusCode.ToString(),
                Status = status,
                StatusCode = (int)statusCode,
                Result = data,
                ErrorMessage = errorMsg
            };
        }

        public static APIResponseModel NoContent(object errorMsg, HttpStatusCode statusCode = HttpStatusCode.NoContent, object data = null, string status = "error")
        {
            return new APIResponseModel
            {
                Message = statusCode.ToString(),
                Status = status,
                StatusCode = (int)statusCode,
                Result = data,
                ErrorMessage = errorMsg
            };
        }
    }
}
