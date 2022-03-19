using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class Costumer
    {
        private static int _costumerId = 0;
        private string _number;
        private string _sex;
        private string _lastName;
        private string _firstName;
        private string _street;
        private int _postalCcode;
        private string _location;
        private string _country;
        private decimal _telNr;
        private string _email;

        public Costumer(string sex, string lastName, string firstName, string street,
            int postalCcode, string location, string country, decimal telNr, string email)
        {
            string storedId = null;
            if (File.Exists("aicostumer")) storedId = File.ReadAllText("aicostumer");
            if (storedId == null || storedId.Length < 0) storedId = "0";
            _costumerId = Convert.ToInt32(storedId) + 1;
            File.WriteAllText("aicostumer", _costumerId.ToString());
            this._number = _costumerId.ToString();
            Sex = sex;
            LastName = lastName;
            FirstName = firstName;
            Street = street;
            PostalCcode = postalCcode;
            Location = location;
            Country = country;
            TelNr = telNr;
            Email = email;
        }

        public static int CostumerId { get => _costumerId; set => _costumerId = value; }
        public string Number { get => _number; set => _number = value; }
        public string Sex { get => _sex; set => _sex = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string Street { get => _street; set => _street = value; }
        public int PostalCcode { get => _postalCcode; set => _postalCcode = value; }
        public string Location { get => _location; set => _location = value; }
        public string Country { get => _country; set => _country = value; }
        public decimal TelNr { get => _telNr; set => _telNr = value; }
        public string Email { get => _email; set => _email = value; }
    }
}
