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
    public partial class WebFormAddNewReception : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Первый раз загружается страница или это ответ от неё самой же
            if (!IsPostBack)
            {
                //Если нет ИД, то ничего не делаем необычного, т.е. открываем чистые поля по default
                if (string.IsNullOrEmpty(Request["id"]))
                {
                    ButtonAddReceptionToDB.Text = "Добавить новый приём";
                    goto MYEND;
                }
                ButtonAddReceptionToDB.Text = "Изменить информацию о приёме";
                int id = 0;
                if (!int.TryParse(Request["id"], out id))
                {
                    throw new ArgumentException("Идентификатор приёма имеет неправильный формат");
                }

                //Извлекаем строчку с нужным ID из Reception и вставляем в нужные текстбоксы
                try
                {
                    string queryStringSelect = "SELECT * FROM Reception WHERE Id=" + id.ToString() + ";";
                    using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                    {

                        SqlCommand commandSelect = new SqlCommand(queryStringSelect, c);
                        c.Open();
                        SqlDataReader reader = commandSelect.ExecuteReader();
                        try
                        {
                            if (reader.Read())
                            {
                                TextBoxDoctorId.Text = reader[1].ToString();
                                TextBoxPatientId.Text = reader[2].ToString();

                                var a = reader[3].ToString().Split(' ', '.');
                                TextBoxDateDay.Text = a[0];


                                if (a[1] == "01")
                                    DropDownListMonth.Text = "Январь";
                                else if(a[1] == "02")
                                    DropDownListMonth.Text = "Февраль";
                                else if (a[1] == "03")
                                    DropDownListMonth.Text = "Март";
                                else if (a[1] == "04")
                                    DropDownListMonth.Text = "Апрель";
                                else if (a[1] == "05")
                                    DropDownListMonth.Text = "Май";
                                else if (a[1] == "06")
                                    DropDownListMonth.Text = "Июнь";
                                else if (a[1] == "07")
                                    DropDownListMonth.Text = "Июль";
                                else if (a[1] == "08")
                                    DropDownListMonth.Text = "Август";
                                else if (a[1] == "09")
                                    DropDownListMonth.Text = "Сентябрь";
                                else if (a[1] == "10")
                                    DropDownListMonth.Text = "Октябрь";
                                else if (a[1] == "11")
                                    DropDownListMonth.Text = "Ноябрь";
                                else if (a[1] == "12")
                                    DropDownListMonth.Text = "Декабрь";

                                TextBoxDateYear.Text = a[2];
                                TextBoxDateTime.Text = a[3];
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

        protected void ButtonAddReceptionToDB_Click(object sender, EventArgs e)
        {
            //Если идентификатор отсутствует в запросе, то просто добавляем нового
            if (string.IsNullOrEmpty(Request["id"]))
            {
                try
                {
                    using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                    {
                        //READ TEXTBOX'ES
                        var doctor_id = TextBoxDoctorId.Text;
                        var patient_id = TextBoxPatientId.Text;
                        var dateyear = Convert.ToInt32(TextBoxDateYear.Text);
                        var datemonth = DropDownListMonth.Text;
                        var dateday = Convert.ToInt32(TextBoxDateDay.Text);
                        var datetime = TextBoxDateTime.Text;

                        if (doctor_id == "" || patient_id == "" || datetime == "::" || TextBoxDateYear.Text == "" || TextBoxDateDay.Text == "")
                        {
                            lblError.Text = "Недостаточно данных для продолжения";
                            goto MYENDADDPATIENT;
                        }

                        int getNumberMonth = 0;
                        if (datemonth == "Январь")
                            getNumberMonth = 1;
                        else if (datemonth == "Февраль")
                            getNumberMonth = 2;
                        else if (datemonth == "Март")
                            getNumberMonth = 3;
                        else if (datemonth == "Апрель")
                            getNumberMonth = 4;
                        else if (datemonth == "Май")
                            getNumberMonth = 5;
                        else if (datemonth == "Июнь")
                            getNumberMonth = 6;
                        else if (datemonth == "Июль")
                            getNumberMonth = 7;
                        else if (datemonth == "Август")
                            getNumberMonth = 8;
                        else if (datemonth == "Сентябрь")
                            getNumberMonth = 9;
                        else if (datemonth == "Октябрь")
                            getNumberMonth = 10;
                        else if (datemonth == "Ноябрь")
                            getNumberMonth = 11;
                        else
                            getNumberMonth = 12;

                        string[] splittedTime = datetime.Split(':');
                        int[] splittedTimeInt = new int[splittedTime.Length];
                        for (int i = 0; i < splittedTime.Length; i++)
                        {
                            splittedTimeInt[i] = Convert.ToInt32(splittedTime[i]);
                        }

                        DateTime ThisTime = new DateTime(dateyear, getNumberMonth, dateday, splittedTimeInt[0], splittedTimeInt[1], splittedTimeInt[2]);

                        //INSERT INFORMATION
                        c.Open();
                        string sql = string.Format("Insert Into Reception" +
                            "(Doctor_Id, Patient_Id, Date) Values(@Doctor_Id, @Patient_Id, @Date)");

                        using (SqlCommand cmd = new SqlCommand(sql, c))
                        {
                            // Добавить параметры
                            cmd.Parameters.AddWithValue("@Doctor_Id", doctor_id);
                            cmd.Parameters.AddWithValue("@Patient_Id", patient_id);
                            cmd.Parameters.AddWithValue("@Date", ThisTime);

                            cmd.ExecuteNonQuery();
                        }


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
                    throw new ArgumentException("Идентификатор приёма имеет неправильный формат");
                }
                //Делаем апдейт БД для этого самого айдишника
                try
                {
                    string queryStringUpdate = "UPDATE [Reception] SET [Doctor_Id] = @Doctor_Id, [Patient_Id] = @Patient_Id, [Date] = @Date WHERE [Id] = @Id";
                    using (var c = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                    {
                        c.Open();

                        //READ TEXTBOX'ES
                        var doctor_id = TextBoxDoctorId.Text;
                        var patient_id = TextBoxPatientId.Text;
                        var dateyear = Convert.ToInt32(TextBoxDateYear.Text);
                        var datemonth = DropDownListMonth.Text;
                        var dateday = Convert.ToInt32(TextBoxDateDay.Text);
                        var datetime = TextBoxDateTime.Text;

                        if (doctor_id == "" || patient_id == "" || datetime == "::" || TextBoxDateYear.Text == "" || TextBoxDateDay.Text == "")
                        {
                            lblError.Text = "Недостаточно данных для продолжения";
                            goto MYENDADDPATIENT;
                        }

                        int getNumberMonth = 0;
                        if (datemonth == "Январь")
                            getNumberMonth = 1;
                        else if (datemonth == "Февраль")
                            getNumberMonth = 2;
                        else if (datemonth == "Март")
                            getNumberMonth = 3;
                        else if (datemonth == "Апрель")
                            getNumberMonth = 4;
                        else if (datemonth == "Май")
                            getNumberMonth = 5;
                        else if (datemonth == "Июнь")
                            getNumberMonth = 6;
                        else if (datemonth == "Июль")
                            getNumberMonth = 7;
                        else if (datemonth == "Август")
                            getNumberMonth = 8;
                        else if (datemonth == "Сентябрь")
                            getNumberMonth = 9;
                        else if (datemonth == "Октябрь")
                            getNumberMonth = 10;
                        else if (datemonth == "Ноябрь")
                            getNumberMonth = 11;
                        else
                            getNumberMonth = 12;

                        string[] splittedTime = datetime.Split(':');
                        int[] splittedTimeInt = new int[splittedTime.Length];
                        for (int i = 0; i < splittedTime.Length; i++)
                        {
                            splittedTimeInt[i] = Convert.ToInt32(splittedTime[i]);
                        }

                        DateTime ThisTime = new DateTime(dateyear, getNumberMonth, dateday, splittedTimeInt[0], splittedTimeInt[1], splittedTimeInt[2]);


                        using (SqlCommand commandUpdate = new SqlCommand(queryStringUpdate, c))
                        {
                            //Добавить параметры
                            commandUpdate.Parameters.AddWithValue("@Doctor_Id", doctor_id);
                            commandUpdate.Parameters.AddWithValue("@Patient_Id", patient_id);
                            commandUpdate.Parameters.AddWithValue("@Date", ThisTime);
                            commandUpdate.Parameters.AddWithValue("@Id", id);

                            commandUpdate.ExecuteNonQuery();
                        }
                    };
                }
                catch (Exception ex)
                {
                    lblError.Text = string.Format("Ошибка: {0}", ex.Message);
                }
                MYENDADDPATIENT:
                Response.Redirect("HospitalWebForm.aspx");
            }
        }
    }
}