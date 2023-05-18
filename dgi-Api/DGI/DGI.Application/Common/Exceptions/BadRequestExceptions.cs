using Response = DGI.Application.Common.BaseResponse.BaseResponse;

namespace DGI.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public Response Response { get; }

        public BadRequestException(string message)
            : base(message)
        {
            Response = Response.BadRequest(message);
        }
    }
}
