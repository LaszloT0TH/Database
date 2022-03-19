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
    public partial class UsernamesAndPasswordsList : Form
    {
        InputForm form;
        List<Usernames_And_Passwords> usernames_And_Passwords = new List<Usernames_And_Passwords>();
        string[] UAPArray;

        void Usernames_And_Passwords_List()
        {
            if (File.Exists("UsernameAndPasswords.csv"))
            {
                StreamReader reader = new StreamReader("UsernameAndPasswords.csv", Encoding.Default);
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] record = line.Split(';');
                    string username = record[0];
                    string pasword = record[1];
                    usernames_And_Passwords.Add(new Usernames_And_Passwords { _usernames = username, _passwords = pasword });
                    line = reader.ReadLine();
                }
                reader.Close();
            }
            UAPArray = new string[usernames_And_Passwords.Count];
            for (int i = 0; i < usernames_And_Passwords.Count; i++)
            {
                UAPArray[i] += usernames_And_Passwords[i]._usernames
                     + ";" + usernames_And_Passwords[i]._passwords;
            }

            form = new InputForm(this);
            form.Add("UAP", new InputSelect("Benutzernamens und Passwörters:", UAPArray).SetSize(350))

                .MoveTo(10, 10)
                .SetButton("Löschen")
                .SetButtonchange("Neu", Visible = true)
                .SetButtonmenu("Menu", Visible = true)
                .OnSubmit(() =>
                {
                    string[] record = form["UAP"].Split(';');
                    string temporaryCarNumber = record[0];
                    StreamWriter writer = new StreamWriter("UsernameAndPasswords.csv");
                    foreach (Usernames_And_Passwords u_a_p in usernames_And_Passwords)
                    {
                        if (u_a_p._usernames != temporaryCarNumber)
                        {
                            string line = $"{u_a_p._usernames};{u_a_p._passwords}";
                            writer.WriteLine(line);
                        }  
                    }
                    writer.Close();
                    MessageBox.Show(form["UAP"]);
                    InputField.ClearTextBox(this);
                })
                .OnSubmitChange(() =>
                {
                    UsernamesAndPasswords usernamesAndPasswords = new UsernamesAndPasswords();
                    this.Visible = false;
                    usernamesAndPasswords.Visible = false;
                    usernamesAndPasswords.ShowDialog();
                })
                .OnSubmitMenu(() =>
                {
                    Menu menu = new Menu();
                    this.Visible = false;
                    menu.Visible = false;
                    menu.ShowDialog();
                });
        }
        public UsernamesAndPasswordsList()
        {
            InitializeComponent();
            Usernames_And_Passwords_List();
        }
    }
}
