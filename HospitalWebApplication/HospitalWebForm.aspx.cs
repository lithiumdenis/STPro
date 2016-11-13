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
    public partial class HospitalWebForm : CoreFunc
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var datass = CoreFunc.loadDataUsingDataSet("Doctor");
            //var a = datass.Rows[0];
            //datass.Rows.Add(null, "blah", "blah", 34, "Male", "blah");

            gridDoctor.DataSource = datass;
            gridDoctor.DataBind();

            gridPatient.DataSource = CoreFunc.loadDataUsingDataSet("Patient");
            gridPatient.DataBind();

            gridReception.DataSource = CoreFunc.loadDataUsingDataSet("Reception");
            gridReception.DataBind();

            if (!IsPostBack)
            {
                ddlSchema.DataSource = schemas;
                ddlSchema.DataBind();
            }

            ddlSchema.SelectedIndexChanged += DdlSchema_SelectedIndexChanged;
        }

        private void DdlSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["Schema"] = ddlSchema.SelectedIndex;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormAddNewReception.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormAddNewDoctor.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormAddNewPatient.aspx");
        }

        protected void gridDoctor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Получаем полноценный ID из места положения в таблице
            var datass = CoreFunc.loadDataUsingDataSet("Doctor");
            var a = datass.Rows[e.RowIndex];                            //При сортировке это приводит к ошибке

            int id = Convert.ToInt32(a[0]);

            try
            {
                string queryStringDelete = "DELETE FROM [Doctor] WHERE [Id] = @Id";
                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    c.Open();

                    using (SqlCommand commandUpdate = new SqlCommand(queryStringDelete, c))
                    {
                        //Добавить параметры
                        commandUpdate.Parameters.AddWithValue("@Id", id);

                        commandUpdate.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                lblError.Text = string.Format("Ошибка: {0}", ex.Message);
            }
            
            gridDoctor.DataSource = CoreFunc.loadDataUsingDataSet("Doctor");
            gridDoctor.DataBind();
        }

        protected void gridDoctor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Получаем полноценный ID из места положения в таблице
            var datass = CoreFunc.loadDataUsingDataSet("Doctor");
            var a = datass.Rows[e.NewEditIndex];                        //При сортировке это приводит к ошибке
            string realID = a[0].ToString();

            string transferPath = "WebFormAddNewDoctor.aspx?id=" + realID;

            Response.Redirect(transferPath);
        }

        protected void gridPatient_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Получаем полноценный ID из места положения в таблице
            var datass = CoreFunc.loadDataUsingDataSet("Patient");
            var a = datass.Rows[e.RowIndex];                            //При сортировке это приводит к ошибке

            int id = Convert.ToInt32(a[0]);

            try
            {
                string queryStringDelete = "DELETE FROM [Patient] WHERE [Id] = @Id";
                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    c.Open();

                    using (SqlCommand commandUpdate = new SqlCommand(queryStringDelete, c))
                    {
                        //Добавить параметры
                        commandUpdate.Parameters.AddWithValue("@Id", id);

                        commandUpdate.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                lblError.Text = string.Format("Ошибка: {0}", ex.Message);
            }

            gridPatient.DataSource = CoreFunc.loadDataUsingDataSet("Patient");
            gridPatient.DataBind();
        }

        protected void gridPatient_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Получаем полноценный ID из места положения в таблице
            var datass = CoreFunc.loadDataUsingDataSet("Patient");
            var a = datass.Rows[e.NewEditIndex];                        //При сортировке это приводит к ошибке
            string realID = a[0].ToString();

            string transferPath = "WebFormAddNewPatient.aspx?id=" + realID;

            Response.Redirect(transferPath);

        }

        protected void gridReception_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Получаем полноценный ID из места положения в таблице
            var datass = CoreFunc.loadDataUsingDataSet("Reception");
            var a = datass.Rows[e.RowIndex];                            //При сортировке это приводит к ошибке

            int id = Convert.ToInt32(a[0]);

            try
            {
                string queryStringDelete = "DELETE FROM [Reception] WHERE [Id] = @Id";
                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    c.Open();

                    using (SqlCommand commandUpdate = new SqlCommand(queryStringDelete, c))
                    {
                        //Добавить параметры
                        commandUpdate.Parameters.AddWithValue("@Id", id);

                        commandUpdate.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                lblError.Text = string.Format("Ошибка: {0}", ex.Message);
            }

            gridReception.DataSource = CoreFunc.loadDataUsingDataSet("Reception");
            gridReception.DataBind();

        }

        protected void gridReception_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Получаем полноценный ID из места положения в таблице
            var datass = CoreFunc.loadDataUsingDataSet("Reception");
            var a = datass.Rows[e.NewEditIndex];                        //При сортировке это приводит к ошибке
            string realID = a[0].ToString();

            string transferPath = "WebFormAddNewReception.aspx?id=" + realID;

            Response.Redirect(transferPath);
        }
    }
}