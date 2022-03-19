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
    public partial class Menu : Form
    {
        InputForm form;
        void Saleperson()
        {
            form = new InputForm(this);
            form.Add("Menü", new InputSelect("Menü:", new string[] { "Neu Kunde hinzufügen", "Neu Auto hinzufügen" }).SetSize(200))

                .MoveTo(10, 10)
                .SetButton("Ok")
                .SetButtonchange("", Visible = false)
                .SetButtonmenu("", Visible = false)
                .OnSubmit(() =>
                {
                    switch (form["Menü"])
                    {
                        case "Neu Kunde hinzufügen":
                            {
                                NewCostumer newCostumer = new NewCostumer();
                                this.Visible = false;
                                newCostumer.Visible = false;
                                newCostumer.ShowDialog();

                                break;
                            }
                        case "Neu Auto hinzufügen":
                            {
                                NewCar newCar = new NewCar();
                                this.Visible = false;
                                newCar.Visible = false;
                                newCar.ShowDialog();
                                break;
                            }
                        default:
                            break;
                    }
                })
                .OnSubmitChange(() =>
                {

                });
        }
        void Boss()
        {
            form = new InputForm(this);
            form.Add("Menü", new InputSelect("Menü:", new string[] { "Neu Kunde hinzufügen", "Neu Auto hinzufügen",
                "Neu VerkäuferIn hinzufügen oder kündigen", "Benutzernamen und Passwörter", "Abfragen von Daten" }).SetSize(350))
                .MoveTo(10, 10)
                .SetButton("Ok")
                .SetButtonchange("", Visible = false)
                .SetButtonmenu("", Visible = false)
                .OnSubmit(() =>
                {
                    switch (form["Menü"])
                    {
                        case "Neu Kunde hinzufügen":
                            {
                                NewCostumer newCostumer = new NewCostumer();
                                this.Visible = false;
                                newCostumer.Visible = false;
                                newCostumer.ShowDialog();
                                break;
                            }
                        case "Neu Auto hinzufügen":
                            {
                                NewCar newCar = new NewCar();
                                this.Visible = false;
                                newCar.Visible = false;
                                newCar.ShowDialog();
                                break;
                            }
                        case "Neu VerkäuferIn hinzufügen oder kündigen":
                            {
                                NewSalesperson newSalesperson = new NewSalesperson();
                                this.Visible = false;
                                newSalesperson.Visible = false;
                                newSalesperson.ShowDialog();
                                break;
                            }
                        case "Benutzernamen und Passwörter":
                            {
                                UsernamesAndPasswords usernamesAndPasswords = new UsernamesAndPasswords();
                                this.Visible = false;
                                usernamesAndPasswords.Visible = false;
                                usernamesAndPasswords.ShowDialog();
                                break;
                            }
                        case "Abfragen von Daten":
                            {
                                Query query = new Query();
                                this.Visible = false;
                                query.Visible = false;
                                query.ShowDialog();
                                break;
                            }
                        default:
                            break;
                    }
                })
                .OnSubmitChange(() =>
                {

                });
        }
        public Menu()
        {
            InitializeComponent();
            if (!Login.flag)
            {
                label1.Visible = true;
                label1.Location = new Point(320, 180);
                label1.Size = new Size(125, 45);
                label1.Text = "Zugriff abgelehnt";
                label1.Font = new Font("sans-serif", 15f);
                label1.AutoSize = true;
            }
            else
            {
                List<Logins> logins = new List<Logins>();
                StreamReader reader = new StreamReader("Login.csv", Encoding.Default);
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] record = line.Split(';');
                    
                    string username = record[0];
                    string pasword = record[1];
                    DateTime date = Convert.ToDateTime(record[2]);
                    logins.Add(new Logins {Username = username, Pasword = pasword, Date = date });
                    line = reader.ReadLine();
                }
                reader.Close();
                
                Logins log = logins[logins.Count - 1];
                if (log.Username == "chef")
                {
                    Boss();
                }
                else
                {
                    Saleperson();
                }
            }
        }
    }
}
