using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership_Maintenance
{

    /// <summary>
    /// Collections Class for Member Types
    /// </summary>
    class MembershipList : IEnumerable<Member>
    {

        public delegate void ChangeHandler(MembershipList memList);
        public event ChangeHandler Changed;
        List<Member> _members;

        /// <summary>
        /// Default Constructor for MemberList
        /// Initialize _members as a List\<Member> 
        /// </summary>
        public MembershipList()
        {
            _members = new List<Member>();
        }

        public Member this[int i]
        {
            get
            {
                return _members[i];
            }
            set
            {
                _members[i] = value;
            }
        }

        /// <summary>
        /// Property to access the .Count of
        /// Memberlist
        /// </summary>
        public int Count
        {
            get
            {
                return _members.Count();
            }
        }

        /// <summary>
        /// Method for adding a member to the MembershipList
        /// </summary>
        /// <param name="mem">member being added</param>
        public void Add(Member mem)
        {
            if (!this.contains(mem))
            {
                _members.Add(mem);
            }
            try
            {
                if (Changed != null)
                {
                    Changed(this);
                }
            }
            catch { }

        }

        /// <summary>
        /// Method for removing a member to the MembershipList
        /// </summary>
        /// <param name="mem">member being removed</param>
        public void Remove(Member mem)
        {
            try
            {
                _members.Remove(mem);
                if (Changed != null)
                {
                    Changed(this);
                }
            }
            catch { }
        }

        /// <summary>
        /// Reads file and adds to list of members
        /// </summary>
        public void Write()=> MembershipData.GetMembership(this);

        /// <summary>
        /// Writes file from the list of members
        /// </summary>
        public void Save()=> MembershipData.SaveMembership(this);


        /// <summary>
        /// Overloads + operator to call the add function
        /// </summary>
        /// <param name="memList"></param>
        /// <param name="mem"></param>
        /// <returns></returns>
        public static MembershipList operator +(MembershipList memList, Member mem)
        {
            memList.Add(mem);
            return memList;
        }


        /// <summary>
        /// Overloads the - operator to call the remove function
        /// </summary>
        /// <param name="memList"></param>
        /// <param name="mem"></param>
        /// <returns></returns>
        public static MembershipList operator -(MembershipList memList, Member mem)
        {
            memList.Remove(mem);
            return memList;
        }

        /// <summary>
        /// Method to generate a List<string> for filling in the textbox
        /// </summary>
        /// <returns>List<string> for listbox</returns>
        public List<string> getList()
        {
            List<string> listBox = new List<string>();
            foreach (Member mem in _members)
            {
                listBox.Add(mem.GetDisplayText());
            }
            return listBox;
        }

        /// <summary>
        /// Checks if a member is in Memberlist
        /// </summary>
        /// <param name="mem"></param>
        /// <returns></returns>
        public bool contains(Member mem) => _members.Contains(mem);

        /// <summary>
        /// returns _member's IEnumerator
        /// by calling .GetEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Member> GetEnumerator()
        {
            return this._members.GetEnumerator();
        }

        /// <summary>
        /// returns _member's IEnumerator
        /// by calling .GetEnumerator
        /// </summary>
        /// <returns>IEnumertor belonging to the memberclass</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._members.GetEnumerator();
        }
    }
}
