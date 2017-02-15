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
    /// <summary>
    /// Class for adding membership
    /// </summary>
    public partial class Add_Membership : Form
    {
        private string _firstName;
        private string _lastName;
        private string _email;

        /// <summary>
        /// Properties for First Name
        /// </summary>
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
        
        /// <summary>
        /// Properties for Last Name
        /// </summary>
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

        /// <summary>
        /// Properties for Email
        /// </summary>
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

        /// <summary>
        /// Constructors for Add_Memebership
        /// </summary>
        public Add_Membership()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Method called when Save_Button_Click even is triggered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (Validator.LengthInRange(FirstName_TextBox, 0, 25)
                && Validator.LengthInRange(LastName_TextBox, 0, 25)
                && Validator.LengthInRange(Email_TextBox, 0, 25)
                && Validator.IsPresent(FirstName_TextBox)
                && Validator.IsPresent(LastName_TextBox)
                && Validator.IsPresent(Email_TextBox)
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

        /// <summary>
        /// Method called when Cancel_Button_Clieck event is triggered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FirstName_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
