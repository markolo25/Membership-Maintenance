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
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Membership_Maintenance()
        {
            InitializeComponent();
            memberList.Write();
            MembershipData.GetMembership(memberList);
            listBox1.DataSource = memberList.getList();

        }

        /// <summary>
        /// Function called when Add_Click event is Triggered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, EventArgs e)
        {
            memberList.Changed += new MembershipList.ChangeHandler(MembershipData.SaveMembership);
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

        /// <summary>
        /// Function Called when Delete_Click event is triggered 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, EventArgs e)
        {
            memberList.Changed += new MembershipList.ChangeHandler(MembershipData.SaveMembership);
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex != -1)
            {
                {
                    try
                    {
                        DialogResult button = MessageBox.Show("Are you sure you want to delete",
                            "Confirm Delete", MessageBoxButtons.YesNo);
                        if (button == DialogResult.Yes)
                        {
                            memberList -= memberList[selectedIndex];
                        }
                    }
                    catch
                    {
                    }
                    listBox1.DataSource = memberList.getList();
                }
            }

        }

        /// <summary>
        /// Function called when Exit_Click event is triggered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, EventArgs e)
        {
            memberList.Save();
            System.Windows.Forms.Application.Exit();
        }
    }
}
