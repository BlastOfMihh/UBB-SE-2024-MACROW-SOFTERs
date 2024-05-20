using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Model;

namespace MauiApp1.ViewModel
{
    public class ChatPageViewModel : INotifyPropertyChanged
    {
        private int userId;
        private readonly IService service;
        private int chatId;

        public event PropertyChangedEventHandler? PropertyChanged;

        private string contactName;
        public string ContactName
        {
            get => contactName;
            private set
            {
                if (contactName != value)
                {
                    contactName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string contactProfilePhotoPath;
        public string ContactProfilePhotoPath
        {
            get => contactProfilePhotoPath;
            private set
            {
                if (value != contactProfilePhotoPath)
                {
                    contactProfilePhotoPath = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<MessageModel> Messages { get; private set; }

        public ChatPageViewModel(Service service, int userId)
        {
            this.service = service;
            this.userId = userId;
            Messages = new ObservableCollection<MessageModel>();
        }

        private void RefreshChatMessages()
        {
            List<MessageModel> messages = service.GetChatMessages(chatId);
            Messages.Clear();
            foreach (MessageModel messageModel in messages)
            {
                Messages.Add(messageModel);
            }
        }

        public void SetChatId(int chatId)
        {
            this.chatId = chatId;
            ContactName = service.GetContactName(chatId);
            ContactProfilePhotoPath = service.GetContactProfilePhotoPath(chatId);
            RefreshChatMessages();
        }

        public void AddTextMessageToChat(string text)
        {
            service.AddTextMessageToChat(chatId, userId, text);
            RefreshChatMessages();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
