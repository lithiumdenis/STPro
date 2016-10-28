﻿using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HospitalWebApplication
{
    public partial class HospitalWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var datass = CoreFunc.loadDataUsingDataSet("Doctor");
            //datass.Rows.Add(null, "blah", "blah", 34, "Male", "blah");

            gridDoctor.DataSource = datass;
            gridDoctor.DataBind();

            gridPatient.DataSource = CoreFunc.loadDataUsingDataSet("Patient");
            gridPatient.DataBind();

            gridReception.DataSource = CoreFunc.loadDataUsingDataSet("Reception");
            gridReception.DataBind();
        }

        

        protected void gridDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebFormAddData.aspx", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebFormAddData.aspx", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebFormAddData.aspx", true);
        }
    }
}