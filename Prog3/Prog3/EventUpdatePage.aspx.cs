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

            /*
            * If it is a postback the previously selected date
            * calenders selected date and text is shown
            */

            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack)
            {
                Calendar calendar = (Calendar)PreviousPage.Master.FindControl("ContentPlaceHolder5").FindControl("Calendar2");
                Calendar1.SelectedDate = calendar.SelectedDate;
                lblDateSelected.Text = Calendar1.SelectedDate.ToShortDateString();
                UpdateGridview();
            }
        }

        /*
         * Fills the Gridview with the events in the database.
         */
        private void UpdateGridview()
        {
            List<int> eventIds = GetValidEvents(Calendar1.SelectedDate);

            if (eventIds.Count > 0)
            {
                GridView1.Visible = true;
                string idString = "";
                int count = 0;
                while (count < eventIds.Count)
                {
                    if (count != eventIds.Count - 1)
                    {
                        idString += eventIds[count] + " or id = ";
                    }
                    else
                    {
                        idString += eventIds[count];
                    }
                    count++;
                }

                /*
                * Connects to database and inserts data into gridview
                */
                string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(cs);

                string command = "select Id, Event_Name" + /*, Date */ " from eventsTable where id =" + idString;
                SqlDataAdapter adapt = new SqlDataAdapter(command, con);
                con.Open();
                adapt.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            else
                GridView1.Visible = false;

        }

        /*
         * Queries the database for the events that fall under the same date as inDate.
         * @param indate: the date to query
         * @return a list of database IDs that correspond to the valid events
         */
        private List<int> GetValidEvents(DateTime inDate)
        {
            List<int> ids = new List<int>();

            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand("select ID, Date from eventsTable where Deleted = 0", con);

            con.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (((DateTime)reader["Date"]).ToShortDateString().Equals(inDate.ToShortDateString()))
                        ids.Add((int)reader["ID"]);
                }

            }

            con.Close();

            return ids;
        }

        /*
        * Creates a connection with the database. That 
        * connection is then used to insert the event.
        */
        protected void btnCreate_Click(object sender, EventArgs e)
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            btnCreate.Enabled = false;
            RequiredFieldValidator1.Enabled = true;

            if (txtEventName.Text.Length > 0)
            {
                string eventName = txtEventName.Text/*GridView1.SelectedRow.Cells[0].Text*/;

                int id = Int32.Parse(GridView1.SelectedRow.Cells[1].Text);

                string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("Update eventsTable SET Event_name = @Event_Name WHERE Id = @id And Date = @Date", con); 
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Event_Name", eventName);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Date", Calendar1.SelectedDate);
                con.Open();
                int i = cmd.ExecuteNonQuery();

                Response.Redirect("EventDisplayPage.aspx");
            }
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            btnCreate.Enabled = false;
            txtEventName.Enabled = false;
            txtEventName.Text = "Text";
            RequiredFieldValidator1.Enabled = false;

            if (txtEventName.Text.Length > 0)
            {
                int id = Int32.Parse(GridView1.SelectedRow.Cells[1].Text);

                string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("Update eventsTable SET Deleted = 1 WHERE Id = @id And Date = @Date", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Date", Calendar1.SelectedDate);
                con.Open();
                int i = cmd.ExecuteNonQuery();

                Response.Redirect("EventDisplayPage.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            RequiredFieldValidator1.Enabled = false;
            //txtEventName.Enabled = false;
        }
    }
}