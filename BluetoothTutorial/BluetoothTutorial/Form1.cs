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
        
        public Form1()
        {
            InitializeComponent();

           
        }
        private System.Windows.Forms.Timer timer1; 
        
        private void btnGo_Click(object sender, EventArgs e)
        {
          //  SendData();


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
                ////////////    tbOutput.AppendText("Remembered: " + sbdd.ShowRemembered.ToString() + "\r\n");
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
            userDevices.Add(new Device("Chris", "F06BCA92E623"));
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
            //Drops known user table
            sqlClient.Drop("tblknown");
            //Creates known user table
            sqlClient.Create("tblknown", "id int NOT NULL AUTO_INCREMENT, name varchar(255),PRIMARY KEY (id)");

            //Auto update
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
                
                if (listBox1.Items.Contains("Rahul"))
                {                     
                    webBrowser1.DocumentText =
                          "<html><head><meta http-equiv='refresh' content='0; url=http://webdev.ict.op.ac.nz/kakkr1/web3Final/' /> </head><body>" +
                          "</body></html>";

                }
                //else if (listBox1.Items.Contains("John"))                 
                //{
                //    webBrowser1.DocumentText =
                //             "<html><body>" +
                //             "<h1>Welcome John</h1>" +
                //             "</body></html>";
                      
                //}
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
        private void SendData()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string webData = wc.DownloadString("http://kate.ict.op.ac.nz/~kakkr1/Assignment2/add.html");
            
            MessageBox.Show(webData);

        }

         private void ds()
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://kate.ict.op.ac.nz/~kakkr1/Assignment2/homePage.php ");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream objectx .
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            MessageBox.Show(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
 
 
    }
}
