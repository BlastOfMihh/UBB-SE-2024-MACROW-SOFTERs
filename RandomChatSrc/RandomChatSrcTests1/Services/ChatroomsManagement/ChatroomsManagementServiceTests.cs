using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomChatSrc.Domain.ChatDomain;
using RandomChatSrc.Services.ChatroomsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Services.ChatroomsManagement.Tests
{
    [TestClass()]
    public class ChatroomsManagementServiceTests
    {
        [TestMethod()]
        public void CreateChatTest()
        {
            //write a test which checks if a chat is created
            ChatroomsManagementService chatroomsManagementService = new ChatroomsManagementService();
            Chat chat = chatroomsManagementService.CreateChat(5);
            Assert.IsNotNull(chat);
        }
    }
}