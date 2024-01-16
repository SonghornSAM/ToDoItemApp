using Newtonsoft.Json;
using System.ComponentModel;

namespace ToDoItemApi.Helpers
{
    public class BaseDataModel
    {
        public class ApiResponse<T> where T : IResponse
        {
            private T _data;
            private ApiReturnError _errCode = ApiReturnError.GeneralError;

            public ApiResponse()
            {
            }

            public ApiResponse(T data)
            {
                _data = data;
                _errCode = (ApiReturnError)data.ErrorCode;
            }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

            public ApiReturnError ErrorCode
            {
                get => _errCode != ApiReturnError.GeneralError ? _errCode : _data == null || (ApiReturnError)_data.ErrorCode != ApiReturnError.Success ? (ApiReturnError)_data.ErrorCode : _errCode;
                set => _errCode = value;
            }

            public string Message => ErrorCode.ToString();
        }
        public class BaseResponse : IResponse
        {
            public BaseResponse CreateSuccessResponse()
            {
                return new BaseResponse
                {
                    ErrorCode = 0,
                    ErrorMessage = String.Empty
                };
            }
            public BaseResponse()
            {
            }

            public BaseResponse(int errorCode)
            {
                ErrorCode = errorCode;
            }

            public int ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
            public bool IsSuccess => ErrorCode == 0;
            public bool ShouldSerializeErrorCode()
            {
                //Will serialize property "ProductType" if SerializeSensitiveInfo == true
                return false;
            }
            public bool ShouldSerializeErrorMessage()
            {
                //Will serialize property "GameType" if SerializeSensitiveInfo == true
                return false;
            }
        }
        public interface IResponse
        {
            int ErrorCode { get; set; }
            string ErrorMessage { get; set; }
        }

        public class BaseDateRange
        {
            public DateTime StartDate { get; set; }

            public DateTime EndDate
            {
                get => _endDate;
                set => _endDate = value > StartDate ? value : StartDate;
            }
            private DateTime _endDate { get; set; }
        }
    }
}
