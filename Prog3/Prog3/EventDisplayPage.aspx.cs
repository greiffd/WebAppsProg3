using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Prog3
{
    public partial class EventDisplayPage : System.Web.UI.Page
    {

        public Label labelEventName { get { return lblEventName; } }

        public List<Event> events = new List<Event>();

        public DateTime date { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            //Calendar calendar = (Calendar)Master.FindControl("Calendar1"); 
            //lblEventName.Text = calendar.SelectedDate.ToShortDateString();

            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack/*!IsPostBack*/)
            {
                //Label newLabel = (Label)PreviousPage.FindControl("lblUpdatedName");
                //lblEventName.Text = newLabel.Text;
            }
            else
            {
                Calendar calendar = (Calendar)Master.FindControl("Calendar1");
                lblEventName.Text = calendar.SelectedDate.ToShortDateString();
                date = calendar.SelectedDate;
            }

            //Calendar calendar = (Calendar)Master.FindControl("Calendar1");
            //date = calendar.SelectedDate;

            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter adapt = new SqlDataAdapter("select Event_Name, Date from eventsTable", con);
            con.Open();
            adapt.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            //Event myEvent = new Event();
            //myEvent.eventName = "New Test Event";
            // myEvent.date = DateTime.Now;

            //events.Add(myEvent);
            // GridView1.DataSource = events;
            // GridView1.DataBind();

            GridView1.Visible = true;
            // GridView1.Columns[0].HeaderText = "Date";
            // GridView1.Columns[1].HeaderText = "Event";

            //BoundField col = (BoundField)GridView1.Columns[0];
            //col.DataFormatString = Eval("Fromdate", "{0:dd/MM/yyyy}");

            //Calendar calendar = (Calendar)Master.FindControl("Calendar1");
            //Label label = (Label)Master.FindControl("lblEventName");
            //label.Text = calendar.SelectedDate.ToShortDateString();
        }

        private void GetEventsByDate(DateTime Date)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}