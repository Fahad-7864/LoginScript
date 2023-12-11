using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms; 


namespace LoginScript

{
    internal class UserManager

    {
        //change this to your own path
        private readonly string _filePath = @"C:\Users\fahad\source\repos\LoginScript\LoginScript\users.csv";

        // Constructor to check if the CSV file exists, if not, create it
        public UserManager()
        {
            if (!File.Exists(_filePath))
            {
                using (var writer = new StreamWriter(_filePath, false)) 
                {
                    writer.WriteLine("username,passwordHash");
                }
            }
        }

        // Register a new username and password
        public bool Register(string username, string password)
        {
            try
            {
                var users = ReadUsers();
                if (users.Any(u => u.Username == username))
                {
                    return false; // Username already exists
                }

                var user = new User
                {
                    Username = username,
                    PasswordHash = HashPassword(password) // hash the password
                };
                
                // Append the the user
                using (var writer = new StreamWriter(_filePath, true))
                {
                    writer.WriteLine($"{user.Username},{user.PasswordHash}");
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to CSV file: {ex.Message}");
                return false;
            }
        }

       
        public bool Login(string username, string password)
        {
            var users = ReadUsers();
            return users.Any(u => u.Username == username && u.PasswordHash == HashPassword(password));
        }

        //
        private List<User> ReadUsers()
        {
            var users = new List<User>(); 

            using (var reader = new StreamReader(_filePath))
            {
                
                string line;

                // Read each line of the file 
                while ((line = reader.ReadLine()) != null)
                {
                    // Split the line into parts using the comma (for CSV files)
                    var parts = line.Split(',');

                    // Check if the line correctly splits into two parts: username and password.
                    if (parts.Length == 2)
                    {
                        // Create a new User object from the parts and add it to the users list.

                        users.Add(new User { Username = parts[0], PasswordHash = parts[1] });
                    }
                }
            }

            return users; 
        }

        // Hash the password
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}

