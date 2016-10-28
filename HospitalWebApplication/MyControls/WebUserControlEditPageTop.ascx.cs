using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalWebApplication.MyControls
{
    public partial class WebUserControlEditPageTop : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBackToPrevPage_Click(object sender, EventArgs e)
        {
            Server.Transfer("HospitalWebForm.aspx", true);
        }
    }
}