using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prog3
{
    public partial class EventUpdatePage : System.Web.UI.Page
    {

        public Label updateLabel { get { return lblUpdatedName; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack/*!IsPostBack*/)
            {
                //Label displayPageLabel = (Label)PreviousPage.FindControl("labelEventName");
                lblUpdatedName.Text = PreviousPage.labelEventName.Text;
            }
            else
            {
                lblUpdatedName.Text = "Not postback";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblUpdatedName.Text = txtEventName.Text;
        }
    }
}