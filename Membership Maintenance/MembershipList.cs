using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership_Maintenance
{
    class MembershipList
    {
        List<Member> _members;

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

        public int Count
        {
            get
            {
                return _members.Count();
            }
        }

        public void Add(Member mem)
        {
            _members.Add(mem);
        }

        public void Remove(Member mem)
        {
            _members.Remove(mem);
        }

        /// <summary>
        /// Reads file and adds to list of members
        /// </summary>
        public void Write()
        {
            
        }

        /// <summary>
        /// Writes file from the list of members
        /// </summary>
        public void Save()
        {

        }

        public static MembershipList operator+ (MembershipList memList, Member mem)
        { 
            memList.Add(mem);
            return memList;
        }

        public static MembershipList operator -(MembershipList memList, Member mem)
        {
            memList.Remove(mem);
            return memList;
        }

        public List<string> getList()
        {
            List<string> listBox = new List<string>();
            foreach (Member mem in _members)
            {
               listBox.Add(mem.GetDisplayText());
            }
            return listBox;
        }

        public bool contains(Member mem)
        {
            return _members.Contains(mem);
        }










    }
}
