<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HospitalWebForm.aspx.cs" Inherits="HospitalWebApplication.HospitalWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body {
            background-color: <%=Color%>;
        } 
    </style>
</head>
<body >
    <form id="form1" runat="server">

    <asp:Label id="lblError" CssClass="cc" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="Фоновый цвет: " ForeColor ="White" Width="450px" Font-Names="Franklin Gothic Medium"></asp:Label> <asp:DropDownList ID="ddlSchema" runat="server" AutoPostBack="true"></asp:DropDownList>
    <div>
    <asp:Label ID="Label1" runat="server" Text="TABLE ''DOCTOR''" ForeColor ="White" Width="400px" Font-Names="Franklin Gothic Medium"></asp:Label>
    </div>

        <asp:GridView ID="gridDoctor" runat="server" OnRowDeleting="gridDoctor_RowDeleting" OnRowEditing="gridDoctor_RowEditing" AllowSorting="false" AutoGenerateColumns="false" BackColor="White" BorderColor="#E7E7FF" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" EmptyDataText="Нет записей для отображения." GridLines="Horizontal" BorderStyle="None">

            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="False" ButtonType="Button" ControlStyle-BorderColor="Purple" ControlStyle-BackColor="White" />
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:BoundField DataField="Position" HeaderText="Position" SortExpression="Position" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                            <SortedDescendingHeaderStyle BackColor="#3E3277" />

        </asp:GridView>

        <asp:Button ID="Button1" runat="server" Text="ADD DATA" BackColor ="#333399" ForeColor ="White" OnClick="Button1_Click" BorderColor="White" Font-Names="Franklin Gothic Medium" />

       <!-- style="position: absolute; left: 100px; top: 50px;" -->

     <br />    <!-- Перенос строки-->
     <br /> 
     <br /> 

    <div>
    <asp:Label ID="Label2" runat="server" Text="TABLE ''PATIENT''" ForeColor ="White" Font-Names="Franklin Gothic Medium"></asp:Label>
    </div>

    <asp:GridView ID="gridPatient" runat="server" OnRowDeleting="gridPatient_RowDeleting" OnRowEditing="gridPatient_RowEditing" AllowSorting="false" AutoGenerateColumns="false" BackColor="White" BorderColor="#E7E7FF" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" EmptyDataText="Нет записей для отображения." GridLines="Horizontal" BorderStyle="None">

            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="False" ButtonType="Button" ControlStyle-BorderColor="Purple" ControlStyle-BackColor="White" />
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:BoundField DataField="Contraindications" HeaderText="Contraindications" SortExpression="Contraindications" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                            <SortedDescendingHeaderStyle BackColor="#3E3277" />

        </asp:GridView>

        <asp:Button ID="Button2" runat="server" Text="ADD DATA" BackColor ="#333399" ForeColor ="White" OnClick="Button2_Click" BorderColor="White" Font-Names="Franklin Gothic Medium" />

        <br />    <!-- Перенос строки-->
        <br /> 
        <br /> 

    <div>
    <asp:Label ID="Label3" runat="server" Text="TABLE ''RECEPTION''" ForeColor ="White" Font-Names="Franklin Gothic Medium"></asp:Label>
    </div>
       
        <asp:GridView ID="gridReception" runat="server" OnRowDeleting="gridReception_RowDeleting" OnRowEditing="gridReception_RowEditing" AllowSorting="false" AutoGenerateColumns="false" BackColor="White" BorderColor="#E7E7FF" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" EmptyDataText="Нет записей для отображения." GridLines="Horizontal" BorderStyle="None">

            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="False" ButtonType="Button" ControlStyle-BorderColor="Purple" ControlStyle-BackColor="White" />
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Doctor_Id" HeaderText="Doctor_Id" SortExpression="Doctor_Id" />
                <asp:BoundField DataField="Patient_Id" HeaderText="Patient_Id" SortExpression="Patient_Id" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                            <SortedDescendingHeaderStyle BackColor="#3E3277" />

        </asp:GridView>

        <asp:Button ID="Button3" runat="server" Text="ADD DATA" BackColor ="#333399" ForeColor ="White" OnClick="Button3_Click" BorderColor="White" Font-Names="Franklin Gothic Medium" />

        
    </form>
</body>
</html>