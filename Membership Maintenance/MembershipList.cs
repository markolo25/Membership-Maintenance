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


    }
}
