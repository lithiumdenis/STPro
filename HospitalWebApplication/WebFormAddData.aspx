<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAddData.aspx.cs" Inherits="HospitalWebApplication.WebFormAddData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Label id="lblError" CssClass="cc" runat="server" ForeColor="Red"></asp:Label>

    <div>
        Добавьте необходимые данные:
    </div>
    </br>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Добавление нового доктора:" ForeColor="White" BackColor="Purple"></asp:Label>
    </div>
    <div>
        Фамилия: <asp:TextBox ID="TextBoxDoctorSurname" runat="server" style="margin-left: 63px"></asp:TextBox>
    </div>
    <div>
        Имя: <asp:TextBox ID="TextBoxDoctorName" runat="server" style="margin-left: 106px"></asp:TextBox>
    </div>
    <div>
        Возраст: <asp:TextBox ID="TextBoxDoctorAge" runat="server" style="margin-left: 74px"></asp:TextBox>
    </div>
    <div>
        Пол: 
        <asp:DropDownList ID="DropDownListDoctorGender" runat="server" style="margin-left: 107px" Width="146px">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        Специальность: <asp:TextBox ID="TextBoxDoctorPosition" runat="server" style="margin-left: 10px"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonAddDoctorToDB" runat="server" BackColor="#9900FF" ForeColor="White" Text="Добавить доктора в базу данных" Width="297px" OnClick="ButtonAddDoctorToDB_Click" />
        <br />
        <br />
        <br />
    </div>


        </br>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Добавление нового пациента:" ForeColor="White" BackColor="Purple"></asp:Label>
    </div>
    <div>
        Фамилия: <asp:TextBox ID="TextBoxPatientSurname" runat="server" style="margin-left: 63px"></asp:TextBox>
    </div>
    <div>
        Имя: <asp:TextBox ID="TextBoxPatientName" runat="server" style="margin-left: 106px"></asp:TextBox>
    </div>
    <div>
        Возраст: <asp:TextBox ID="TextBoxPatientAge" runat="server" style="margin-left: 74px"></asp:TextBox>
    </div>
    <div>
        Пол: 
        <asp:DropDownList ID="DropDownListPatientGender" runat="server" style="margin-left: 107px" Width="146px">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        Противопоказания: <asp:TextBox ID="TextBoxPatientContraindications" runat="server" style="margin-left: 10px"></asp:TextBox>
        <br />
        <asp:Button ID="Button2" runat="server" BackColor="#9900FF" ForeColor="White" Text="Добавить пациента в базу данных" Width="297px" OnClick="ButtonAddPatientToDB_Click" />
        <br />
        <br />
        <br />
    </div>



        <asp:Button ID="Button1" runat="server" BackColor="#9966FF" ForeColor="White" Height="33px" OnClick="Button1_Click" Text="Завершить добавление данных" Width="278px" />
    </form>
</body>
</html>
