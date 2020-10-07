﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prog3
{
    public partial class EventUpdatePage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            /*
            * If it is a postback the previously selected date
            * calenders selected date and text is shown
            */

            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
            {
               
                Calendar1.SelectedDate = calendar.SelectedDate;
                lblDateSelected.Text = Calendar1.SelectedDate.ToShortDateString();
            }
        }



            /*
            * Creates a connection with the database. That 
            * connection is then used to insert the event.
            */
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand("Insert INTO eventsTable(Event_Name, Date) VALUES (@Event_Name, @Date)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Event_Name", txtEventName.Text);
            cmd.Parameters.AddWithValue("@Date", Calendar1.SelectedDate);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            Response.Redirect("EventDisplayPage.aspx");
        }
    }
}