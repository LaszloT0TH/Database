using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.InputForms
{
    /// <summary>
    /// Arrangement of input fields, buttons, data grid
    /// </summary>
    class InputForm : Panel
    {
        Dictionary<string, InputField> fields;
        Button button, buttonmenu, buttonchange;
        Action clickAction, CclickAction, MclickAction;

        public InputForm(Control parent)
        {
            Width = 1400;
            Height = 100;
            parent.Controls.Add(this);
            fields = new Dictionary<string, InputField>();

            button = new Button();
            button.Text = "Send";
            button.Font = new Font("sans-serif", 11f, FontStyle.Bold);
            button.Width = 150;
            button.Height = 35;

            this.Controls.Add(button);

            button.Top = 25;
            button.Left = 25;

            button.Click += OnClick;
            //---------------------------------------------------------------------
            buttonmenu = new Button();
            buttonmenu.Text = "Menu";
            buttonmenu.Font = new Font("sans-serif", 11f, FontStyle.Bold);
            buttonmenu.Width = 150;
            buttonmenu.Height = 35;

            this.Controls.Add(buttonmenu);

            buttonmenu.Top = 25;
            buttonmenu.Left = 25;

            buttonmenu.Click += OnClickmenu;
            //---------------------------------------------------------------------
            buttonchange = new Button();
            buttonchange.Text = "List";
            buttonchange.Font = new Font("sans-serif", 11f, FontStyle.Bold);
            buttonchange.Width = 150;
            buttonchange.Height = 35;

            this.Controls.Add(buttonchange);

            buttonchange.Top = 25;
            buttonchange.Left = 25;

            buttonchange.Click += OnClickchange;
        }
        ~ InputForm()
        { }
        public string this[string name]
        {
            get { return GetValue(name); }
        }
        public InputForm Add(string name, InputField field)
        {
            int y = 25 + (fields.Count * 50);
            fields.Add(name, field);
            field.Add(this);

            field.MoveTo(25, y);

            y += 60;
            button.Top = y;
            y += 50;
            Height = y;

            y += 0;
            buttonchange.Top = y;
            y += 50;
            Height = y;

            y += 0;
            buttonmenu.Top = y;
            y += 50;
            Height = y;

            y += 500;
            Height = y;
            return this;
        }
        public InputForm SetButtonPosition(int left)
        {
            button.Left = buttonchange.Left = buttonmenu.Left = left;
            return this;
        }
        public string GetValue(string name)
        {
            if (fields.ContainsKey(name))
            {
                return fields[name].Value;
            }
            return null;
        }
        public InputForm MoveTo(int x, int y)
        {
            Left = x;
            Top = y;
            return this;
        }
        public InputForm SetButton(string text, bool visible = true)
        {
            button.Text = text;
            if (!visible)
            {
                button.Hide();
            }
            return this;
        }
        public InputForm SetButtonmenu(string text, bool visible = true)
        {
            buttonmenu.Text = text;
            if (!visible)
            {
                buttonmenu.Hide();
            }
            return this;
        }
        public InputForm SetButtonchange(string text, bool visible = true)
        {
            buttonchange.Text = text;
            if (!visible)
            {
                buttonchange.Hide();
            }
            return this;
        }
        public InputForm OnSubmit(Action action)
        {
            clickAction += action;
            return this;
        }
        void OnClick(object sender, EventArgs e)
        {
            if (clickAction != null)
            {
                string error = GetError();
                if (error != null)
                {
                    string msg = $"Falsch ausgefüllt: {error}";
                    MessageBox.Show(msg, "Fehler");
                }
                else clickAction();
            }
        }
        string GetError()
        {
            foreach (string name in fields.Keys)
            {
                if (!fields[name].IsValid()) return name;
            }
            return null;
        }
        void OnClickmenu(object sender, EventArgs e)
        {
            MclickAction();
        }
        public InputForm OnSubmitChange(Action Caction)
        {
            CclickAction += Caction;
            return this;
        }
        public InputForm OnSubmitMenu(Action Maction)
        {
            MclickAction += Maction;
            return this;
        }
        void OnClickchange(object sender, EventArgs e)
        {
            CclickAction();
        }
    }
}
