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
    public partial class NewCostumer : Form
    {
        InputForm form;
        Costumer costumer;
        NewSale newSale;
        public static bool newcostId;
        void New_Costumer()
        {
            form = new InputForm(this);
            form.Add("Geschl", new InputSelect("Geschlecht:", new string[] { "weiblich", "männlich", "divers", "inter", "offen", "kein Eintrag" }))
                .Add("FName", (new InputField("Familienname")).AddRule("[A-ZÖÜ]{1}[a-zäöüß]{1,30}[ ]{0,1}[A-ZÖÜ]{0,1}[a-zäöüß]{0,30}[ ]{0,1}[A-ZÖÜ]{0,1}[a-zäöüß]{0,30}"))
                .Add("VName", (new InputField("Vorname")).AddRule("[A-ZÖÜ]{1}[a-zäöüß]{1,30}[ ]{0,1}[A-ZÖÜ]{0,1}[a-zäöüß]{0,30}"))
                .Add("Adresse", (new InputField("Adresse: Strasse Hausnummer/Stiege/Türnummer")).AddRule("[A-ZÖÜ]{1}[a-zäöüß]{1,30}[ ]{0,1}[-]{0,1}[A-ZÖÜ]{0,1}[a-zäöüß]{0,30}[ ]{0,1}[-]{0,1}[A-ZÖÜ]{0,1}[a-zäöüß]{0,30}[ ]{1}[1-9]{1}[0-9]{0,2}[-]{0,1}[1-9]{0,1}[0-9]{0,2}[/]{0,1}[1-9]{0,1}[/]{0,1}[1-9]{0,1}[0-9]{0,2}[-]{0,1}[1-9]{0,1}[0-9]{0,2}"))
                .Add("PLZ", (new InputField("Postleitzahl")).AddRule("[1-9][0-9]{3}"))
                .Add("Ort", (new InputField("Ort")).AddRule("[A-ZÖÜ][a-zäöüß]{1,30}[ ]{0,1}[-]{0,1}[A-ZÖÜ]{0,1}[a-zäöüß]{0,30}[ ]{0,1}[-]{0,1}[A-ZÖÜ]{0,1}[a-zäöüß]{0,30}"))
                .Add("Land", (new InputField("Land")).AddRule("[A-ZÖÜ][a-zäöüß]{1,30}[ ]{0,1}[-]{0,1}[A-ZÖÜ]{0,1}[a-zäöüß]{0,30}[ ]{0,1}[-]{0,1}[A-ZÖÜ]{0,1}[a-zäöüß]{0,30}"))
                .Add("TelNr", (new InputField("Telefonnummer \"+##0 #0 ##0 ##0 ##0\"")).AddRule("[+]{1}[1-9]{1}[0-9]{0,2}[ ]{1}[1-9]{1}[0-9]{0,2}[ ]{1}[1-9]{0,1}[0-9]{0,2}[ ]{0,1}[1-9]{0,1}[0-9]{0,2}[ ]{0,1}[1-9]{1}[0-9]{0,2}"))
                .Add("Email", (new InputField("E-Mail-Adresse")).AddRule("[a-z0-9A-Z]{1}[a-zA-Z0-9!#$%&'*+-/=?^_`{|}~.]{0,20}[a-z0-9A-Z]{1}[@]{1}[a-z]{2,20}[.]{1}[a-z]{2,3}"))
                .MoveTo(10, 10)
                .SetButton("Weiter")
                .SetButtonchange("Kunden List", Visible = true)
                .SetButtonmenu("Menu", Visible = true)
                .OnSubmit(() =>
                {
                    string sex = form["Geschl"];
                    string lastName = form["FName"];
                    string firstName = form["VName"];
                    string street = form["Adresse"];
                    int postalCcode = Convert.ToInt32(form["PLZ"]);
                    string location = form["Ort"];
                    string country = form["Land"];
                    decimal telNr = Convert.ToDecimal(form["TelNr"].Replace(" ", "").Remove(0, 1));
                    string email = form["Email"];
                    DateTime date = DateTime.Now;
                    costumer = new Costumer(sex, lastName, firstName, street, postalCcode, location, country, telNr, email);
                    StreamWriter writer = new StreamWriter("Costumer.csv", true);
                    string line = $"{costumer.Number};{costumer.Sex};{costumer.LastName};{costumer.FirstName};{costumer.Street};{costumer.PostalCcode};" +
                        $"{costumer.Location};{costumer.Country};{costumer.TelNr};{costumer.Email};{date}";
                    writer.WriteLine(line);
                    writer.Close();
                    MessageBox.Show($"Geschpeichert\n\n{lastName} {firstName} ({sex})");
                    InputField.ClearTextBox(this);
                    newcostId = true;
                    newSale = new NewSale();
                    this.Visible = false;
                    newSale.Visible = false;
                    newSale.ShowDialog();
                })
                .OnSubmitChange(() =>
                {
                    CostumersList costumersList = new CostumersList();
                    this.Visible = false;
                    costumersList.Visible = false;
                    costumersList.ShowDialog();
                })
                .OnSubmitMenu(() =>
                {
                    Menu menu = new Menu();
                    this.Visible = false;
                    menu.Visible = false;
                    menu.ShowDialog();
                });
        }

        public NewCostumer()
        {
            InitializeComponent();
            New_Costumer();
        }
    }
}
