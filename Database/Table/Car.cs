using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Table
{
    class Car
    {
        private static int _carNumber;
        private string _number;
        private string _model; 
        private string _color;
        private int _number_of_seats;
        private double _cubic_capacity;
        private int _mileage;
        private int _year_of_production;
        private string _chassis_number;
        private int _engine_power;
        private string _gearbox;
        private string _fuel;
        private int _own_Weight;
        private bool _sold;

        public Car(string model, string color, int number_of_seats, 
            double cubic_capacity, int mileage, int year_of_production, string chassis_number, 
            int engine_power, string gearbox, string fuel, int own_Weight)
        {
            string storedId = null;
            if (File.Exists("aicar")) storedId = File.ReadAllText("aicar");
            if (storedId == null || storedId.Length < 0) storedId = "0";
            _carNumber = Convert.ToInt32(storedId) + 1;
            File.WriteAllText("aicar", _carNumber.ToString());
            this._number = _carNumber.ToString();
            Model = model;
            Color = color;
            Number_of_seats = number_of_seats;
            Cubic_capacity = cubic_capacity;
            Mileage = mileage;
            Year_of_production = year_of_production;
            Chassis_number = chassis_number;
            Engine_power = engine_power;
            Gearbox = gearbox;
            Fuel = fuel;
            Own_Weight = own_Weight;
            Sold = false;
        }
        public Car SetAsSold() { Sold = false; return this; }
        public static int CarNumber { get => _carNumber; set => _carNumber = value; }
        public string Number { get => _number; set => _number = value; }
        public string Model { get => _model; set => _model = value; }
        public string Color { get => _color; set => _color = value; }
        public int Number_of_seats { get => _number_of_seats; set => _number_of_seats = value; }
        public double Cubic_capacity { get => _cubic_capacity; set => _cubic_capacity = value; }
        public int Mileage { get => _mileage; set => _mileage = value; }
        public int Year_of_production { get => _year_of_production; set => _year_of_production = value; }
        public string Chassis_number { get => _chassis_number; set => _chassis_number = value; }
        public int Engine_power { get => _engine_power; set => _engine_power = value; }
        public string Gearbox { get => _gearbox; set => _gearbox = value; }
        public string Fuel { get => _fuel; set => _fuel = value; }
        public int Own_Weight { get => _own_Weight; set => _own_Weight = value; }
        public bool Sold { get => _sold; set => _sold = value; }
    }
}
