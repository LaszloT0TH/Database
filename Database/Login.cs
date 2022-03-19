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
    public partial class Login : Form
    {
        public static bool flag = false;
        InputForm form;
        List<Usernames_And_Passwords> usernames_And_Passwords = new List<Usernames_And_Passwords>();
        void Start()
        {
            
            form = new InputForm(this);
            form.Add("Username", (new InputField("Geben Sie bitte Ihre Benutzername ein: chef")))
                .Add("Pasword", (new InputField("Geben Sie bitte Ihre Passwort ein: boss00")))

                .MoveTo(200, 150)
                .SetButton("Ok")
                .SetButtonchange("", Visible = false)
                .SetButtonmenu("", Visible = false)
                .OnSubmit(() =>
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
                    
                    if (usernames_And_Passwords.Contains(new Usernames_And_Passwords { _usernames = form["Username"], _passwords = form["Pasword"] }))
                    {
                        flag = true;
                        DateTime date = DateTime.Now;
                        StreamWriter writer = new StreamWriter("Login.csv", true);
                        string line = $"{form["Username"]};{form["Pasword"]};{date}";

                        writer.WriteLine(line);
                        writer.Close();
                    }
                    else
                    {
                        MessageBox.Show("Geben Sie korrekte Details ein");
                        InputField.ClearTextBox(this);
                    }
                    if (flag)
                    {
                        this.Close();
                    }
                });

        }

        public Login()
        {
            InitializeComponent();
            Start();
        }
    }
}
