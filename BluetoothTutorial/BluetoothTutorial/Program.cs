using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BluetoothTutorial
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }
        static void OnProcessExit(object sender, EventArgs e)
        {

            SQLClient sqlClient = new SQLClient("localhost", "getaddress", "root", "");

            //Drops known user table
            sqlClient.Drop("tblknown");
            //Creates known user table
            sqlClient.Create("tblknown", "id int NOT NULL AUTO_INCREMENT, name varchar(255),PRIMARY KEY (id)");
        }
        
    }
}
