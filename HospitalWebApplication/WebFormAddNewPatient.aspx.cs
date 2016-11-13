using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace HospitalWebApplication
{
    public partial class WebFormAddNewPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Первый раз загружается страница или это ответ от неё самой же
            if (!IsPostBack)
            {
                //Если нет ИД, то ничего не делаем необычного, т.е. открываем чистые поля по default
                if (string.IsNullOrEmpty(Request["id"]))
                {
                    ButtonAddPatientToDB.Text = "Добавить нового пациента";
                    goto MYEND;
                }
                ButtonAddPatientToDB.Text = "Изменить информацию о пациенте";
                int id = 0;
                if (!int.TryParse(Request["id"], out id))
                {
                    throw new ArgumentException("Идентификатор пациента имеет неправильный формат");
                }

                //Извлекаем строчку с нужным ID из Patient и вставляем в нужные текстбоксы
                try
                {
                    string queryStringSelect = "SELECT * FROM Patient WHERE Id=" + id.ToString() + ";";
                    using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                    {

                        SqlCommand commandSelect = new SqlCommand(queryStringSelect, c);
                        c.Open();
                        SqlDataReader reader = commandSelect.ExecuteReader();
                        try
                        {
                            if (reader.Read())
                            {

                                TextBoxPatientSurname.Text = reader[1].ToString();
                                TextBoxPatientName.Text = reader[2].ToString();
                                TextBoxPatientAge.Text = reader[3].ToString();
                                TextBoxPatientContraindications.Text = reader[5].ToString();
                                DropDownListPatientGender.Text = reader[4].ToString();

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

        protected void ButtonAddPatientToDB_Click(object sender, EventArgs e)
        {
            //Если идентификатор отсутствует в запросе, то просто добавляем нового
            if (string.IsNullOrEmpty(Request["id"]))
            {
                try
                {
                    using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                    {
                        //READ TEXTBOX'ES
                        var surname = TextBoxPatientSurname.Text;
                        var name = TextBoxPatientName.Text;
                        var age = Convert.ToInt32(TextBoxPatientAge.Text);
                        var contraindications = TextBoxPatientContraindications.Text;
                        var gender = DropDownListPatientGender.Text;

                        if (surname == "" || name == "" || contraindications == "" || gender == "")
                        {
                            lblError.Text = "Недостаточно данных для продолжения";
                            goto MYENDADDPATIENT;
                        }

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

                        //CLEAR TEXTBOX'ES
                        TextBoxPatientSurname.Text = "";
                        TextBoxPatientName.Text = "";
                        TextBoxPatientAge.Text = "";
                        TextBoxPatientContraindications.Text = "";
                    };
                }
                catch (Exception ex)
                {
                    lblError.Text = string.Format("Ошибка: {0}", ex.Message);
                }
                MYENDADDPATIENT:
                Response.Redirect("HospitalWebForm.aspx");
            }
            else //А вот если идентификатор был, то инициируем процедуру обновления
            {
                //Ещё разок извлекаем этот айдишник
                int id = 0;
                if (!int.TryParse(Request["id"], out id))
                {
                    throw new ArgumentException("Идентификатор пациента имеет неправильный формат");
                }
                //Делаем апдейт БД для этого самого айдишника
                try
                {
                    string queryStringUpdate = "UPDATE [Patient] SET [Surname] = @Surname, [Name] = @Name, [Age] = @Age, [Gender] = @Gender, [Contraindications] = @Contraindications WHERE [Id] = @Id";
                    using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                    {
                        c.Open();

                        string tbsn = TextBoxPatientSurname.Text;
                        string tbnm = TextBoxPatientName.Text;
                        int tba = Convert.ToInt32(TextBoxPatientAge.Text);
                        string tbg = DropDownListPatientGender.Text;
                        string tbpo = TextBoxPatientContraindications.Text;

                        using (SqlCommand commandUpdate = new SqlCommand(queryStringUpdate, c))
                        {
                            //Добавить параметры
                            commandUpdate.Parameters.AddWithValue("@Surname", tbsn);
                            commandUpdate.Parameters.AddWithValue("@Name", tbnm);
                            commandUpdate.Parameters.AddWithValue("@Age", tba);
                            commandUpdate.Parameters.AddWithValue("@Gender", tbg);
                            commandUpdate.Parameters.AddWithValue("@Contraindications", tbpo);
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