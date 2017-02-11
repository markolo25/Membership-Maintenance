using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership_Maintenance
{
    class Member
    {
        private string _firstName;
        private string _lastName;
        private string _email;

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value.Length > 25)
                {
                    _email = value;
                }
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
                if (value.Length > 25)
                {
                    _lastName = value;
                }
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value.Length > 25)
                {
                    _firstName = value;
                }
            }
        }


        public Member()
        {

        }
        
        public Member(string FirstName, string LastName, string Email )
        {
            _firstName = FirstName;
            _lastName = LastName;
            _email = Email;
        }

        public string GetDisplayText()
        {
            return _firstName + " " + _lastName + " - " + _email;
        }
    }
}
