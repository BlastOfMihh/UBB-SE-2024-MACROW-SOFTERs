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
        public GlobalServices.GlobalServices globalServices { get; set; }
        public ChatRequestsRepository requestsChatRepo {  get; set; }

        public RequestChatService(ChatRequestsRepository requestsChatRepo)
        {
            this.requestsChatRepo = requestsChatRepo;
        }

        public List<Request> getAllRequests()
        {
            return this.requestsChatRepo.chatRequests;
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
            TextChat newTextChat = this.globalServices.chatroomsManagementService.CreateChat(5);
            newTextChat.addParticipant(this.globalServices.userRepo.getUserById(senderId));
            newTextChat.addParticipant(this.globalServices.userRepo.getUserById(receiverId));
            this.requestsChatRepo.removeRequest(senderId, receiverId);
        }
    }
}
