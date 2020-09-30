using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prog3
{
    public partial class CalendarMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ContentPlaceHolder1.Visible = false;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            lblEventName.Text = Calendar1.SelectedDate.ToShortDateString();

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {

        }
    }
}