<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAddNewPatient.aspx.cs" Inherits="HospitalWebApplication.WebFormAddNewPatient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color: #99CCFF">
    <form id="form1" runat="server">
    <div>
        <asp:Label id="lblError" CssClass="cc" runat="server" ForeColor="Red"></asp:Label>

        <div>
        <asp:Label ID="Label2" runat="server" Text="Добавление нового пациента:" style="font-weight: 700"></asp:Label>
    </div>
        <em>Фамилия:
    </em>
    <div>
         <asp:TextBox ID="TextBoxPatientSurname" runat="server"></asp:TextBox>
    </div>
        <em>Имя</em>:
    <div>
         <asp:TextBox ID="TextBoxPatientName" runat="server"></asp:TextBox>
    </div>
        <em>Возраст</em>:
    <div>
         <asp:TextBox ID="TextBoxPatientAge" runat="server"></asp:TextBox>
    </div>
        <em>Пол</em>: 
    <div>
        
        <asp:DropDownList ID="DropDownListPatientGender" runat="server" Width="146px">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:DropDownList>
    </div>
        <em>Противопоказания</em>:
    <div>
         <asp:TextBox ID="TextBoxPatientContraindications" runat="server"></asp:TextBox>
         <br />
        <br />
        <asp:Button ID="ButtonAddPatientToDB" runat="server" BackColor="#9900FF" ForeColor="White" Text="Добавить пациента в базу данных" Width="255px" OnClick="ButtonAddPatientToDB_Click" Height="40px" style="font-weight: 700" />
        <br />
        <br />
        <br />
    </div>

    
    </div>
    </form>
</body>
</html>
