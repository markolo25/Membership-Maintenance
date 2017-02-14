using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Membership_Maintenance
{
    public partial class Membership_Maintenance : Form
    {
        
        List<string> _items = new List<string>();
        public Membership_Maintenance()
        {
            InitializeComponent();
            listBox1.DataSource = _items;
        }

        //Add
        private void Add_Click(object sender, EventArgs e)
        {
            Add_Membership add = new Add_Membership();
            var dialog = add.ShowDialog();
            var doug = new Member(add.FirstName, add.LastName, add.Email);
            _items.Add(doug.GetDisplayText());
            listBox1.DataSource = null;
            listBox1.DataSource = _items;


        }

        //Delete
        private void Delete_Click(object sender, EventArgs e)
        {

        }

        //Exit
        private void Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
