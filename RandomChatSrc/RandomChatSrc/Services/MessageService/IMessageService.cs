using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Services.MessageService
{
    public interface IMessageService
    {
        void SendMessage(string message);
    }
}
