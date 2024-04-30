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
    public class RequestChatService
    {
        private readonly GlobalServices.GlobalServices _globalServices;
        private readonly RequestsChatRepo _requestsChatRepo;

        public RequestChatService(RequestsChatRepo requestsChatRepo, GlobalServices.GlobalServices globalServices)
        {
            _requestsChatRepo = requestsChatRepo;
            _globalServices = globalServices;
        }

        /// <summary>
        /// Retrieves all requests.
        /// </summary>
        /// <returns>A list of requests.</returns>
        public List<Request> getAllRequests()
        {
            return _requestsChatRepo.Requests;
        }

        /// <summary>
        /// Adds a chat request.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        public void addRequest(Guid senderId, Guid receiverId)
        {
            _requestsChatRepo.addRequest(senderId, receiverId);
        }

        /// <summary>
        /// Declines a chat request.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        public void declineRequest(Guid senderId, Guid receiverId)
        {
            _requestsChatRepo.removeRequest(senderId, receiverId);
        }

        /// <summary>
        /// Accepts a chat request and creates a new text chat.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        public void acceptRequest(Guid senderId, Guid receiverId)
        {
            TextChat newTextChat = _globalServices.GetChatroomsManagementService().CreateChat(5);
            newTextChat.addParticipant(_globalServices.GetUserRepo().getUserById(senderId));
            newTextChat.addParticipant(_globalServices.GetUserRepo().getUserById(receiverId));
            _requestsChatRepo.removeRequest(senderId, receiverId);
        }
    }
}
