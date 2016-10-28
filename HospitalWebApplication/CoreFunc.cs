using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HospitalWebApplication
{
    public class CoreFunc
    {
        public static DataTable loadDataUsingDataSet(string tableName)
        {
            try
            {
                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    c.Open();

                    string queryBuilder = "select * from " + tableName;

                    var da = new SqlDataAdapter(queryBuilder, c);
                    var ds = new DataSet();
                    da.Fill(ds);

                    return ds.Tables[0];
                };
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('login successful');</script>");
                //lblError.Text = string.Format("Error occured: {0}", ex.Message);
            }
            return null;
        }

        
    }
}