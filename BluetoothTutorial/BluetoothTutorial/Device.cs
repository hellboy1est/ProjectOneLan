using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluetoothTutorial
{
    class Device
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public Device(string insertUsername,string insertAddress)
        {
            userName = insertUsername;
            address = insertAddress;

        }
    }
}
