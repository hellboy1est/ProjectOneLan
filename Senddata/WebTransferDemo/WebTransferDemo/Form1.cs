﻿using System;
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
        WebClient client = new WebClient();

        SQLClient sqlClient = new SQLClient("localhost", "getaddress", "root", "");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            sqlClient.Insert("tbladdress", "address", "123");   
            
            
            //try
            //{
            //    string connection = "server=127.0.0.1; database=getaddress;user=root; password=;";
            //    MySqlConnection conn = new MySqlConnection(connection);
            //    conn.Open();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

 
        }
    }
}
