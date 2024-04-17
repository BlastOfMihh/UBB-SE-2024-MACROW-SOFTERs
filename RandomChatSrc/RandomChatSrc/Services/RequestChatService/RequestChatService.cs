using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Repository;
using RandomChatSrc.Domain.RequestDomain;
using RandomChatSrc.Domain.TextChat;

namespace RandomChatSrc.Services.RequestChatService
{
    public class RequestChatService
    {
        public GlobalServices globalServices { get; set; }  // TODO: TO LINK TO
        public RequestsChatRepo requestsChatRepo {  get; set; }

        public RequestChatService(RequestsChatRepo requestsChatRepo)
        {
            this.requestsChatRepo = requestsChatRepo;
        }

        public List<Request> getAllRequests()
        {
            return this.requestsChatRepo.Requests;
        }

        public void addRequest(Guid senderId, Guid receiverId)
        {
            this.requestsChatRepo.addRequest(senderId, receiverId);
        }

        public void declineRequest(Guid senderId, Guid receiverId)
        {
            this.requestsChatRepo.removeRequest(senderId, receiverId);
        }

        public void acceptRequest(Guid senderId, Guid receiverId)
        {
            TextChat newTextChat = this.globalServices.chatRoomsManagementServices.CreateChat(5);
            newTextChat.addParticipant(this.globalServices.userService.getUserById(senderId));
            newTextChat.addParticipant(this.globalServices.userService.getUserById(receiverId));
            this.requestsChatRepo.removeRequest(senderId, receiverId);
        }
    }
}
