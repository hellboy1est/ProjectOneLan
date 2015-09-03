using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using MySql;

using MySql.Data.MySqlClient;

namespace WebTransferDemo
{
    public partial class Form1 : Form
    {  
        SQLClient sqlClient = new SQLClient("localhost", "getaddress", "root", "");
        public string address;
        public int[] ass=new int[5]  { 1, 2, 3, 4, 5};

        string user = "";
        string message = "";

        public Form1()
        {
            InitializeComponent();
            address="'12SD34'";
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = textBox1.Text.ToUpper();
            message = textBox2.Text.ToUpper();           
            

            //adds '' to string,so sql can accept as a char
            string knownuser = "'" + user.Replace(",", "','") + "'";           

            //adds '' to string,so sql can accept as a char
            string message_user = "'" + message.Replace(",", "','") + "'";

          sqlClient.Update("usermac", "message="+ message_user, "username=" +knownuser);
        //  sqlClient.Update("usermac", "message='Welcome Rahul kakkar'", "username='RAHUL KAKKAR'");
        //  sqlClient.Update("usermac", "message='Hello tanuj'", "username='TANUJ'");
        //  sqlClient.Update("usermac", "message='John, how are you'", "username='JOHN'"); 


            for (int i = 0; i < ass.Length; i++)
            { 
//                sqlClient.Insert("usermac", "message", ass[i].ToString());

                 
            }
 
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

     
    }
}
 