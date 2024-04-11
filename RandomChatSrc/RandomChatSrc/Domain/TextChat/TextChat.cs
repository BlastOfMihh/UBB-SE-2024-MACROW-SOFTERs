
﻿using System;
using System.Collections.Generic;
using System.IO;  // idk if this is fine for Mobile
using System.Runtime.Serialization;
using RandomChatSrc.Domain.ChatDomain;
using System.Xml.Linq;


namespace RandomChatSrc.Domain.TextChat
{
    public class TextChat : Chat
    {
        public List<Message> Messages { get; }
        public string MessagesFolderPath { get; }
        public Guid LastAvailableMessageId { get; set; }

        public TextChat(List<Message> messages, string messagesFolderPath) : base()
        {
            Messages = messages;
            MessagesFolderPath = messagesFolderPath;

            // it's fine for mobile actually?
            if (!Directory.Exists(MessagesFolderPath))
            {
                // take the last part of the directory path
                // string directoryName = MessagesFolderPath.Substring(MessagesFolderPath.LastIndexOf('\\') + 1);
                // create android directory

                Directory.CreateDirectory(MessagesFolderPath); // CRASHES ANDROID
            }

            LoadStoredMessages();
        }

        public void AddMessage(int senderId, string messageContent)
        {
            Guid messageId = Guid.NewGuid();
            string messagePath = MessagesFolderPath + "/message_" + messageId.ToString() + ".xml";
            DateTime messageTimestamp = DateTime.Now;
            Message curMessage = new(messageId, senderId.ToString(), MessagesFolderPath, messagePath, messageTimestamp, messageContent);
            Messages.Add(curMessage);

            XDocument messageDoc = new(
                new XElement("messages",
                    new XElement("message",
                        new XElement("sender", senderId),
                        new XElement("timestamp", messageTimestamp.ToString("yyyy-MM-ddTHH:mm:ss")),
                        new XElement("content", messageContent)
                    )
                )
            );
            messageDoc.Save(messagePath);

            LastAvailableMessageId = messageId;
        }   

        private void LoadStoredMessages()
        {
            foreach (string messageFilePath in Directory.GetFiles(MessagesFolderPath))
            {
                XDocument? messageDoc = XDocument.Load(messageFilePath);
                if (messageDoc == null)
                {
                    Console.WriteLine("Could not load a document for file path '" + messageFilePath + "'");
                    continue;
                }
                if (messageDoc.Root == null)
                {
                    Console.WriteLine("The root for the document with file path '" + messageFilePath + "' is inexistent.");
                    continue;
                }

                // there should always be exactly one "<message>" element in the XML.
                XElement? messageElement = messageDoc.Root.Element("message");
                if (messageElement == null)
                {
                    Console.WriteLine("There is no message content for the document with file path '" + messageFilePath + "'");
                }

                XElement? senderElement = messageElement?.Element("sender");
                if (senderElement == null)
                {
                    Console.WriteLine("There is no sender content for the document with file path '" + messageFilePath + "'");
                }
                int senderId = int.Parse(senderElement!.Value);

                XElement? timestampElement = messageElement?.Element("timestamp");
                if (timestampElement == null)
                {
                    Console.WriteLine("There is no timestamp content for the document with file path '" + messageFilePath + "'");
                }
                string timestamp = timestampElement!.Value;
                DateTime timestampDateTime = DateTime.ParseExact(timestamp, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                XElement? contentElement = messageElement?.Element("content");
                if (contentElement == null)
                {
                    Console.WriteLine("There is no textual content for the document with file path '" + messageFilePath + "'");
                }
                string textContent = contentElement!.Value;

                int underscoreIdx = messageFilePath.LastIndexOf('_');
                int dotIdx = messageFilePath.LastIndexOf('.');
                if (!(underscoreIdx != -1 && dotIdx != -1 && underscoreIdx < dotIdx))
                {
                    Console.WriteLine($"Invalid path format for path '{messageFilePath}'!");
                    continue;
                }
                string messageIdStr = messageFilePath.Substring(underscoreIdx + 1, dotIdx - underscoreIdx - 1);

                Message curMessage = new(Guid.Parse(messageIdStr), senderId.ToString(), MessagesFolderPath, messageFilePath, timestampDateTime, textContent);
                Messages.Add(curMessage);
            }

            // Make sure the messages in the List are in chronological order.
            Messages.Sort((m1, m2) => m1.SentTime.CompareTo(m2.SentTime));
        }
    }
}

