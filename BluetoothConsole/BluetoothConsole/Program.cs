using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InTheHand;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Ports;
using InTheHand.Net.Sockets;

using MySql;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

namespace BluetoothConsole
{
    class Program
    {

       public static SQLClient sqlClient = new SQLClient("localhost", "getaddress", "root", "");

       public static List<Device> userDevices = new List<Device>();

       static ManualResetEvent _quitEvent = new ManualResetEvent(false);

        static void Main(string[] args)
       {
           
               //Runs Method
               InitDeviceList();
              
               //Drops known user table
               sqlClient.Drop("tblknown");
               //Creates known user table
               sqlClient.Create("tblknown", "id int NOT NULL AUTO_INCREMENT, name varchar(255),counting int NOT NULL ,address int,PRIMARY KEY (id)");

               BluetoothClient bc = new BluetoothClient();
           BluetoothDeviceInfo[] devices = bc.DiscoverDevices();
               
                   string a = "dadasd";
                   int number = 0;

                   if (devices.Length == 0)
                   {
                       Console.WriteLine("Empty set");
                   }
                   else

                       for (int i = 0; i < devices.Length; i++)
                       {
                           a = number + ") " + devices[i].DeviceName + "/" + "Address: " + devices[i].DeviceAddress + "\r\n";

                           for (int j = 0; j < userDevices.Count; j++)
                           {
                               if (devices[i].DeviceAddress.ToString() == userDevices[j].Address)
                               {
                                   //convert list items to string
                                   string username = (userDevices[j].UserName.ToString().ToUpper());
                                   string address = (userDevices[j].Address.ToString().ToUpper());
                                   //adds '' to string,so sql can accept as a char
                                   string knownuser = "'" + username.Replace(",", "','") + "'";
                                   string knownaddress = "'" + address.Replace(",", "','") + "'";

                                   //  listBox1.Items.Add(userDevices[j].UserName);


                                   sqlClient.Insert("tblknown", "name", knownuser);
                                   sqlClient.Update("tblknown", "counting =counting+1", "id=1");
                               }

                           }

                           number++;
                           Console.WriteLine(a);
                          
                       }
                   Console.ReadLine();
        }
         
       
        //Adds Devices manually to userDevices instance
        static void InitDeviceList()
        {
            userDevices.Add(new Device("Rahul", "08FC88541032"));
            userDevices.Add(new Device("John", "3C915712CAC1"));
            userDevices.Add(new Device("Chris", "F06BCA92E623"));
            userDevices.Add(new Device("Catherine", "00F46FACBD86"));
            userDevices.Add(new Device("Tanuj", "D40B1AFC74D6"));
            userDevices.Add(new Device("Paul", "AE3C4666286A"));
            userDevices.Add(new Device("Elvis", "2CD05A133FD2"));
        }
      

    }
}
