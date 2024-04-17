using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Domain.RequestDomain;

namespace RandomChatSrc.Repository
{
    public class RequestsChatRepo
    {
        public List<Request> Requests {  get; set; }
        public string RequestsFolderPath {  get; set; }

        public RequestsChatRepo(List<Request> requests, string requestsFolderPath)
        {
            this.Requests = requests;
            this.RequestsFolderPath = requestsFolderPath;
        }

        private void loadFromMemory()
        {

        }
    }
}
