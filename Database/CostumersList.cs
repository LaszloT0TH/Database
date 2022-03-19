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
    public partial class CostumersList : Form
    {
        public static int costId = 0;
        InputForm form;
        NewSale newSale;
        List<Costumers> costumers;
        string[] costumersArray;

        void Costumers_List()
        {

            costumers = new List<Costumers>();
            if (File.Exists("Costumer.csv"))
            {
                StreamReader reader = new StreamReader("Costumer.csv", Encoding.Default);
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] record = line.Split(';');
                    int costumerId = Convert.ToInt32(record[0]);
                    string sex = record[1]; 
                    string lastName = record[2];
                    string firstName = record[3];
                    string street = record[4];
                    int postalCcode = Convert.ToInt32(record[5]);
                    string location = record[6];
                    string country = record[7];
                    decimal telNr = Convert.ToDecimal(record[8]);
                    string email = record[9];
                    costumers.Add(new Costumers
                    {
                        CostumerId = costumerId,
                        Sex = sex,
                        LastName = lastName,
                        FirstName = firstName,
                        Street = street,
                        PostalCcode = postalCcode,
                        Location = location,
                        Country = country,
                        TelNr = telNr,
                        Email = email
                    });
                    line = reader.ReadLine();
                }
                reader.Close();
            }
            costumersArray = new string[costumers.Count];
            for (int i = 0; i < costumers.Count; i++)
            {
                costumersArray[i] += costumers[i].CostumerId + ";" + costumers[i].LastName 
                    + ";" + costumers[i].Street + ";" + costumers[i].Location + "; +" + costumers[i].TelNr;
            }
            
            form = new InputForm(this);
            form.Add("Costumers", new InputSelect("Kunden List:", costumersArray).SetSize(800))

                .MoveTo(10, 10)
                .SetButton("Weiter")
                .SetButtonchange("List", Visible = false)
                .SetButtonmenu("Menu", Visible = true)
                .OnSubmit(() =>
                {
                    string[] tempCostId = form["Costumers"].Split(';');
                    costId = Convert.ToInt32(tempCostId[0]);
                    MessageBox.Show(form["Costumers"]);
                    newSale = new NewSale();
                    this.Visible = false;
                    newSale.Visible = false;
                    newSale.ShowDialog();
                })
                .OnSubmitChange(() =>
                {
                    //Form4 form4 = new Form4();
                    //form4.Show();
                    //this.Close();
                })
                .OnSubmitMenu(() =>
                {
                    Menu menu = new Menu();
                    this.Visible = false;
                    menu.Visible = false;
                    menu.ShowDialog();
                });
        }
        public CostumersList()
        {
            InitializeComponent();
            Costumers_List();
        }
    }
}
