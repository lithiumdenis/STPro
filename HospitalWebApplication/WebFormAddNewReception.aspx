<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAddNewReception.aspx.cs" Inherits="HospitalWebApplication.WebFormAddNewReception" %>
<%@ Register Src="~/MyControls/WebUserControlEditPageTop.ascx" TagPrefix="lith" TagName="TopControl"%>

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
            <lith:TopControl ID ="mytop2" runat="server"></lith:TopControl>
        </div>
        <div>
        <asp:Label ID="Label2" runat="server" Text="Добавьте новый приём:" style="font-weight: 700"></asp:Label>
    </div>
        <em>Идентификатор доктора:</em>
    <div>
         <asp:TextBox ID="TextBoxDoctorId" runat="server"></asp:TextBox>
    </div>
        <em>Идентификатор пациента</em>:
    <div>
         <asp:TextBox ID="TextBoxPatientId" runat="server"></asp:TextBox>
    </div>
        <em>Год</em>:
    <div>
         <asp:TextBox ID="TextBoxDateYear" runat="server"></asp:TextBox>
    </div>
        <em>Месяц</em>: 
    <div>
        <asp:DropDownList ID="DropDownListMonth" runat="server" Width="146px">
            <asp:ListItem>Январь</asp:ListItem>
            <asp:ListItem>Февраль</asp:ListItem>
            <asp:ListItem>Март</asp:ListItem>
            <asp:ListItem>Апрель</asp:ListItem>
            <asp:ListItem>Май</asp:ListItem>
            <asp:ListItem>Июнь</asp:ListItem>
            <asp:ListItem>Июль</asp:ListItem>
            <asp:ListItem>Август</asp:ListItem>
            <asp:ListItem>Сентябрь</asp:ListItem>
            <asp:ListItem>Октябрь</asp:ListItem>
            <asp:ListItem>Ноябрь</asp:ListItem>
            <asp:ListItem>Декабрь</asp:ListItem>
        </asp:DropDownList>
    </div>
        <em>День</em>:
    <div>
         <asp:TextBox ID="TextBoxDateDay" runat="server"></asp:TextBox>
    </div>
        <em>Время (HH:MM:SS)</em>:
    <div>
         <asp:TextBox ID="TextBoxDateTime" runat="server" Text="::"></asp:TextBox>
         <br />
        <br />
        <asp:Button ID="ButtonAddReceptionToDB" runat="server" BackColor="#9900FF" ForeColor="White" Text="Добавить приём в базу данных" Width="255px" OnClick="ButtonAddReceptionToDB_Click" Height="40px" style="font-weight: 700" />
        <br />
        <br />
        <br />
    </div>

    
    </div>
    </form>
</body>
</html>
