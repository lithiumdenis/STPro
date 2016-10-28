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
    public partial class WebFormAddNewDoctor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAddDoctorToDB_Click(object sender, EventArgs e)
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
            Server.Transfer("HospitalWebForm.aspx", true);
        }
    }
}