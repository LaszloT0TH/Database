using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class Salesperson_Secret_Data
    {
        private static int _sSalesId = 0;
        private string _number;
        private double _wage;
        private DateTime _date_of_birth;
        private int _postalCode;
        private string _location;
        private string _street;

        public Salesperson_Secret_Data(double wage, DateTime date_of_birth, int postalCode, string location, string street)
        {
            string storedId = null;
            if (File.Exists("aisalesperson")) storedId = File.ReadAllText("aisalesperson");
            if (storedId == null || storedId.Length < 0) storedId = "0";
            SSalesId = Convert.ToInt32(storedId);
            File.WriteAllText("aisalesperson", SSalesId.ToString());
            this._number = SSalesId.ToString();
            Wage = wage;
            Date_of_birth = date_of_birth;
            PostalCode = postalCode;
            Location = location;
            Street = street;
        }

        public static int SSalesId { get => _sSalesId; set => _sSalesId = value; }
        public string Number { get => _number; set => _number = value; }
        public double Wage { get => _wage; set => _wage = value; }
        public DateTime Date_of_birth { get => _date_of_birth; set => _date_of_birth = value; }
        public int PostalCode { get => _postalCode; set => _postalCode = value; }
        public string Location { get => _location; set => _location = value; }
        public string Street { get => _street; set => _street = value; }
    }
}
