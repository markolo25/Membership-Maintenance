using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Membership_Maintenance
{
    public partial class Add_Membership : Form
    {
        private string _firstName;
        private string _lastName;
        private string _email;

        public string FirstName
        {
            get
            {

                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public Add_Membership()
        {
            InitializeComponent();

        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (Validator.LengthInRange(FirstName_TextBox, 0, 25)
                && Validator.LengthInRange(LastName_TextBox, 0, 25)
                && Validator.LengthInRange(Email_TextBox, 0, 25)
                && Validator.IsValidEmail(Email_TextBox))
            {
                this._firstName = FirstName_TextBox.Text;
                this._lastName = LastName_TextBox.Text;
                this._email = Email_TextBox.Text;
            }
            else
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
