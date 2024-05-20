using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace MauiApp1.Model
{
    public class User
    {
        public int UserId { get; }
        public string Name { get; }
        public string ProfilePhotoPath { get; }

        public User(int userId, string name, string profilePhotoPath)
        {
            this.UserId = userId;
            this.Name = name;
            this.ProfilePhotoPath = profilePhotoPath;
        }
    }
}


