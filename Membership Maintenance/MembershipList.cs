using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership_Maintenance
{

    class MembershipList : IEnumerable<Member>
    {

        public delegate void ChangeHandler(MembershipList memList);
        public event ChangeHandler Changed;
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
        public void Write()
        {
            MembershipData.GetMembership(this);
        }

        /// <summary>
        /// Writes file from the list of members
        /// </summary>
        public void Save()
        {
            MembershipData.SaveMembership(this);
        }

        public static MembershipList operator +(MembershipList memList, Member mem)
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

        public IEnumerator<Member> GetEnumerator()
        {
            return this._members.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._members.GetEnumerator();
        }
    }
}
