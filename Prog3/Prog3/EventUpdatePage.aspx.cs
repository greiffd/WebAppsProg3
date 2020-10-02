using System;
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
        private DateTime date;

        public Label updateLabel { get { return lblUpdatedName; } }

        Calendar calendar;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack/*!IsPostBack*/)
            {
                calendar = PreviousPage.eventCalendar;
                date = calendar.SelectedDate;
                //lblUpdatedName.Text = PreviousPage.labelEventName.Text;
            }
            else
            {
                lblUpdatedName.Text = "Not postback";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //date = calendar.SelectedDate;

            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand("Insert INTO eventsTable(Event_Name, Date) VALUES (@Event_Name, @Date)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Event_Name", txtEventName.Text);
            cmd.Parameters.AddWithValue("@Date", date);
            con.Open();
            int i = cmd.ExecuteNonQuery();
        }
    }
}