using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CoreGraphics;
using RandomChatSrc.Domain.RequestDomain;

namespace RandomChatSrc.Repository
{
    public class RequestsChatRepo
    {
        public Guid Id { get; set; }
        public List<Request> Requests {  get; set; }
        public string RequestsFolderPath {  get; set; }

        public RequestsChatRepo(List<Request> requests, string requestsFolderPath)
        {
            this.Id = Guid.NewGuid();
            this.Requests = requests;
            this.RequestsFolderPath = requestsFolderPath + this.Id.ToString();

            if (!Directory.Exists(this.RequestsFolderPath))
            {
                Directory.CreateDirectory(this.RequestsFolderPath);
            }
            this.loadFromMemory();
        }

        private void loadFromMemory()
        {
            foreach (string requestPath in Directory.GetFiles(this.RequestsFolderPath))
            {
                XDocument? requestDoc = XDocument.Load(requestPath);
                if (requestDoc == null)
                {
                    Console.WriteLine("Could not load a document for file path '" + requestPath + "'");
                    continue;
                }
                if (requestDoc.Root == null)
                {
                    Console.WriteLine("The root for the document with file path '" + requestPath + "' is inexistent.");
                    continue;
                }

                XElement? requestElement = requestDoc.Root.Element("request");
                if (requestElement == null)
                {
                    Console.WriteLine("There is no request content for the document with file path '" + requestPath + "'");
                    continue;
                }

                XElement? requestIdElement = requestElement.Element("RequestId");
                if (requestIdElement == null)
                {
                    Console.WriteLine($"There is no request id content for the document with file path '${requestPath}'");
                    continue;
                }
                string requestId = requestElement.Value;

                XElement? senderElement = requestElement.Element("senderUser");
                if (senderElement == null)
                {
                    Console.WriteLine($"There is no sender content for the document with file path '${requestPath}'");
                    continue;
                }
                string senderUserId = senderElement.Value;

                XElement? receiverElement = requestElement.Element("receiverUser");
                if (receiverElement == null)
                {
                    Console.WriteLine($"There is no receiver content for the document with file path '${requestPath}`");
                    continue;
                }
                string receiverUserId = receiverElement.Value;

                /*  XElement? timestampElement = requestElement.Element("timestamp");
                  if (timestampElement == null)
                  {
                      Console.WriteLine($"There is no timestamp content for the document with file path '${requestPath}'");
                      continue;
                  }*/
                Request curRequest = new(Guid.Parse(requestId), Guid.Parse(senderUserId), Guid.Parse(receiverUserId), requestPath);
                this.Requests.Add(curRequest);
            }
        }

        public void addRequest(Guid senderUserId, Guid receiverUserId)
        {
            Guid requestId = Guid.NewGuid();
            string requestPath = this.RequestsFolderPath + "/request_" + requestId.ToString() + ".xml";
            DateTime requestTimestamp = DateTime.Now;
            Request curRequest = new(requestId, senderUserId, receiverUserId, requestPath);
            this.Requests.Add(curRequest);


            // todo see if its ok to pass Guids to this,
            // instead of strings
            XDocument requestDoc = new(
                new XElement("request",
                    new XElement("RequestId", requestId),
                    new XElement("senderUser", senderUserId),
                    new XElement("receiverUser", receiverUserId)
                 //   new XElement("timestamp", requestTimestamp.ToString("yyyy-MM-ddTHH:mm:ss"))
                )
            );
            requestDoc.Save(requestPath);
        }
    }
}
