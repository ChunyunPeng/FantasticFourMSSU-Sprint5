﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LECCISLogin
{
  public partial class Login : Form
  {
    public Login()
    {
      InitializeComponent();
    }
        private MySqlConnection ConnectToDatabase()
        {
            string myconnection = "Server= 209.106.201.103; Database=group6; uid=dbstudent14;pwd=spicymonster10";
            MySqlConnection conn = new MySqlConnection(myconnection);
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("connection opened");
            }
            return conn;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(@"Server= 209.106.201.103; Database=group6; uid=dbstudent14;pwd=spicymonster10"))
            {
                MySqlCommand cmd = new MySqlCommand("select * from Users where username like @username and password = @password;");
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (loginSuccessful)
                {
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            //var UN = username.Text;
            //var PW = password.Text;
            ////if (PN == "" || EM == "")
            ////    MessageBox.Show("insert values");
            ////else
            ////{
            //MySqlConnection conn = ConnectToDatabase();


            //string sql = "INSERT INTO Property(username, password) VALUES (' " + this.username.Text + " ','" + this.password.Text + " ')";
            //using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            //{
            //    using (MySqlDataReader rdr = cmd.ExecuteReader())
            //    {
            //        while (rdr.Read())
            //        {
            //            MessageBox.Show(string.Format("{0} {1} ", rdr.GetInt32(0), rdr.GetString(1)));
            //        }
            //    }
            //}
            //conn.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
