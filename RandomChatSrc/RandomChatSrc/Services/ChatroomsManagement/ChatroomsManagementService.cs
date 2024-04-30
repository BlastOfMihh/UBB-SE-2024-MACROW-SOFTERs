// <copyright file="ChatroomsManagementService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using RandomChatSrc.Domain;
using RandomChatSrc.Domain.TextChat;

namespace RandomChatSrc.Services.ChatroomsManagement
{
    /// <summary>
    /// Service for managing chatrooms.
    /// </summary>
    public class ChatroomsManagementService : IChatroomsManagementService
    {
       // schimba asta de fiecare data cand dai pull asta e nivelul
        private readonly string textChatsDirectoryPath = "C:\\Users\\potat\\OneDrive\\Documents\\Visual Studio 2022\\ISS\\Macrow\\RandomChatSrc\\RandomChatSrc\\ChatRepo\\";       private List<TextChat> ActiveChats { get; set; }

        public ChatroomsManagementService()
        {
            ActiveChats = new List<TextChat>();
            LoadActiveChats();
        }

        private string GetIdFromPath(string folderPath)
        {
            string id = string.Empty;
            for (int i = folderPath.Length - 1; folderPath[i] != '\\' && i >= 0; --i)
            {
                id += folderPath[i];
            }
            return new string(id.Reverse().ToArray());
        }
        private void LoadActiveChats()
        {
            foreach (string chatFolderPath in Directory.GetDirectories(textChatsDirectoryPath))
            {
                string foundId = GetIdFromPath(chatFolderPath);
                TextChat newTextChat = new TextChat(new List<Message>(), textChatsDirectoryPath, foundId);
                ActiveChats.Add(newTextChat);
            }
        }

        /// <summary>
        /// Creates a new chatroom with a specified size.
        /// </summary>
        /// <param name="size">The size of the chatroom.</param>
        /// <returns>The created chatroom.</returns>
        public TextChat CreateChat(int size)
        {
            var newChat = new TextChat(new List<Message>(), textChatsDirectoryPath);
            ActiveChats.Add(newChat);
            return newChat;
        }

        /// <summary>
        /// Deletes a chatroom with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the chatroom to delete.</param>
        public void DeleteChat(Guid id)
        {
            foreach (TextChat chat in ActiveChats.ToList())
            {
                if (chat.id == id)
                {
                    ActiveChats.Remove(chat);
                    return;
                }
            }
            throw new Exception("Chat could not be deleted!! not enough permissions");
        }

        /// <summary>
        /// Retrieves a random chatroom from the active chatrooms list.
        /// </summary>
        /// <returns>A random chatroom.</returns>
        public TextChat GetChat()
        {
            Random random = new Random();
            int index = random.Next(ActiveChats.Count);
            return ActiveChats[index];
        }

        /// <summary>
        /// Retrieves a chatroom by its ID.
        /// </summary>
        /// <param name="id">The ID of the chatroom.</param>
        /// <returns>The chatroom with the specified ID.</returns>
        public TextChat GetChatById(Guid id)
        {
            foreach (TextChat chat in ActiveChats)
            {
                if (chat.id == id)
                {
                    return chat;
                }
            }
            throw new Exception("Chat not found");
        }

        /// <summary>
        /// Retrieves all active chatrooms.
        /// </summary>
        /// <returns>A list of all active chatrooms.</returns>
        public List<TextChat> GetAllChats()
        {
            return ActiveChats;
        }
    }
}
