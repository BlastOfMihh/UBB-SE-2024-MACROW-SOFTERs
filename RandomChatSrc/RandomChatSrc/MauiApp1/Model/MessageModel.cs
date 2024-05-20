using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    public class MessageModel
    {
        private string type;
        public bool Incoming { get; private set; } // true - incoming, false - outgoing
        public string Text { get; }

        public MessageModel(string type, bool incoming, string text)
        {
            this.type = type;
            this.Incoming = incoming;
            Text = text;
        }
    }
}
