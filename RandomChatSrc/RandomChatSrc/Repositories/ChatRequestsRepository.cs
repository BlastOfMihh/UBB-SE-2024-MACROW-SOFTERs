// <copyright file="ChatRequestsRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Repository
{
    using System.Xml.Linq;
    using RandomChatSrc.Domain.RequestDomain;

    /// <summary>
    ///     Class responsible for writing Chat Requests to the XML file.
    /// </summary>
    public class ChatRequestsRepository
    {
        private Guid Id { get; set; }
        private List<Request> chatRequests {  get; set; }
        private string RequestsFolderPath {  get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatRequestsRepository"/> class.
        /// </summary>
        public ChatRequestsRepository(List<Request> chatRequests, string requestsFolderPath)
        {
            this.Id = Guid.NewGuid();
            this.chatRequests = chatRequests;
            this.RequestsFolderPath = requestsFolderPath + this.Id.ToString();

            if (!Directory.Exists(this.RequestsFolderPath))
            {
                Directory.CreateDirectory(this.RequestsFolderPath);
            }
            this.loadFromMemory();
        }

        /// <summary>
        ///     Retrieves all Chat Requests from the XML file.
        /// </summary>
        private void loadFromMemory()
        {
            foreach (string requestPath in Directory.GetFiles(this.RequestsFolderPath))
            {
                XDocument? requestsDocument = XDocument.Load(requestPath);
                if (requestsDocument == null)
                {
                    Console.WriteLine("Could not load a document for file path '" + requestPath + "'");
                    continue;
                }
                if (requestsDocument.Root == null)
                {
                    Console.WriteLine("The root for the document with file path '" + requestPath + "' is inexistent.");
                    continue;
                }

                XElement? requestElement = requestsDocument.Root.Element("request");
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
                Request currentRequest = new(Guid.Parse(requestId), Guid.Parse(senderUserId), Guid.Parse(receiverUserId), requestPath);
                this.chatRequests.Add(currentRequest);
            }
        }

        /// <summary>
        ///     Adds a new Chat Request to the XML file.
        /// </summary>
        /// <param name="senderUserId">The ID of the user who sent the request.</param>
        /// <param name="receiverUserId">The ID of the user who will receive the request.</param>
        public void addRequest(Guid senderUserId, Guid receiverUserId)
        {
            Guid requestId = Guid.NewGuid();
            string requestPath = this.RequestsFolderPath + "/request_" + requestId.ToString() + ".xml";
            Request currentRequest = new(requestId, senderUserId, receiverUserId, requestPath);
            this.chatRequests.Add(currentRequest);
            XDocument requestDocument = new(new XElement("request",
                                                new XElement("RequestId", requestId),
                                                new XElement("senderUser", senderUserId),
                                                new XElement("receiverUser", receiverUserId)));
            requestDocument.Save(requestPath);
        }

        /// <summary>
        ///     Deletes a Chat Request from the XML file.
        /// </summary>
        /// <param name="senderUserId">The ID of the user who sent the request.</param>
        /// <param name="receiverUserId">The ID of the user who received the request.</param>
        public void removeRequest(Guid senderUserId, Guid receiverUserId)
        {
            this.chatRequests = this.chatRequests.Where(request => !(request.SenderUserId == senderUserId && request.ReceiverUserId == receiverUserId)).ToList();
        }

        /// <summary>
        ///     Deletes a Chat Request from the XML file.
        /// </summary>
        public List<Request> getAllChatRequests()
        {
            return this.chatRequests;
        }
    }
}
