using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class Salesperson
    {
        private static int _salesId =0;
        private string _number;
        private string _lastName;
        private string _firstName;
        private double _provision;
        private DateTime _entry;
        private bool _active;

        public Salesperson(string lastName, string firstName, double provision, DateTime entry, bool active = true)
        {
            string storedId = null;
            if (File.Exists("aisalesperson")) storedId = File.ReadAllText("aisalesperson");
            if (storedId == null || storedId.Length < 0) storedId = "0";
            _salesId = Convert.ToInt32(storedId) + 1;
            File.WriteAllText("aisalesperson", _salesId.ToString());
            this._number = _salesId.ToString();
            LastName = lastName;
            FirstName = firstName;
            Provision = provision;
            Entry = entry;
            Active = active;
        }

        public static int SalesId { get => _salesId; set => _salesId = value; }
        public string Number { get => _number; set => _number = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public double Provision { get => _provision; set => _provision = value; }
        public DateTime Entry { get => _entry; set => _entry = value; }
        public bool Active { get => _active; set => _active = value; }
    }
}
