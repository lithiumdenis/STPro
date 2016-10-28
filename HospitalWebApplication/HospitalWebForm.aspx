<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HospitalWebForm.aspx.cs" Inherits="HospitalWebApplication.HospitalWebForm" %>

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
    <asp:Label ID="Label1" runat="server" Text="TABLE ''DOCTOR''" ForeColor ="#1C5E55" Width="400px"></asp:Label>
    </div>

    <asp:DataGrid ID="gridDoctor"   runat="server" AllowSorting="True" CellPadding="4" DataKeyNames="Id" EmptyDataText="---" HeaderStyle-BackColor ="Purple" HeaderStyle-ForeColor ="White" OnSelectedIndexChanged="gridDoctor_SelectedIndexChanged" ForeColor="#333333" GridLines="None" Width="400px">            
        <AlternatingItemStyle BackColor="White" />
        <EditItemStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
<HeaderStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True"></HeaderStyle>
        <ItemStyle BackColor="#E3EAEB" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    </asp:DataGrid>

        <asp:Button ID="Button1" runat="server" Text="ADD DATA" BackColor ="#1C5E55" ForeColor ="White" OnClick="Button1_Click" />

       <!-- style="position: absolute; left: 100px; top: 50px;" -->

     <br />    <!-- Перенос строки-->
        <br /> 
        <br /> 

    <div>
    <asp:Label ID="Label2" runat="server" Text="TABLE ''PATIENT''" ForeColor ="#1C5E55"></asp:Label>
    </div>
       
    <asp:DataGrid ID="gridPatient" runat="server" AllowSorting="True" CellPadding="4" DataKeyNames="Id" EmptyDataText="---" HeaderStyle-BackColor ="Purple" HeaderStyle-ForeColor ="White" ForeColor="#333333" GridLines="None">
        <AlternatingItemStyle BackColor="White" />
        <EditItemStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#E3EAEB" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:DataGrid>

        <asp:Button ID="Button2" runat="server" Text="ADD DATA" BackColor ="#1C5E55" ForeColor ="White" OnClick="Button2_Click" />

        <br />    <!-- Перенос строки-->
        <br /> 
        <br /> 

    <div>
    <asp:Label ID="Label3" runat="server" Text="TABLE ''RECEPTION''" ForeColor ="#1C5E55"></asp:Label>
    </div>
       
    <asp:DataGrid ID="gridReception" runat="server" AllowSorting="True" CellPadding="4" DataKeyNames="Id" EmptyDataText="---" HeaderStyle-BackColor ="Purple" HeaderStyle-ForeColor ="White" ForeColor="#333333" GridLines="None">
        <AlternatingItemStyle BackColor="White" />
        <EditItemStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#E3EAEB" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:DataGrid>
        <asp:Button ID="Button3" runat="server" Text="ADD DATA" BackColor ="#1C5E55" ForeColor ="White" OnClick="Button3_Click" />

    </form>
</body>
</html>