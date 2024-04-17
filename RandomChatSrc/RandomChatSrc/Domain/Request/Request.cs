using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Domain.RequestDomain
{
    public class Request
    {
        public Guid SenderUserId { get; set; }
        public Guid ReceiverUserId { get; set; }
        public string requestPath;

        public Request(Guid senderUserId, Guid receiverUserId, string requestPath)
        {
            this.SenderUserId = senderUserId;
            this.ReceiverUserId = receiverUserId;
            this.requestPath = requestPath;
        }
    }
}
