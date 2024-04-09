using AudioUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Domain.Mocks
{
    public class MockChat : IMockChat
    {
        public Guid Id { get; set; }
        private List<string> Participants { get; set; }
        private int MaxParticipants { get; set; }

    }
}
