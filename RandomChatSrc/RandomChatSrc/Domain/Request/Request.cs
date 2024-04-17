using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Domain.RequestDomain
{
    public class Request
    {
        public Guid RequestId { get; set; }
        public Guid SenderUserId { get; set; }
        public Guid ReceiverUserId { get; set; }
        public string RequestPath { get; set; }

        public Request(Guid requestId, Guid senderUserId, Guid receiverUserId, string requestPath)
        {
            this.RequestId = requestId;
            this.SenderUserId = senderUserId;
            this.ReceiverUserId = receiverUserId;
            this.RequestPath = requestPath;
        }
    }
}
