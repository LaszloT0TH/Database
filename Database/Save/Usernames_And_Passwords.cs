using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class Usernames_And_Passwords
    {
        public string _usernames { get; set; }
        public string _passwords { get; set; }
        public int? _passwordNumbers 
        {
            get { return Convert.ToInt32(
                Convert.ToString(this._passwords[this._passwords.Length - 2]) + 
                Convert.ToString(this._passwords[this._passwords.Length - 1])); 
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Usernames_And_Passwords objAsPart = obj as Usernames_And_Passwords;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        
        public bool Equals(Usernames_And_Passwords other)
        {
            if (other == null) return false;
            return (this._usernames.Equals(other._usernames) && this._passwords.Equals(other._passwords));
        }

        public override int GetHashCode()
        {
            int hashCode = -1717943133;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_usernames);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_passwords);
            return hashCode;
        }
    }
}
