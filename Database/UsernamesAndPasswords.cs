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
    public partial class UsernamesAndPasswords : Form
    {
        InputForm form;
        Username_And_Passwords username_And_Passwords;
        void Usernames_And_Passwords()
        {
            form = new InputForm(this);
            form.Add("Username", (new InputField("Neu Benutzername (Nummer und kleine Buchstaben)")).AddRule("[a-zäöüß0-9]{1,30}"))
                .Add("Pasword", (new InputField("Neu Passwort die letzte zwei Karakter muss salesId Nummer sein ")).AddRule("[A-ZÖÜÄa-zäöüß,.&@#0-9]{1,30}"))
                
                .MoveTo(10, 10)
                .SetButton("Speichern")
                .SetButtonchange("List", Visible = true)
                .SetButtonmenu("Menu", Visible = true)
                .OnSubmit(() =>
                {
                    string username = form["Username"];
                    string pasword = form["Pasword"];
                    username_And_Passwords = new Username_And_Passwords(username, pasword);
                    StreamWriter writer = new StreamWriter("UsernameAndPasswords.csv", true);
                    string line = $"{username_And_Passwords.Usernames};{username_And_Passwords.Passwords}";
                    writer.WriteLine(line);
                    writer.Close();
                    MessageBox.Show($"Geschpeichert\n\n{username} {pasword}");
                    InputField.ClearTextBox(this);
                })
                .OnSubmitChange(() =>
                {
                    UsernamesAndPasswordsList usernamesAndPasswordsList = new UsernamesAndPasswordsList();
                    this.Visible = false;
                    usernamesAndPasswordsList.Visible = false;
                    usernamesAndPasswordsList.ShowDialog();

                })
                .OnSubmitMenu(() =>
                {
                    Menu menu = new Menu();
                    this.Visible = false;
                    menu.Visible = false;
                    menu.ShowDialog();
                });
        }
        public UsernamesAndPasswords()
        {
            InitializeComponent();
            Usernames_And_Passwords();
        }
    }
}
