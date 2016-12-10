using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;


namespace HospitalWebApplication
{
    public partial class HospitalWebForm : CoreFunc
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var datass = CoreFunc.loadDataUsingDataSet("Doctor");
            //var a = datass.Rows[0];
            //datass.Rows.Add(null, "blah", "blah", 34, "Male", "blah");
            //datass.Rows.Add(null, null, null, "ololo", null, null);

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


        ////Изменение записей в Doctor
        //[WebMethod(EnableSession = true)]
        //public static object UpdateDoctor(Doctor record)
        //{
        //    try
        //    {
        //        //Repository.StudentRepository.UpdateStudent(record);
        //        return new { Result = "OK" };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new { Result = "ERROR", Message = ex.Message };
        //    }
        //}



        //Добавление записей в Doctor
        [WebMethod(EnableSession = true)]
        public static object CreateDoctor(Doctor record)
        {
            try
            {
                var addedDoctor = record;//Repository.StudentRepository.AddStudent(record);


                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    //READ TEXTBOX'ES
                    var surname = record.Surname;
                    var name = record.Name;
                    var age = record.Age;
                    var position = record.Position;
                    var gender = record.Gender;

                    //if (surname == "" || name == "" || position == "" || gender == "")
                    //{
                    //    lblError.Text = "Недостаточно данных для продолжения";
                    //    goto MYENDADDDOCTOR;
                    //}

                    //INSERT INFORMATION
                    c.Open();
                    string sql = string.Format("Insert Into Doctor" +
                        "(Surname, Name, Age, Gender, Position) Values(@Surname, @Name, @Age, @Gender, @Position)");

                    using (SqlCommand cmd = new SqlCommand(sql, c))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@Surname", surname);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Age", age);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Position", position);

                        cmd.ExecuteNonQuery();
                    }
                };

                return new { Result = "OK", Record = addedDoctor };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        //Удаление записей из Doctor -----не работает
        [WebMethod(EnableSession = true)]
        public static object DeleteDoctor(int Id)
        {
            try
            {
                string queryStringDelete = "DELETE FROM [Doctor] WHERE [Id] = @Id";
                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    c.Open();

                    using (SqlCommand commandUpdate = new SqlCommand(queryStringDelete, c))
                    {
                        //Добавить параметры
                        commandUpdate.Parameters.AddWithValue("@Id", Id);

                        commandUpdate.ExecuteNonQuery();
                    }
                };

                return new { Result = "OK" };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        //Чтение записей из Doctor

        [WebMethod(EnableSession = true)]
        public static object DoctorList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                //Get data from database
                int doctorCount = returnCountOfDoctors(); 
                List<Doctor> doctors = returnPartOfDoctorsWithSorting(jtStartIndex, jtPageSize, jtSorting);

                //Return result to jTable
                return new { Result = "OK", Records = doctors, TotalRecordCount = doctorCount };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        private static List<Doctor> returnPartOfDoctorsWithSorting(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int counterForTakeAPart = 0;
            List<Doctor> mylist = new List<Doctor>();
            //Извлекаем строчку с нужным ID из Doctor и вставляем в нужные текстбоксы
            try
            {
                string queryStringSelect = "SELECT * FROM Doctor ORDER BY " + jtSorting + ";";
                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {

                    SqlCommand commandSelect = new SqlCommand(queryStringSelect, c);
                    c.Open();
                    SqlDataReader reader = commandSelect.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            if (counterForTakeAPart >= jtStartIndex && counterForTakeAPart < jtStartIndex + jtPageSize)
                            {
                                mylist.Add(new Doctor
                                {
                                    Id = Convert.ToInt32(reader[0]),
                                    Surname = reader[1].ToString(),
                                    Name = reader[2].ToString(),
                                    Age = Convert.ToInt32(reader[3]),
                                    Gender = reader[4].ToString(),
                                    Position = reader[5].ToString()
                                });
                            }

                            counterForTakeAPart++;
                        }
                    }
                    finally
                    {
                        // Always call Close when done reading.
                        reader.Close();
                    }
                };
            }
            catch (Exception ex)
            {
                //lblError.Text = string.Format("Ошибка: {0}", ex.Message);
            }

            return mylist;
        }

        private static int returnCountOfDoctors()
        {
            int CountOfDoctors = 0;
            //Извлекаем строчку с нужным ID из Doctor и вставляем в нужные текстбоксы
            try
            {
                string queryStringSelect = "SELECT Count(*) FROM Doctor;";
                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {

                    SqlCommand commandSelect = new SqlCommand(queryStringSelect, c);
                    c.Open();
                    SqlDataReader reader = commandSelect.ExecuteReader();
                    try
                    {
                        if (reader.Read())
                        {
                            CountOfDoctors = Convert.ToInt32(reader[0]);
                        }
                    }
                    finally
                    {
                        // Always call Close when done reading.
                        reader.Close();
                    }
                };
            }
            catch (Exception ex)
            {
                //lblError.Text = string.Format("Ошибка: {0}", ex.Message);
            }

            return CountOfDoctors;
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

        protected void gridDoctor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDoctor.PageIndex = e.NewPageIndex;
            gridDoctor.DataBind();
        }

        protected void gridPatient_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridPatient.PageIndex = e.NewPageIndex;
            gridPatient.DataBind();
        }

        protected void gridReception_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridReception.PageIndex = e.NewPageIndex;
            gridReception.DataBind();
        }
    }
}