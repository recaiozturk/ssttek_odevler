using System.Net;
using System.Text.Json.Serialization;

namespace Sample.Api.Models
{
    public class ServiceResult
    {
        public List<string>? Errors { get; set; }


        [JsonIgnore] public bool IsSuccess => Errors is null || Errors.Count == 0;
        [JsonIgnore] public bool IsFail => !IsSuccess;

        [JsonIgnore] public HttpStatusCode Status { get; set; }

        public static ServiceResult Success(HttpStatusCode status)
        {
            return new ServiceResult() { Status = status };
        }

        public static ServiceResult Fail(List<string> errors, HttpStatusCode status)
        {
            return new ServiceResult
            {
                Errors = errors,
                Status = status
            };
        }

        public static ServiceResult Fail(string error, HttpStatusCode status)
        {
            return new ServiceResult
            {
                Errors = [error],
                Status = status
            };
        }
    }


    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }


        public static ServiceResult<T> Success(T data, HttpStatusCode status)
        {
            return new ServiceResult<T>
            {
                Data = data,
                Status = status
            };
        }


        public new static ServiceResult<T> Fail(List<string> errors, HttpStatusCode status)
        {
            return new ServiceResult<T>
            {
                Errors = errors,
                Status = status
            };
        }

        public new static ServiceResult<T> Fail(string error, HttpStatusCode status)
        {
            return new ServiceResult<T>
            {
                Errors = [error],
                Status = status
            };
        }
    }
}
