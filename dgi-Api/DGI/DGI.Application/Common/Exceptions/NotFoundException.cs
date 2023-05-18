using Response = DGI.Application.Common.BaseResponse.BaseResponse;

namespace DGI.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public Response Response { get; }

        public NotFoundException(string entityName, string id)
          : base($"{entityName} with id {id} not found")
        {
            Response = Response.NotFound(Message);
        }
    }
}
