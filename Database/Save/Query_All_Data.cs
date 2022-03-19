using System;

namespace Database.Save
{
    class Query_All_Data
    {   
        // Costumers
        public int costCostumerId;
        public string costSex;
        public string costLastName;
        public string costFirstName;
        public string costStreet;
        public int costPostalCcode;
        public string costLocation;
        public string costCountry;
        public decimal costTelNr;
        public string costEmail;
        // Cars
        public int carCarNumber;
        public string carModel;
        public string carColor;
        public int carNumber_of_seats;
        public double carCubic_capacity;
        public int carMileage;
        public int carYear_of_production;
        public string carChassis_number;
        public int carEngine_power;
        public string carGearbox;
        public string carFuel;
        public int carOwn_Weight;
        // Salespersons
        public int salep_salesId;
        public string salep_lastName;
        public string salep_firstName;
        public double salep_provision;
        public int salep_entry;
        public bool salep_active;
        // Salespersons_Secret_Data
        public double salep_wage;
        public int salep_date_of_birth;
        public int salep_postalCcode;
        public string salep_location;
        public string salep_street;
        // Sales
        public DateTime sale_date;

        public Query_All_Data(int costCostumerId, string costSex, string costLastName, string costFirstName, 
            string costStreet, int costPostalCcode, string costLocation, string costCountry, decimal costTelNr, 
            string costEmail, int carCarNumber, string carModel, string carColor, int carNumber_of_seats, 
            double carCubic_capacity, int carMileage, int carYear_of_production, string carChassis_number, 
            int carEngine_power, string carGearbox, string carFuel, int carOwn_Weight, int salep_salesId, 
            string salep_lastName, string salep_firstName, double salep_provision, int salep_entry, bool salep_active, 
            double salep_wage, int salep_date_of_birth, int salep_postalCcode, string salep_location, 
            string salep_street, DateTime sale_date)
        {
            this.costCostumerId = costCostumerId;
            this.costSex = costSex;
            this.costLastName = costLastName;
            this.costFirstName = costFirstName;
            this.costStreet = costStreet;
            this.costPostalCcode = costPostalCcode;
            this.costLocation = costLocation;
            this.costCountry = costCountry;
            this.costTelNr = costTelNr;
            this.costEmail = costEmail;
            this.carCarNumber = carCarNumber;
            this.carModel = carModel;
            this.carColor = carColor;
            this.carNumber_of_seats = carNumber_of_seats;
            this.carCubic_capacity = carCubic_capacity;
            this.carMileage = carMileage;
            this.carYear_of_production = carYear_of_production;
            this.carChassis_number = carChassis_number;
            this.carEngine_power = carEngine_power;
            this.carGearbox = carGearbox;
            this.carFuel = carFuel;
            this.carOwn_Weight = carOwn_Weight;
            this.salep_salesId = salep_salesId;
            this.salep_lastName = salep_lastName;
            this.salep_firstName = salep_firstName;
            this.salep_provision = salep_provision;
            this.salep_entry = salep_entry;
            this.salep_active = salep_active;
            this.salep_wage = salep_wage;
            this.salep_date_of_birth = salep_date_of_birth;
            this.salep_postalCcode = salep_postalCcode;
            this.salep_location = salep_location;
            this.salep_street = salep_street;
            this.sale_date = sale_date;
        }
    }
}
