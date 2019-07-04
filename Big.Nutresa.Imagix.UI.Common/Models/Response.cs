using System.Collections.Generic;

namespace Big.Nutresa.Imagix.UI.Common.Models
{
    public class Response<T>
    {
        public bool Status { get; set; }
        public List<MessageResult> Message { get; set; }

        public T ObjectResponse { get; set; }
        public Response()
        {
            Message = new List<MessageResult>();
        }
    }
    public class MessageResult
    {
        public string Message { get; set; }

    }
}
