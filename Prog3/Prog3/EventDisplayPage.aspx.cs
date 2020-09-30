using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prog3
{
    public partial class EventDisplayPage : System.Web.UI.Page
    {

        public Label labelEventName { get { return lblEventName; } }

        public List<Event> events = new List<Event>();

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
            }

            Event myEvent = new Event();
            myEvent.eventName = "New Test Event";
            myEvent.date = DateTime.Now;

            events.Add(myEvent);
            GridView1.DataSource = events;
            GridView1.DataBind();

            GridView1.Visible = true;

            //BoundField col = (BoundField)GridView1.Columns[0];
            //col.DataFormatString = Eval("Fromdate", "{0:dd/MM/yyyy}");

            //Calendar calendar = (Calendar)Master.FindControl("Calendar1");
            //Label label = (Label)Master.FindControl("lblEventName");
            //label.Text = calendar.SelectedDate.ToShortDateString();
        }

        private void GetEventsByDate(DateTime Date)
        {
            //SqlDataSource1.
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}