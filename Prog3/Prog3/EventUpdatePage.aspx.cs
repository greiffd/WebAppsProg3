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

        protected void Page_Load(object sender, EventArgs e)
        {
            //EventDisplayPage eventDisplayPage = (EventDisplayPage)this.Page.PreviousPage;
            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
            {
                Calendar calendar = (Calendar) PreviousPage.Master.FindControl("ContentPlaceHolder5").FindControl("Calendar2");
                Calendar1.SelectedDate = calendar.SelectedDate;
                lblDateSelected.Text = Calendar1.SelectedDate.ToShortDateString();
            }
            else
            {
                // Does not do any load functions
            }
        }

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