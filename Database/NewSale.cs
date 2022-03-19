using Database.InputForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    public partial class NewSale : Form
    {
        InputForm form;
        List<Cars> cars;
        List<Logins> logins;
        Sale sale;
        string[] carsArray;
       
        void New_Sale()
        {

            cars = new List<Cars>();
            logins = new List<Logins>();
            int soldcount = 0;
            if (File.Exists("Car.csv"))
            {
                StreamReader reader = new StreamReader("Car.csv", Encoding.Default);
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] record = line.Split(';');
                    int carNumber = Convert.ToInt32(record[0]);
                    string model = record[1];
                    string color = record[2];
                    int number_of_seats = Convert.ToInt32(record[3]);
                    double cubic_capacity = Convert.ToDouble(record[4]);
                    int mileage = Convert.ToInt32(record[5]);
                    int year_of_production = Convert.ToInt32(record[6]);
                    string chassis_number = record[7];
                    int engine_power = Convert.ToInt32(record[8]);
                    string gearbox = record[9];
                    string fuel = record[10];
                    int own_Weight = Convert.ToInt32(record[11]);
                    bool sold = Convert.ToBoolean(record[12]);
                    if (sold)
                    {
                        soldcount++;
                    }
                    cars.Add(new Cars
                    {
                        CarNumber = carNumber,
                        Model = model,
                        Color = color,
                        Number_of_seats = number_of_seats,
                        Cubic_capacity = cubic_capacity,
                        Mileage = mileage,
                        Year_of_production = year_of_production,
                        Chassis_number = chassis_number,
                        Engine_power = engine_power,
                        Gearbox = gearbox,
                        Fuel = fuel,
                        Own_Weight = own_Weight,
                        Sold = sold
                    });
                    line = reader.ReadLine();
                }
                reader.Close();
            }
            
            carsArray = new string[cars.Count - soldcount];
            for (int i = 0, j = 0; j < cars.Count; j++)
            {
                if (!cars[j].Sold)
                {
                    carsArray[i] += cars[j].CarNumber + ";" + cars[j].Model + ";" + cars[j].Color + ";" + cars[j].Number_of_seats
                    + ";" + cars[j].Cubic_capacity + ";" + cars[j].Mileage + ";" + cars[j].Year_of_production
                    + ";" + cars[j].Chassis_number + ";" + cars[j].Engine_power + ";" + cars[j].Gearbox + ";" + cars[j].Fuel
                    + ";" + cars[j].Own_Weight;
                    i++;
                }
            }

            form = new InputForm(this);
            form.Add("Auto", new InputSelect("Auto List:", carsArray ).SetSize(800))

                .MoveTo(10, 10)
                .SetButton("Vekauf")
                .SetButtonchange("List", Visible = false)
                .SetButtonmenu("Menu", Visible = false)
                .OnSubmit(() =>
                {
                    string[] record = form["Auto"].Split(';');
                    int temporaryCarNumber = Convert.ToInt32(record[0]);
                    StreamWriter writer = new StreamWriter("Car.csv");
                    foreach (Cars car in cars)
                    {
                        if (car.CarNumber == temporaryCarNumber)
                        {
                            car.Sold = true;
                        }
                        string line1 = $"{car.CarNumber};{car.Model};{car.Color};{car.Number_of_seats};" +
                        $"{car.Cubic_capacity};{car.Mileage};{car.Year_of_production};" +
                        $"{car.Chassis_number};{car.Engine_power};" +
                        $"{car.Gearbox};{car.Fuel};{car.Own_Weight};{car.Sold}";
                        writer.WriteLine(line1);
                    }
                    writer.Close();

                    int costumerId;
                    if (NewCostumer.newcostId)
                    {
                        string storedId = null;
                        if (File.Exists("aicostumer")) storedId = File.ReadAllText("aicostumer");
                        costumerId = Convert.ToInt32(storedId);
                    }
                    else
                    {
                        costumerId = CostumersList.costId;
                    }
                    
                    StreamReader _reader = new StreamReader("Login.csv", Encoding.Default);
                    string _line = _reader.ReadLine();
                    while (_line != null)
                    {
                        string[] _records = _line.Split(';');
                        string _username = _records[0];
                        string _pasword = _records[1];
                        DateTime _dateTime = Convert.ToDateTime(_records[2]);
                        logins.Add(new Logins { Username = _username, Pasword = _pasword, Date = _dateTime });
                        _line = _reader.ReadLine();
                    }
                    _reader.Close();
                    Logins log = logins[logins.Count - 1];
                    int salesId = Convert.ToInt32(log.Pasword[log.Pasword.Length-2].ToString() + log.Pasword[log.Pasword.Length - 1].ToString());
                    
                    int carNumber = temporaryCarNumber;

                    DateTime date = DateTime.Now;
                    sale = new Sale(costumerId, salesId, carNumber, date);
                    StreamWriter stream = new StreamWriter("Sale.csv",true);
                    string line_ = $"{sale.Number};{sale.CostumerId};{sale.SalesId};{sale.CarNumber};{sale.Date}";
                    stream.WriteLine(line_);
                    stream.Close();
                    MessageBox.Show(form["Auto"] + " verkauft");
                    NewCostumer newCostumer = new NewCostumer();
                    this.Visible = false;
                    newCostumer.Visible = false;
                    newCostumer.ShowDialog();
                })
                .OnSubmitChange(() =>
                {
                    //Form4 form4 = new Form4();
                    //form4.Show();
                    //this.Close();
                });
        }

        public NewSale()
        {
            InitializeComponent();
            New_Sale();
        }
    }
}
