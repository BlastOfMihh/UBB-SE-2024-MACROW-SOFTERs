using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Models;
using RandomChatSrc.Repository;
using RandomChatSrc.Services.GlobalServices;

namespace RandomChatSrc.Services.RequestChatService
{
    public class RequestChatService
    {
        public GlobalServices.GlobalServices globalServices { get; set; }
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
            TextChat newTextChat = this.globalServices.chatroomsManagementService.CreateChat(5);
            newTextChat.AddParticipant(this.globalServices.userRepo.getUserById(senderId));
            newTextChat.AddParticipant(this.globalServices.userRepo.getUserById(receiverId));
            this.requestsChatRepo.removeRequest(senderId, receiverId);
        }
    }
}
