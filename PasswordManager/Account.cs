using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class Account
    {
        public string Platform { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string description;
        public string DisplayString { get; set; }

        public Account(string platform, string username, string password, string email)
        {
            Platform = platform;
            Username = username;
            Password = password;
            Email = email;
            description = "";
            DisplayString = $"{Platform}| {Username}";
        }
        public Account(string platform, string username, string password, string email,string desc)
        {
            Platform = platform;
            Username = username;
            Password = password;
            Email = email;
            description = desc;
            DisplayString = $"{Platform}| {Username}";
        }
    }
}
