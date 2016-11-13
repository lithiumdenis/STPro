using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Linq;

namespace HospitalWebApplication
{
    public partial class WebFormAddNewDoctor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Первый раз загружается страница или это ответ от неё самой же
            if (!IsPostBack)
            {
                //Если нет ИД, то ничего не делаем необычного, т.е. открываем чистые поля по default
                if (string.IsNullOrEmpty(Request["id"]))
                {
                    ButtonAddDoctorToDB.Text = "Добавить нового доктора";
                    goto MYEND;
                }
                ButtonAddDoctorToDB.Text = "Изменить информацию о докторе";
                int id = 0;
                if (!int.TryParse(Request["id"], out id))
                {
                    throw new ArgumentException("Идентификатор доктора имеет неправильный формат");
                }

                //Извлекаем строчку с нужным ID из Doctor и вставляем в нужные текстбоксы
                try
                {
                    string queryStringSelect = "SELECT * FROM Doctor WHERE Id=" + id.ToString() + ";";
                    using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                    {

                        SqlCommand commandSelect = new SqlCommand(queryStringSelect, c);
                        c.Open();
                        SqlDataReader reader = commandSelect.ExecuteReader();
                        try
                        {
                            if (reader.Read())
                            {

                                TextBoxDoctorSurname.Text = reader[1].ToString();
                                TextBoxDoctorName.Text = reader[2].ToString();
                                TextBoxDoctorAge.Text = reader[3].ToString();
                                TextBoxDoctorPosition.Text = reader[5].ToString();
                                DropDownListDoctorGender.Text = reader[4].ToString();

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
                    lblError.Text = string.Format("Ошибка: {0}", ex.Message);
                }

                MYEND:;
            }
        }

        protected void ButtonAddDoctorToDB_Click(object sender, EventArgs e)
        {
            //Если идентификатор отсутствует в запросе, то просто добавляем нового
            if (string.IsNullOrEmpty(Request["id"]))
            {
                try
                {
                    using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                    {
                        //READ TEXTBOX'ES
                        var surname = TextBoxDoctorSurname.Text;
                        var name = TextBoxDoctorName.Text;
                        var age = Convert.ToInt32(TextBoxDoctorAge.Text);
                        var position = TextBoxDoctorPosition.Text;
                        var gender = DropDownListDoctorGender.Text;

                        if (surname == "" || name == "" || position == "" || gender == "")
                        {
                            lblError.Text = "Недостаточно данных для продолжения";
                            goto MYENDADDDOCTOR;
                        }

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

                        TextBoxDoctorSurname.Text = "";
                        TextBoxDoctorName.Text = "";
                        TextBoxDoctorAge.Text = "";
                        TextBoxDoctorPosition.Text = "";
                    };
                }
                catch (Exception ex)
                {
                    lblError.Text = string.Format("Ошибка: {0}", ex.Message);
                }
                MYENDADDDOCTOR:
                Response.Redirect("HospitalWebForm.aspx");
            }
            else //А вот если идентификатор был, то инициируем процедуру обновления
            {
                //Ещё разок извлекаем этот айдишник
                int id = 0;
                if (!int.TryParse(Request["id"], out id))
                {
                    throw new ArgumentException("Идентификатор доктора имеет неправильный формат");
                }
                //Делаем апдейт БД для этого самого айдишника
                try
                {
                    string queryStringUpdate = "UPDATE [Doctor] SET [Surname] = @Surname, [Name] = @Name, [Age] = @Age, [Gender] = @Gender, [Position] = @Position WHERE [Id] = @Id";
                    using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                    {
                        c.Open();

                        string tbsn = TextBoxDoctorSurname.Text;
                        string tbnm = TextBoxDoctorName.Text;
                        int tba = Convert.ToInt32(TextBoxDoctorAge.Text);
                        string tbg = DropDownListDoctorGender.Text;
                        string tbpo = TextBoxDoctorPosition.Text;

                        using (SqlCommand commandUpdate = new SqlCommand(queryStringUpdate, c))
                        {
                            //Добавить параметры
                            commandUpdate.Parameters.AddWithValue("@Surname", tbsn);
                            commandUpdate.Parameters.AddWithValue("@Name", tbnm);
                            commandUpdate.Parameters.AddWithValue("@Age", tba);
                            commandUpdate.Parameters.AddWithValue("@Gender", tbg);
                            commandUpdate.Parameters.AddWithValue("@Position", tbpo);
                            commandUpdate.Parameters.AddWithValue("@Id", id);
    
                            commandUpdate.ExecuteNonQuery();
                        }
                    };
                }
                catch (Exception ex)
                {
                    lblError.Text = string.Format("Ошибка: {0}", ex.Message);
                }
                Response.Redirect("HospitalWebForm.aspx");
            }
        }
    }
}