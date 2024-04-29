namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents a request sent by a User to another User.
    /// Contains the request's identifier, the sender's and receiver's identifiers and the request's path.
    /// </summary>

    public class Request(Guid requestId, Guid senderUserId, Guid receiverUserId, string requestPath)
    {
        public Guid RequestId { get; set; } = requestId;
        public Guid SenderUserId { get; set; } = senderUserId;
        public Guid ReceiverUserId { get; set; } = receiverUserId;
        public string RequestPath { get; set; } = requestPath;
    }
}
