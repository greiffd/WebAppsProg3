using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace Prog3
{
    public partial class EventDisplayPage : System.Web.UI.Page
    {

        public DateTime date { get; set; }      // The current date

        /*
         * Gets the selected date and stores it.
         */
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            date = Calendar2.SelectedDate;
            lblDate.Text = date.ToShortDateString();

            UpdateGridview();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            date = Calendar2.SelectedDate;
            UpdateGridview();

        }

        /*
         * Fills the Gridview with the events in the database.
         */
        private void UpdateGridview()
        {
            List<int> eventIds = GetValidEvents(date);

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


                string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(cs);

                string command = "select Event_Name" + /*, Date */ " from eventsTable where id =" + idString;
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

            SqlCommand cmd = new SqlCommand("select ID, Date from eventsTable", con);

            con.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (((DateTime)reader["Date"]).ToShortDateString().Equals(inDate.ToShortDateString()))
                        ids.Add((int)reader["ID"]);
                }

            }

            return ids;
        }

    }
}