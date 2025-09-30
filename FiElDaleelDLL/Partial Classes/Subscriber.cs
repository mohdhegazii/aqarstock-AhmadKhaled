using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
    public partial class Subscriber
    {
        string _Password;
        string _NewPassword;
        bool _ChangePassword;

        public bool ChangePassword
        {
            get { return _ChangePassword; }
            set { _ChangePassword = value; }
        }
        public virtual string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        public string NewPassword
        {
            get { return _NewPassword; }
            set { _NewPassword = value; }
        }
        public virtual string FullAndUserName
        {
            get {
                return this.FullName + " - (" + this.UserName + " )";
            }
        }
    }
}
