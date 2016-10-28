<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAddNewDoctor.aspx.cs" Inherits="HospitalWebApplication.WebFormAddNewDoctor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color: #99CCFF">
    <form id="form1" runat="server">
        <asp:Label id="lblError" CssClass="cc" runat="server" ForeColor="Red"></asp:Label>

    <div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Добавление нового доктора:" ForeColor="Black" style="font-weight: 700"></asp:Label>
        <br />
    </div>
        <em>Фамилия:</em>
    <div>
         <asp:TextBox ID="TextBoxDoctorSurname" runat="server"></asp:TextBox> 
    </div>
        <em>Имя:
    </em>
    <div>
         <asp:TextBox ID="TextBoxDoctorName" runat="server"></asp:TextBox> 
    </div>
        <em>Возраст:</em>
    <div>
         <asp:TextBox ID="TextBoxDoctorAge" runat="server"></asp:TextBox>
    </div>
        <em>Пол:</em> 
    <div>
        
        <asp:DropDownList ID="DropDownListDoctorGender" runat="server" Width="148px">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:DropDownList>
    </div>
        <em>Специальность:</em>
    <div>
         <asp:TextBox ID="TextBoxDoctorPosition" runat="server"></asp:TextBox>
         <br />
        <br />
        <asp:Button ID="ButtonAddDoctorToDB" runat="server" BackColor="#9900FF" ForeColor="White" Text="Добавить доктора в базу данных" Width="255px" OnClick="ButtonAddDoctorToDB_Click" style="font-weight: 700" Height="40px" />
        <br />
        <br />
        <br />
    </div>



    </div>
    </form>
</body>
</html>
