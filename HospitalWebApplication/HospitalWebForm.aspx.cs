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
            
        }

        #region Reception methods

        //Изменение записей в Reception
        [WebMethod(EnableSession = true)]
        public static object UpdateReception(Reception record)
        {
            try
            {
                string queryStringDelete = "UPDATE [Reception] SET [Doctor_Id] = @Doctor_Id, [Patient_Id] = @Patient_Id WHERE [Id] = @Id";
                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    c.Open();

                    using (SqlCommand commandUpdate = new SqlCommand(queryStringDelete, c))
                    {
                        //Добавить параметры
                        commandUpdate.Parameters.AddWithValue("@Id", record.Id);
                        commandUpdate.Parameters.AddWithValue("@Doctor_Id", record.Doctor_Id);
                        commandUpdate.Parameters.AddWithValue("@Patient_Id", record.Patient_Id);
                   
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

        //Добавление записей в Reception
        [WebMethod(EnableSession = true)]
        public static object CreateReception(Reception record)
        {
            try
            {
                var addedReception = record;

                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    //READ TEXTBOX'ES
                    var doctor_id = record.Doctor_Id;
                    var patient_id = record.Patient_Id;
                    var date = record.Date;

                    //if (surname == "" || name == "" || position == "" || gender == "")
                    //{
                    //    lblError.Text = "Недостаточно данных для продолжения";
                    //    goto MYENDADDDOCTOR;
                    //}

                    //INSERT INFORMATION
                    c.Open();
                    string sql = string.Format("Insert Into Reception" +
                        "(Doctor_Id, Patient_Id, Date) Values(@Doctor_Id, @Patient_Id, @Date)");

                    using (SqlCommand cmd = new SqlCommand(sql, c))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@Doctor_Id", doctor_id);
                        cmd.Parameters.AddWithValue("@Patient_Id", patient_id);
                        cmd.Parameters.AddWithValue("@Date", date);
                      

                        cmd.ExecuteNonQuery();
                    }
                };

                return new { Result = "OK", Record = addedReception };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        //Удаление записей из Reception
        [WebMethod(EnableSession = true)]
        public static object DeleteReception(int Id)
        {
            try
            {
                string queryStringDelete = "DELETE FROM [Reception] WHERE [Id] = @Id";
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

        //Чтение записей из Patient
        [WebMethod(EnableSession = true)]
        public static object ReceptionList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                //Get data from database
                int receptionCount = returnCountOfReceptions();
                List<Reception> receptions = returnPartOfReceptionsWithSorting(jtStartIndex, jtPageSize, jtSorting);

                //Return result to jTable
                return new { Result = "OK", Records = receptions, TotalRecordCount = receptionCount };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        private static List<Reception> returnPartOfReceptionsWithSorting(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int counterForTakeAPart = 0;
            List<Reception> mylist = new List<Reception>();
            //Извлекаем строчку с нужным ID из Reception и вставляем в нужные текстбоксы
            try
            {
                string queryStringSelect = "SELECT * FROM Reception ORDER BY " + jtSorting + ";";
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
                                mylist.Add(new Reception
                                {
                                    Id = Convert.ToInt32(reader[0]),
                                    Doctor_Id = Convert.ToInt32(reader[1]),
                                    Patient_Id = Convert.ToInt32(reader[2]),
                                    Date = Convert.ToDateTime(reader[3])
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

        private static int returnCountOfReceptions()
        {
            int CountOfReceptions = 0;

            //using context and LINQ
            using (var ctx = new HospitalDatabaseEntities())
            {
                CountOfReceptions = (from a in ctx.Reception select a).Count();
            }

            return CountOfReceptions;
        }

        #endregion

        #region Patient methods

        //Изменение записей в Patient
        [WebMethod(EnableSession = true)]
        public static object UpdatePatient(Patient record)
        {
            try
            {
                string queryStringDelete = "UPDATE [Patient] SET [Surname] = @Surname, [Name] = @Name, [Age] = @Age, [Gender] = @Gender, [Contraindications] = @Contraindications WHERE [Id] = @Id";
                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    c.Open();

                    using (SqlCommand commandUpdate = new SqlCommand(queryStringDelete, c))
                    {
                        //Добавить параметры
                        commandUpdate.Parameters.AddWithValue("@Id", record.Id);
                        commandUpdate.Parameters.AddWithValue("@Surname", record.Surname);
                        commandUpdate.Parameters.AddWithValue("@Name", record.Name);
                        commandUpdate.Parameters.AddWithValue("@Age", record.Age);
                        commandUpdate.Parameters.AddWithValue("@Gender", record.Gender);
                        commandUpdate.Parameters.AddWithValue("@Contraindications", record.Contraindications);

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

        //Добавление записей в Patient
        [WebMethod(EnableSession = true)]
        public static object CreatePatient(Patient record)
        {
            try
            {
                var addedPatient = record;

                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    //READ TEXTBOX'ES
                    var surname = record.Surname;
                    var name = record.Name;
                    var age = record.Age;
                    var contraindications = record.Contraindications;
                    var gender = record.Gender;

                    //if (surname == "" || name == "" || position == "" || gender == "")
                    //{
                    //    lblError.Text = "Недостаточно данных для продолжения";
                    //    goto MYENDADDDOCTOR;
                    //}

                    //INSERT INFORMATION
                    c.Open();
                    string sql = string.Format("Insert Into Patient" +
                        "(Surname, Name, Age, Gender, Contraindications) Values(@Surname, @Name, @Age, @Gender, @Contraindications)");

                    using (SqlCommand cmd = new SqlCommand(sql, c))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@Surname", surname);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Age", age);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Contraindications", contraindications);

                        cmd.ExecuteNonQuery();
                    }
                };

                return new { Result = "OK", Record = addedPatient };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        //Удаление записей из Patient
        [WebMethod(EnableSession = true)]
        public static object DeletePatient(int Id)
        {
            try
            {
                string queryStringDelete = "DELETE FROM [Patient] WHERE [Id] = @Id";
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

        //Чтение записей из Patient
        [WebMethod(EnableSession = true)]
        public static object PatientList(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            try
            {
                //Get data from database
                int patientCount = returnCountOfPatients();
                List<Patient> patients = returnPartOfPatientsWithSorting(jtStartIndex, jtPageSize, jtSorting);

                //Return result to jTable
                return new { Result = "OK", Records = patients, TotalRecordCount = patientCount };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        private static List<Patient> returnPartOfPatientsWithSorting(int jtStartIndex, int jtPageSize, string jtSorting)
        {
            int counterForTakeAPart = 0;
            List<Patient> mylist = new List<Patient>();
            //Извлекаем строчку с нужным ID из Patient и вставляем в нужные текстбоксы
            try
            {
                string queryStringSelect = "SELECT * FROM Patient ORDER BY " + jtSorting + ";";
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
                                mylist.Add(new Patient
                                {
                                    Id = Convert.ToInt32(reader[0]),
                                    Surname = reader[1].ToString(),
                                    Name = reader[2].ToString(),
                                    Age = Convert.ToInt32(reader[3]),
                                    Gender = reader[4].ToString(),
                                    Contraindications = reader[5].ToString()
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

        private static int returnCountOfPatients()
        {
            int CountOfPatients = 0;

            //using context and LINQ
            using (var ctx = new HospitalDatabaseEntities())
            {
                CountOfPatients = (from a in ctx.Patient select a).Count();
            }

            return CountOfPatients;
        }

        #endregion

        #region Doctor methods

        //Изменение записей в Doctor
        [WebMethod(EnableSession = true)]
        public static object UpdateDoctor(Doctor record)
        {
            try
            {
                string queryStringDelete = "UPDATE [Doctor] SET [Surname] = @Surname, [Name] = @Name, [Age] = @Age, [Gender] = @Gender, [Position] = @Position WHERE [Id] = @Id";
                using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    c.Open();

                    using (SqlCommand commandUpdate = new SqlCommand(queryStringDelete, c))
                    {
                        //Добавить параметры
                        commandUpdate.Parameters.AddWithValue("@Id", record.Id);
                        commandUpdate.Parameters.AddWithValue("@Surname", record.Surname);
                        commandUpdate.Parameters.AddWithValue("@Name", record.Name);
                        commandUpdate.Parameters.AddWithValue("@Age", record.Age);
                        commandUpdate.Parameters.AddWithValue("@Gender", record.Gender);
                        commandUpdate.Parameters.AddWithValue("@Position", record.Position);

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

        //Добавление записей в Doctor
        [WebMethod(EnableSession = true)]
        public static object CreateDoctor(Doctor record)
        {
            try
            {
                var addedDoctor = record;

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

        //Удаление записей из Doctor
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
            List<Doctor> mylist = new List<Doctor>();
            int counterForTakeAPart = 0;

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


            //Это работает, но громоздко
            ////using context and LINQ
            //using (var ctx = new HospitalDatabaseEntities())
            //{
            //    var query = from a in ctx.Doctor select a;

            //    //Sorting
            //    //This ugly code is used just for demonstration.
            //    //Normally, Incoming sorting text can be directly appended to an SQL query.

            //    //sort by name
            //    if (string.IsNullOrEmpty(jtSorting) || jtSorting.Equals("Name ASC"))
            //    {
            //        query = query.OrderBy(p => p.Name);
            //    }
            //    else if (jtSorting.Equals("Name DESC"))
            //    {
            //        query = query.OrderByDescending(p => p.Name);
            //    }

            //    //sort by gender
            //    else if (jtSorting.Equals("Gender ASC"))
            //    {
            //        query = query.OrderBy(p => p.Gender);
            //    }
            //    else if (jtSorting.Equals("Gender DESC"))
            //    {
            //        query = query.OrderByDescending(p => p.Gender);
            //    }

            //    //sort by surname
            //    else if (jtSorting.Equals("Surname ASC"))
            //    {
            //        query = query.OrderBy(p => p.Surname);
            //    }
            //    else if (jtSorting.Equals("Surname DESC"))
            //    {
            //        query = query.OrderByDescending(p => p.Surname);
            //    }

            //    //sort by id
            //    else if (jtSorting.Equals("Id ASC"))
            //    {
            //        query = query.OrderBy(p => p.Id);
            //    }
            //    else if (jtSorting.Equals("Id DESC"))
            //    {
            //        query = query.OrderByDescending(p => p.Id);
            //    }

            //    //sort by age
            //    else if (jtSorting.Equals("Age ASC"))
            //    {
            //        query = query.OrderBy(p => p.Age);
            //    }
            //    else if (jtSorting.Equals("Age DESC"))
            //    {
            //        query = query.OrderByDescending(p => p.Age);
            //    }

            //    //sort by position
            //    else if (jtSorting.Equals("Position ASC"))
            //    {
            //        query = query.OrderBy(p => p.Position);
            //    }
            //    else if (jtSorting.Equals("Position DESC"))
            //    {
            //        query = query.OrderByDescending(p => p.Position);
            //    }

            //    //Default!
            //    else
            //    {
            //        query = query.OrderBy(p => p.Name);
            //    }


            //    var result = query.Skip(jtStartIndex).Take(jtPageSize).ToList(); //Paging

            //    //Иначе некорректная связь с Reception генерируется. Пересоздаём
            //    for (int i = 0; i < result.Count; i++)
            //        mylist.Add(new Doctor { Age = result[i].Age, Gender = result[i].Gender, Id = result[i].Id, Name = result[i].Name,
            //         Position = result[i].Position, Surname = result[i].Surname} );

            //    return mylist;
            //}
        }

        private static int returnCountOfDoctors()
        {
            int CountOfDoctors = 0;

            //using context and LINQ
            using (var ctx = new HospitalDatabaseEntities())
            {
                CountOfDoctors = (from a in ctx.Doctor select a).Count();
            }

            return CountOfDoctors;
        }

        #endregion

        //protected void Button3_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("WebFormAddNewReception.aspx");
        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("WebFormAddNewDoctor.aspx");
        //}

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("WebFormAddNewPatient.aspx");
        //}

        //protected void gridDoctor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    //Получаем полноценный ID из места положения в таблице
        //    var datass = CoreFunc.loadDataUsingDataSet("Doctor");
        //    var a = datass.Rows[e.RowIndex];                            //При сортировке это приводит к ошибке

        //    int id = Convert.ToInt32(a[0]);

        //    try
        //    {
        //        string queryStringDelete = "DELETE FROM [Doctor] WHERE [Id] = @Id";
        //        using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        //        {
        //            c.Open();

        //            using (SqlCommand commandUpdate = new SqlCommand(queryStringDelete, c))
        //            {
        //                //Добавить параметры
        //                commandUpdate.Parameters.AddWithValue("@Id", id);

        //                commandUpdate.ExecuteNonQuery();
        //            }
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Text = string.Format("Ошибка: {0}", ex.Message);
        //    }
            
        //    gridDoctor.DataSource = CoreFunc.loadDataUsingDataSet("Doctor");
        //    gridDoctor.DataBind();
        //}

        //protected void gridDoctor_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    //Получаем полноценный ID из места положения в таблице
        //    var datass = CoreFunc.loadDataUsingDataSet("Doctor");
        //    var a = datass.Rows[e.NewEditIndex];                        //При сортировке это приводит к ошибке
        //    string realID = a[0].ToString();

        //    string transferPath = "WebFormAddNewDoctor.aspx?id=" + realID;

        //    Response.Redirect(transferPath);
        //}

        //protected void gridPatient_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    //Получаем полноценный ID из места положения в таблице
        //    var datass = CoreFunc.loadDataUsingDataSet("Patient");
        //    var a = datass.Rows[e.RowIndex];                            //При сортировке это приводит к ошибке

        //    int id = Convert.ToInt32(a[0]);

        //    try
        //    {
        //        string queryStringDelete = "DELETE FROM [Patient] WHERE [Id] = @Id";
        //        using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        //        {
        //            c.Open();

        //            using (SqlCommand commandUpdate = new SqlCommand(queryStringDelete, c))
        //            {
        //                //Добавить параметры
        //                commandUpdate.Parameters.AddWithValue("@Id", id);

        //                commandUpdate.ExecuteNonQuery();
        //            }
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Text = string.Format("Ошибка: {0}", ex.Message);
        //    }

        //    gridPatient.DataSource = CoreFunc.loadDataUsingDataSet("Patient");
        //    gridPatient.DataBind();
        //}

        //protected void gridPatient_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    //Получаем полноценный ID из места положения в таблице
        //    var datass = CoreFunc.loadDataUsingDataSet("Patient");
        //    var a = datass.Rows[e.NewEditIndex];                        //При сортировке это приводит к ошибке
        //    string realID = a[0].ToString();

        //    string transferPath = "WebFormAddNewPatient.aspx?id=" + realID;

        //    Response.Redirect(transferPath);

        //}

        //protected void gridReception_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    //Получаем полноценный ID из места положения в таблице
        //    var datass = CoreFunc.loadDataUsingDataSet("Reception");
        //    var a = datass.Rows[e.RowIndex];                            //При сортировке это приводит к ошибке

        //    int id = Convert.ToInt32(a[0]);

        //    try
        //    {
        //        string queryStringDelete = "DELETE FROM [Reception] WHERE [Id] = @Id";
        //        using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        //        {
        //            c.Open();

        //            using (SqlCommand commandUpdate = new SqlCommand(queryStringDelete, c))
        //            {
        //                //Добавить параметры
        //                commandUpdate.Parameters.AddWithValue("@Id", id);

        //                commandUpdate.ExecuteNonQuery();
        //            }
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Text = string.Format("Ошибка: {0}", ex.Message);
        //    }

        //    gridReception.DataSource = CoreFunc.loadDataUsingDataSet("Reception");
        //    gridReception.DataBind();

        //}

        //protected void gridReception_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    //Получаем полноценный ID из места положения в таблице
        //    var datass = CoreFunc.loadDataUsingDataSet("Reception");
        //    var a = datass.Rows[e.NewEditIndex];                        //При сортировке это приводит к ошибке
        //    string realID = a[0].ToString();

        //    string transferPath = "WebFormAddNewReception.aspx?id=" + realID;

        //    Response.Redirect(transferPath);
        //}

    }
}