using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Username_And_Passwords
    {
        private string _usernames;
        private string _passwords;

        public Username_And_Passwords(string usernames, string passwords)
        {
            Usernames = usernames;
            Passwords = passwords;
        }

        public string Usernames { get => _usernames; set => _usernames = value; }
        public string Passwords { get => _passwords; set => _passwords = value; }
    }
}
