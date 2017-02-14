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

        MembershipList memberList = new MembershipList();
        public Membership_Maintenance()
        {
            InitializeComponent();
            listBox1.DataSource = memberList.getList();
            
        }

        //Add
        private void Add_Click(object sender, EventArgs e)
        {
            Add_Membership add = new Add_Membership();
            var dialog = add.ShowDialog();
            Member newMem = new Member(add.FirstName, add.LastName, add.Email);
            if (dialog == DialogResult.OK && !memberList.contains(newMem))
            {
                memberList.Add(newMem);
            }
            else if (dialog == DialogResult.OK)
            {
                MessageBox.Show("User already in database", "Duplicate User", MessageBoxButtons.OK);
            }

            listBox1.DataSource = memberList.getList();

        }

        //Delete
        private void Delete_Click(object sender, EventArgs e)
        {

            listBox1.SelectedItem
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
