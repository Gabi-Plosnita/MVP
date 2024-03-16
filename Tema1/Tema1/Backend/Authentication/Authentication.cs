using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Tema1.Backend
{
    public class Authentication
    {
        private List<Admin> Admins;

        public bool isAuthenticated { get; private set; }

        public Authentication() 
        {
            Admins = new List<Admin>();
            isAuthenticated = false;
        }

        public void LoadFromFile(string filePath)
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);

                Admins = JsonConvert.DeserializeObject<List<Admin>>(jsonData);

                Console.WriteLine("Data loaded successfully from file.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (JsonException)
            {
                Console.WriteLine("Error deserializing JSON data.");
            }
        }

        public void Login(string username, string password)
        {
            foreach(Admin admin in Admins)
            {
                if(admin.IsValidUsername(username) && admin.IsValidPassword(password))
                {
                    isAuthenticated = true;
                    return;
                }
            }
        }
    }
}
