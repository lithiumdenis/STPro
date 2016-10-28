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
    public partial class HospitalWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptTable.DataSource = loadDataFromDoctorTable();
            rptTable.DataBind();

            RepeaterPatient.DataSource = loadDataFromPatientTable();
            RepeaterPatient.DataBind();

            RepeaterReception.DataSource = loadDataFromReceptionTable();
            RepeaterReception.DataBind();
        }

        private DataTable loadDataFromDoctorTable()
        {
            try
            {
                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    c.Open();
                    SqlCommand cmd = new SqlCommand("select * from Doctor", c);
                    var reader = cmd.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Columns.Add(new DataColumn("Id", typeof(int)));
                    table.Columns.Add(new DataColumn("Surname", typeof(string)));
                    table.Columns.Add(new DataColumn("Name", typeof(string)));
                    table.Columns.Add(new DataColumn("Age", typeof(int)));
                    table.Columns.Add(new DataColumn("Gender", typeof(string)));
                    table.Columns.Add(new DataColumn("Position", typeof(string)));

                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        var surname = reader["Surname"].ToString();
                        var name = reader["Name"].ToString();
                        var age = reader["Age"] == null ? 0 : (int)reader["Age"];
                        var gender = reader["Gender"].ToString();
                        var position = reader["Position"].ToString();

                        var row = table.NewRow();
                        row["Id"] = id;
                        row["Surname"] = surname;
                        row["Name"] = name;
                        row["Age"] = age;
                        row["Gender"] = gender;
                        row["Position"] = position;


                        //row["Name"] = string.Format("{0} {1} {2}", lastName, firstName, middleName);
                        //row["StudyAt"] = string.Format("{0}.{1}", course, group);

                        table.Rows.Add(row);
                    }
                    reader.Close();

                    return table;
                };
            }
            catch (Exception ex)
            {
                lblError.Text = string.Format("Error occured: {0}", ex.Message);
            }
            return null;
        }

        private DataTable loadDataFromPatientTable()
        {
            try
            {
                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    c.Open();
                    SqlCommand cmd = new SqlCommand("select * from Patient", c);
                    var reader = cmd.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Columns.Add(new DataColumn("Id", typeof(int)));
                    table.Columns.Add(new DataColumn("Surname", typeof(string)));
                    table.Columns.Add(new DataColumn("Name", typeof(string)));
                    table.Columns.Add(new DataColumn("Age", typeof(int)));
                    table.Columns.Add(new DataColumn("Gender", typeof(string)));
                    table.Columns.Add(new DataColumn("Contraindications", typeof(string)));

                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        var surname = reader["Surname"].ToString();
                        var name = reader["Name"].ToString();
                        var age = reader["Age"] == null ? 0 : (int)reader["Age"];
                        var gender = reader["Gender"].ToString();
                        var contraindications = reader["Contraindications"].ToString();

                        var row = table.NewRow();
                        row["Id"] = id;
                        row["Surname"] = surname;
                        row["Name"] = name;
                        row["Age"] = age;
                        row["Gender"] = gender;
                        row["Contraindications"] = contraindications;


                        //row["Name"] = string.Format("{0} {1} {2}", lastName, firstName, middleName);
                        //row["StudyAt"] = string.Format("{0}.{1}", course, group);

                        table.Rows.Add(row);
                    }
                    reader.Close();

                    return table;
                };
            }
            catch (Exception ex)
            {
                lblError.Text = string.Format("Error occured: {0}", ex.Message);
            }
            return null;
        }

        private DataTable loadDataFromReceptionTable()
        {
            try
            {
                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    c.Open();
                    SqlCommand cmd = new SqlCommand("select * from Reception", c);
                    var reader = cmd.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Columns.Add(new DataColumn("Id", typeof(int)));
                    table.Columns.Add(new DataColumn("Doctor_Id", typeof(int)));
                    table.Columns.Add(new DataColumn("Patient_Id", typeof(int)));
                    table.Columns.Add(new DataColumn("Date", typeof(string)));
                    table.Columns.Add(new DataColumn("Time", typeof(string)));

                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        var doct = reader["Doctor_Id"] == null ? 0 : (int)reader["Doctor_Id"];
                        var pati = reader["Patient_Id"] == null ? 0 : (int)reader["Patient_Id"];
                        var date = reader["Date"].ToString();
                        var time = reader["Time"].ToString();

                        var splitData = date.Split(' '); //Убираем нулевое время

                        var row = table.NewRow();
                        row["Id"] = id;
                        row["Doctor_Id"] = doct;
                        row["Patient_Id"] = pati;
                        row["Date"] = splitData[0];
                        row["Time"] = time;


                        //row["Name"] = string.Format("{0} {1} {2}", lastName, firstName, middleName);
                        //row["StudyAt"] = string.Format("{0}.{1}", course, group);

                        table.Rows.Add(row);
                    }
                    reader.Close();

                    return table;
                };
            }
            catch (Exception ex)
            {
                lblError.Text = string.Format("Error occured: {0}", ex.Message);
            }
            return null;
        }


    }
}