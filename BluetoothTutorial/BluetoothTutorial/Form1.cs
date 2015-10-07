using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using InTheHand;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Ports;
using InTheHand.Net.Sockets;
using System.IO;
using InTheHand.Windows.Forms;
using InTheHand.Net;
using System.Net;
using System.Web;
using MySql;

using MySql.Data.MySqlClient;
 
 
namespace BluetoothTutorial
{
    public partial class Form1 : Form
    {
      
        SQLClient sqlClient = new SQLClient("localhost", "getaddress", "root", "");

        List<Device> userDevices=new List<Device>();       

        MySqlDataAdapter da = new MySqlDataAdapter();

        public Form1()
        {
            InitializeComponent();

           
        }
        private System.Windows.Forms.Timer timer1;

       
        private void btnGo_Click(object sender, EventArgs e)
        {  
            mainProgram();    
        }
        
       
        private void progressBar()
        {           
            progressBar1.Maximum = 100;          
            progressBar1.Value = 0;                                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
          this.ShowInTaskbar = false;  
           listBox2.Items.Add("NONE");
           listBox1.Items.Add("NONE");
           //InitDeviceList(); 
        }

        public void InitDeviceList()
        { 
            DataSet myData = new DataSet();
            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            MySql.Data.MySqlClient.MySqlDataAdapter myAdapter;

            conn = new MySql.Data.MySqlClient.MySqlConnection();
            cmd = new MySql.Data.MySqlClient.MySqlCommand();
            myAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter();

            conn.ConnectionString = "server=127.0.0.1;uid=root;" +
              "pwd=;database=getaddress;";


            try
            {
                cmd.CommandText = "SELECT address,username FROM usermac";
                cmd.Connection = conn;

                myAdapter.SelectCommand = cmd;
                myAdapter.Fill(myData);

                foreach (DataTable table in myData.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    { // read item
                        //  MessageBox.Show(item.ToString());
                        var a = row[1].ToString();
                        var b = row[0].ToString();
                        // MessageBox.Show(a.ToString());
                        userDevices.Add(new Device(a, b));
                        
                    }
                }
                //writes in xml file 
                //  myData.WriteXml(@"D:\dataset.xml", XmlWriteMode.WriteSchema);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

           mainProgram();


           if (radioButton1.Checked == true)
           {
               timer1.Start();


           }
           else
           {
               timer1.Stop();

           }
            
          
        }

        private void mainProgram()
        {
            userDevices.Clear();
            InitDeviceList(); 

            //Auto run method
            if (radioButton1.Checked == true)
            {
                timer1.Start();


            }
            else
            {
                timer1.Stop();

            } 
                 
            timer1.Stop();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            //how to automatically load button click 
            progressBar();

            BluetoothClient bc = new BluetoothClient();
            BluetoothDeviceInfo[] devices = bc.DiscoverDevices();

            //Drops known user table
            sqlClient.Drop("tblknown");
            //Creates known user table
            sqlClient.Create("tblknown", "id int NOT NULL AUTO_INCREMENT, name varchar(255),counting int NOT NULL ,PRIMARY KEY (id)");
          

            string a = "dadasd";
            string b = "";
            int number = 0;
            for (int i = 0; i < devices.Length; i++)
            {
                a = number + ") " + devices[i].DeviceName + "/" + "Address: " + devices[i].DeviceAddress + "\r\n";
                listBox2.Items.Add(a);
                b = devices[i].DeviceAddress.ToString()+"\r\n";
                //how to store all address 

             
                for (int j = 0; j < userDevices.Count; j++)
                {               
                    if (devices[i].DeviceAddress.ToString() == userDevices[j].Address)
                    {
                        //convert list items to string
                        string username = (userDevices[j].UserName.ToString().ToUpper());

                        //adds '' to string,so sql can accept as a char
                        string knownuser = "'" + username.Replace(",", "','") + "'";
                     
                        listBox1.Items.Add(userDevices[j].UserName);
                        
                        sqlClient.Insert("tblknown", "name", knownuser);
                        sqlClient.Update("tblknown", "counting =counting+1", "id=1"); 
                    }
                    
                } 
                number++; 
            }
             
         //   WelcomeMessage();   
            progressBar1.Value = 100;
            label1.Text = "Total Devices: " + devices.Length;
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                timer1.Start();                
                
            }
            else
            {
                timer1.Stop();                
            }
        }

     }

}  

       
 
  