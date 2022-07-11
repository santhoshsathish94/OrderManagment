using OrderManagment.API.Models;
using System.Net;

namespace OrderManagment.API
{
    public static class APIResponse
    {
        public static APIResponseModel Success(object data, string status = "success")
        {
            return new APIResponseModel
            {
                Message = HttpStatusCode.OK.ToString(),
                Status = status,
                StatusCode = (int)HttpStatusCode.OK,
                Result = data
            };
        }

        public static APIResponseModel Created(string message = "Created Successfully", string status = "created")
        {
            return new APIResponseModel
            {
                Message = message,
                Status = status,
                StatusCode = (int)HttpStatusCode.Created,
            };
        }
        public static APIResponseModel Updated(string message = "Updated Successfully", string status = "updated")
        {
            return new APIResponseModel
            {
                Message = message,
                Status = status,
                StatusCode = (int)HttpStatusCode.OK,
            };
        }
        public static APIResponseModel Deleted(string message = "Deleted Successfully", string status = "deleted")
        {
            return new APIResponseModel
            {
                Message = message,
                Status = status,
                StatusCode = (int)HttpStatusCode.OK,
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
