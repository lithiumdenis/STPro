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

        }

        protected void ButtonAddReceptionToDB_Click(object sender, EventArgs e)
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
                    else if(datemonth == "Март")
                        getNumberMonth = 3;
                    else if(datemonth == "Апрель")
                        getNumberMonth = 4;
                    else if(datemonth == "Май")
                        getNumberMonth = 5;
                    else if(datemonth == "Июнь")
                        getNumberMonth = 6;
                    else if(datemonth == "Июль")
                        getNumberMonth = 7;
                    else if(datemonth == "Август")
                        getNumberMonth = 8;
                    else if(datemonth == "Сентябрь")
                        getNumberMonth = 9;
                    else if(datemonth == "Октябрь")
                        getNumberMonth = 10;
                    else if(datemonth == "Ноябрь")
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
            Server.Transfer("HospitalWebForm.aspx", true);

        }
    }
}