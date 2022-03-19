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
    public partial class SalespersonsList : Form
    {
        InputForm form;
        List<Salespersons> salespersons;
        string[] personArray;

        void Salespersons_List()
        {

            salespersons = new List<Salespersons>();
            int counter = 0;
            if (File.Exists("Salesperson.csv"))
            {
                StreamReader reader = new StreamReader("Salesperson.csv", Encoding.Default);
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] record = line.Split(';');
                    int salesId = Convert.ToInt32(record[0]);
                    string lastName = record[1];
                    string firstName = record[2];
                    double provision = Convert.ToDouble(record[3]);
                    DateTime entry = Convert.ToDateTime(record[4]);
                    bool active = Convert.ToBoolean(record[5]);
                    if (!active)
                    {
                        counter++;
                    }
                    salespersons.Add(new Salespersons
                    {
                        _salesId = salesId,
                        _lastName = lastName,
                        _firstName = firstName,
                        _provision = provision,
                        _entry = entry,
                        _active = active
                    });
                    line = reader.ReadLine();
                }
                reader.Close();
            }

            personArray = new string[salespersons.Count - counter];
            for (int i = 0, j = 0; j < salespersons.Count; j++)
            {
                if (salespersons[j]._active)
                {
                    personArray[i] += salespersons[j]._salesId + ";" + salespersons[j]._lastName + 
                        ";" + salespersons[j]._firstName + ";" + salespersons[j]._provision + ";" + salespersons[j]._entry;
                    i++;
                }
            }

            form = new InputForm(this);
            form.Add("Employee", new InputSelect("Staff List:", personArray).SetSize(700))

                .MoveTo(10, 10)
                .SetButton("Kündigen")
                .SetButtonchange("Menu", Visible = true)
                .SetButtonmenu("", Visible = false)
                .OnSubmit(() =>
                {
                    string[] record = form["Employee"].Split(';');
                    int temporary_salesId = Convert.ToInt32(record[0]);
                    StreamWriter writer = new StreamWriter("Salesperson.csv");
                    foreach (Salespersons person in salespersons)
                    {
                        if (person._salesId == temporary_salesId)
                        {
                            person._active = false;
                        }
                        string line1 = $"{person._salesId};{person._lastName};{person._firstName};{person._provision};" +
                        $"{person._entry};{person._active}";
                        writer.WriteLine(line1);
                    }
                    writer.Close();
                    MessageBox.Show(form["Employee"] + " gekündigt");
                    NewSalesperson newSalesperson = new NewSalesperson();
                    this.Visible = false;
                    newSalesperson.Visible = false;
                    newSalesperson.ShowDialog();
                })
                .OnSubmitChange(() =>
                {
                    Menu menu = new Menu();
                    this.Visible = false;
                    menu.Visible = false;
                    menu.ShowDialog();
                });
        }
        public SalespersonsList()
        {
            InitializeComponent();
            Salespersons_List();
        }
    }
}
