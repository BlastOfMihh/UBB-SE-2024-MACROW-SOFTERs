using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Repository;
using RandomChatSrc.Domain.RequestDomain;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Services.GlobalServices;

namespace RandomChatSrc.Services.RequestChatService
{
    public interface IRequestChatService
    { 
        public List<Request> getAllRequests();

        public void addRequest(Guid senderId, Guid receiverId);

        public void declineRequest(Guid senderId, Guid receiverId);

        public void acceptRequest(Guid senderId, Guid receiverId);
        
    }
}
