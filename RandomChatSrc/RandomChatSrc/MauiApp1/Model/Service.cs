using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.ViewModel;

namespace MauiApp1.Model
{
    public class Service : IService
    {
        private IRepository repository;

        public Service(IRepository repo)
        {
            this.repository = repo;
        }

        public List<Chat> GetChatsSortedByLastMessageTimeStamp(int userId)
        {
            return repository.GetChatsByUser(userId).OrderByDescending(chat => chat.GetLastMessage().GetTimestamp()).ToList();
        }

        public List<Chat> FilterChatsByName(int userId, string name)
        {
            List<Chat> chats = GetChatsSortedByLastMessageTimeStamp(userId);
            if (name.Length == 0)
            {
                return chats;
            }

            name = name.ToLower();

            List<Chat> matchingChats = new List<Chat>();
            foreach (Chat chat in chats)
            {
                User? user = repository.GetUser(chat.ReceiverId);
                if (user == null)
                {
                    continue;
                }

                string userName = user.Name.ToLower();
                if (userName.Contains(name))
                {
                    matchingChats.Add(chat);
                }
            }

            return matchingChats;
        }

        public List<ContactLastMessage> GetContactLastMessages(int userId, string name)
        {
            List<ContactLastMessage> result = new List<ContactLastMessage>();

            List<Chat> chats = this.FilterChatsByName(userId, name);
            foreach (Chat chat in chats)
            {
                User? user = repository.GetUser(chat.ReceiverId);
                if (user == null)
                {
                    continue;
                }

                Message message = chat.GetLastMessage();
                string messageContent = message.GetMessageContent();
                if (message.GetSenderId() == userId)
                {
                    messageContent = "You: " + messageContent;
                }
                if (messageContent.Length > 20)
                {
                    messageContent = messageContent.Substring(0, 17) + "...";
                }

                DateTime dateTime = message.GetTimestamp();
                string time = Utils.ToStringWithLeadingZero(dateTime.Day) + "." + Utils.ToStringWithLeadingZero(dateTime.Month) + "\n";
                time = time + Utils.ToStringWithLeadingZero(dateTime.Hour) + ":" + Utils.ToStringWithLeadingZero(dateTime.Minute);

                ContactLastMessage contactLastMessage = new ContactLastMessage(user.Name, user.ProfilePhotoPath, messageContent, time, message.GetStatus(), chat.ChatId);
                result.Add(contactLastMessage);
            }

            return result;
        }

        public string GetContactName(int chatId)
        {
            Chat? chat = repository.GetChat(chatId);
            if (chat == null)
            {
                return string.Empty;
            }

            User? contact = repository.GetUser(chat.ReceiverId);
            if (contact == null)
            {
                return string.Empty;
            }

            return contact.Name;
        }

        public string GetContactProfilePhotoPath(int chatId)
        {
            Chat? chat = repository.GetChat(chatId);
            if (chat == null)
            {
                return string.Empty;
            }

            User? contact = repository.GetUser(chat.ReceiverId);
            if (contact == null)
            {
                return string.Empty;
            }

            return contact.ProfilePhotoPath;
        }

        public List<MessageModel> GetChatMessages(int chatId)
        {
            List<MessageModel> result = new List<MessageModel>();

            Chat? chat = repository.GetChat(chatId);
            if (chat == null)
            {
                return result;
            }

            List<Message> messages = chat.GetAllMessages();
            foreach (Message message in messages)
            {
                if (message is Message)
                {
                    bool incoming = message.GetSenderId() == chat.ReceiverId;
                    MessageModel model = new MessageModel("text", incoming, message.GetMessageContent());
                    result.Add(model);
                }
            }

            return result;
        }

        public void AddTextMessageToChat(int chatId, int senderId, string text)
        {
            Message message = new TextMessage(0, chatId, senderId, DateTime.Now, string.Empty, text);
            repository.AddMessageToChat(chatId, message);
        }
    }
}
