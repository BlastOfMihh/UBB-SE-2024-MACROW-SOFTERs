//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using RandomChatSrc.Domain;
//using RandomChatSrc.Domain.MapLocation;
//using RandomChatSrc.Domain.TextChat;
//using RandomChatSrc.Repo;

//namespace RandomChatSrc.Services.GlobalServices
//{
//    internal class AllServices
//    {
//        private static AllServices? instance = null;
//        private readonly string _textChatsDirectoryPath = "D:\\facultate\\anu 2\\SEMESTRUL 2\\ISS Second game\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\ChatRepo\\";
//        public List<TextChat> ActiveChats { get; set; }
//        private readonly MapRepo _mapRepo;
//        private readonly TextChat _textChat;
//        private readonly Guid _userId;
//        private readonly GlobalServices _globalServices;
//        public AllServices(MapRepo mapRepo, TextChat textChat, Guid userId)
//        {
//            ActiveChats = new List<TextChat>();
//            LoadActiveChats();
//            _mapRepo = mapRepo;
//            _textChat = textChat;
//            _userId = userId;
//        }

//        private string GetIdFromPath(string folderPath)
//        {
//            string id = "";
//            for (int i = folderPath.Length - 1; folderPath[i] != '\\' && i >= 0; --i)
//            {
//                id += folderPath[i];
//            }
//            return new string(id.Reverse().ToArray());
//        }
//        private void LoadActiveChats()
//        {
//            foreach (string chatFolderPath in Directory.GetDirectories(_textChatsDirectoryPath))
//            {
//                string foundId = GetIdFromPath(chatFolderPath);
//                TextChat newTextChat = new TextChat(new List<Message>(), _textChatsDirectoryPath, foundId);
//                ActiveChats.Add(newTextChat);
//            }
//        }
//        /// <summary>
//        /// Creates a new chatroom with a specified size.
//        /// </summary>
//        /// <param name="size">The size of the chatroom.</param>
//        /// <returns>The created chatroom.</returns>
//        public TextChat CreateChat(int size)
//        {
//            var newChat = new TextChat(new List<Message>(), _textChatsDirectoryPath);
//            ActiveChats.Add(newChat);
//            return newChat;
//        }

//        /// <summary>
//        /// Deletes a chatroom with the specified ID.
//        /// </summary>
//        /// <param name="id">The ID of the chatroom to delete.</param>
//        public void DeleteChat(Guid id)
//        {
//            foreach (TextChat chat in ActiveChats.ToList())
//            {
//                if (chat.id == id)
//                {
//                    ActiveChats.Remove(chat);
//                    return;
//                }
//            }
//            throw new Exception("Chat could not be deleted!! not enough permissions");
//        }

//        /// <summary>
//        /// Retrieves a random chatroom from the active chatrooms list.
//        /// </summary>
//        /// <returns>A random chatroom.</returns>
//        public TextChat GetChat()
//        {
//            Random random = new Random();
//            int index = random.Next(ActiveChats.Count);
//            return ActiveChats[index];
//        }

//        /// <summary>
//        /// Retrieves a chatroom by its ID.
//        /// </summary>
//        /// <param name="id">The ID of the chatroom.</param>
//        /// <returns>The chatroom with the specified ID.</returns>
//        public TextChat getChatById(Guid id)
//        {
//            foreach (TextChat chat in ActiveChats)
//            {
//                if (chat.id == id)
//                {
//                    return chat;
//                }
//            }
//            throw new Exception("Chat not found");
//        }

//        /// <summary>
//        /// Retrieves all active chatrooms.
//        /// </summary>
//        /// <returns>A list of all active chatrooms.</returns>
//        public List<TextChat> getAllChats()
//        {
//            return ActiveChats;
//        }
//        /// <summary>
//        /// Retrieves the locations of all users on the map.
//        /// </summary>
//        /// <returns>A list of map locations for all users.</returns>
//        public List<MapLocation> getAllUserLocations()
//        {
//            return _mapRepo.getAllUsersLocationList();
//        }

//        /// <summary>
//        /// Retrieves the IDs of all users with known locations on the map.
//        /// </summary>
//        /// <returns>A list of user IDs.</returns>
//        public List<Guid> getAllUsers()
//        {
//            List<Guid> users = new List<Guid>();
//            foreach (MapLocation mapLocation in _mapRepo.getAllUsersLocationList())
//            {
//                if (mapLocation.UserId != Guid.Empty)
//                {
//                    users.Add(mapLocation.UserId);
//                }
//            }
//            return users;
//        }

//        /// <summary>
//        /// Initiates a chat request from a sender to a receiver.
//        /// </summary>
//        /// <param name="senderId">The ID of the sender initiating the request.</param>
//        /// <param name="receiverId">The ID of the receiver being requested.</param>

//        public void makeRequest(Guid senderId, Guid receiverId)
//        {
//            _globalServices.requestChatService.addRequest(senderId, receiverId);
//        }
//        /// <summary>
//        /// Updates the location of a user on the map.
//        /// </summary>
//        /// <param name="userId">The ID of the user whose location is being updated.</param>
//        /// <param name="location">The new location of the user.</param>

//        public void updateUserLocation(Guid userId, MapLocation location)
//        {
//            _mapRepo.updateUserLocation(userId, location);
//        }
        
//    }
//}
