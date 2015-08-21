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
 
namespace BluetoothTutorial
{
    public partial class Form1 : Form
    {        
        List<Device> userDevices=new List<Device>();             
        public Form1()
        {
            InitializeComponent(); 
           
        }
        private System.Windows.Forms.Timer timer1; 
        
        private void btnGo_Click(object sender, EventArgs e)
        {
            mainProgram();    
                
                //if (b == "08FC88541032")
                //{
                //    //only last address gets stored? needs all to check
                //    label3.Text += "Rahul";
                //  //  MessageBox.Show("Hello Rahul ");
                //}
                //else if (b == "3C915712CAC1")
                //{
                //    //only last address gets stored? needs all to check
                //    label3.Text += "John";
                //  //  MessageBox.Show("Hello John ");
                //}
                //else if(b=="E899C4127E5F")
                //{
                //    label3.Text += "Elvis";
                //   // MessageBox.Show("Hello Elvis ");
                //} 
                 
                //SelectBluetoothDeviceDialog sbdd = new SelectBluetoothDeviceDialog();         
                //sbdd.ShowUnknown = true;
                //sbdd.ShowRemembered = true;
                //sbdd.ShowAuthenticated = true;


                //if (sbdd.ShowDialog() == DialogResult.OK)
                //{
                //    tbOutput.AppendText("Device Name: "+ sbdd.SelectedDevice.DeviceName+"\r\n");
                //    tbOutput.AppendText("Device Address: " + sbdd.SelectedDevice.DeviceAddress.ToString() + "\r\n");
                //    tbOutput.AppendText("Remembered: " + sbdd.ShowRemembered.ToString() + "\r\n");
                //    tbOutput.AppendText("Last Used: " + sbdd.SelectedDevice.LastUsed.ToString()+ "\r\n");
                //    tbOutput.AppendText("Last Seen: " + sbdd.SelectedDevice.LastSeen.ToString()+"\r\n");
                //    tbOutput.AppendText("Connected: " + sbdd.SelectedDevice.Connected.ToString());
                //}

             
            }
        
       
        private void progressBar()
        {           
            progressBar1.Maximum = 100;          
            progressBar1.Value = 0;                                
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            listBox2.Items.Add("NONE");
            listBox1.Items.Add("NONE");
            InitDeviceList();



            webBrowser1.DocumentText =
             "<html><head><meta http-equiv='refresh' content='0; url=https://www.op.ac.nz/hub/' /> </head><body>" +

             "</body></html>";
             
        }

        public void InitDeviceList()
        {
            userDevices.Add(new Device("Rahul", "08FC88541032"));
            userDevices.Add(new Device("John", "3C915712CAC1"));
            userDevices.Add(new Device("Chris", "f06bca92e623"));
            userDevices.Add(new Device("Catherine", "00F46FACBD86"));
            userDevices.Add(new Device("Tanuj", "D40B1AFC74D6"));
            userDevices.Add(new Device("Paul", "AE3C4666286A"));
            userDevices.Add(new Device("Vincent", "A4DB30BEBC4E"));
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

            string a = "dadasd";
            string b = "";
            int number = 0;
            for (int i = 0; i < devices.Length; i++)
            {
                a = number + ") " + devices[i].DeviceName + "/" + "Address: " + devices[i].DeviceAddress + "\r\n";
                listBox2.Items.Add(a);
                b = devices[i].DeviceAddress.ToString();
                //how to store all address 

                for (int j = 0; j < userDevices.Count; j++)
                {
                    if (devices[i].DeviceAddress.ToString() == userDevices[j].Address)
                    {
                        listBox1.Items.Add(userDevices[j].UserName);
                    }

                }
             
                number++;
                    
            }

            WelcomeMessage();   
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

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
           
        }

        private void WelcomeMessage()
        {

            if (listBox1.Items.Count > 0)
            {
                // It contains items

                //if (listBox1.Items.Contains("John"))
                //{
                //    webBrowser1.DocumentText =
                //             "<html><body>" +
                //             "<h1>Welcome John</h1>" +
                //             "</body></html>";

                //}
                //else if
                if (listBox1.Items.Contains("Rahul"))
                {
                    // https://accounts.google.com/ServiceLogin?continue=https%3A%2F%2Fhistory.google.com%2Fhistory%2F&sacu=1&passive=1209600&acui=0#Email=hellboy1est%40gmail.com
                   webBrowser1.DocumentText =
                         "<html><head><meta http-equiv='refresh' content='0; url=http://webdev.ict.op.ac.nz/kakkr1/web3Final/' /> </head><body>" +
                         "</body></html>";
                      
                }
                else if (listBox1.Items.Contains("Tanuj"))
                {
                    webBrowser1.DocumentText =
                             "<html><body>" +
                             "<h1>Welcome Tanuj</h1>" +
                             "</body></html>";

                }
                else
                {
                    // It doesn't

                    webBrowser1.DocumentText =
                                "<html><head><meta http-equiv='refresh' content='0; url=https://www.op.ac.nz/hub/' /></head><body>" +

                                "</body></html>";
                }

            }
            else
            {
                // It doesn't

                webBrowser1.DocumentText =
                            "<html><head><meta http-equiv='refresh' content='0; url=https://www.op.ac.nz/hub/' /></head><body>" +

                            "</body></html>";
            }
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
 
         

      
 
 
    }
}
