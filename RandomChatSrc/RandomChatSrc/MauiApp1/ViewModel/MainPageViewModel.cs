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
    public class MainPageViewModel
    {
        private int userId;
        private readonly IService service;

        public Service GetService()
        {
            return (Service)this.service;
        }
        public ObservableCollection<ContactLastMessage> Contacts { get; private set; }

        public MainPageViewModel(Service service, int userId)
        {
            this.service = service;
            this.userId = userId;
            List<ContactLastMessage> contacts = service.GetContactLastMessages(userId, string.Empty);
            Contacts = new ObservableCollection<ContactLastMessage>(contacts);
        }

        public void RefreshContacts(string searchText)
        {
            List<ContactLastMessage> contactMessages = service.GetContactLastMessages(userId, searchText);
            Contacts.Clear();
            foreach (ContactLastMessage contactMessage in contactMessages)
            {
                Contacts.Add(contactMessage);
            }
        }

        public void FilterContacts(string searchText)
        {
            if (searchText == null)
            {
                searchText = string.Empty;
            }
            RefreshContacts(searchText);
        }
    }
}
