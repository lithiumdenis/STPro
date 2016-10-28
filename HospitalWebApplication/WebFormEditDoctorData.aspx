<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEditDoctorData.aspx.cs" Inherits="HospitalWebApplication.WebFormEditDoctorData" %>
<%@ Register Src="~/MyControls/WebUserControlEditPageTop.ascx" TagPrefix="lith" TagName="TopControl"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color: #CCCCFF">
    <form id="form1" runat="server">
    <div>
    
        <lith:TopControl ID ="mytop2" runat="server"></lith:TopControl>

    <div>
    <asp:Label ID="Label1" runat="server" Text="Произведите изменение интересующих строк таблицы ''DOCTOR'':" ForeColor ="#1C5E55" Width="593px"></asp:Label>
    </div>

    <asp:GridView ID="GridView4" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderWidth="1px" CellPadding="3" DataKeyNames="Id" DataSourceID="SqlDataSource4" EmptyDataText="Нет записей для отображения." GridLines="Horizontal" BorderStyle="None">
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="False" />
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

    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [Doctor] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Doctor] ([Surname], [Name], [Age], [Gender], [Position]) VALUES (@Surname, @Name, @Age, @Gender, @Position)" ProviderName="<%$ ConnectionStrings:DefaultConnection.ProviderName %>" SelectCommand="SELECT [Id], [Surname], [Name], [Age], [Gender], [Position] FROM [Doctor]" UpdateCommand="UPDATE [Doctor] SET [Surname] = @Surname, [Name] = @Name, [Age] = @Age, [Gender] = @Gender, [Position] = @Position WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Surname" Type="String" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Age" Type="Int32" />
                    <asp:Parameter Name="Gender" Type="String" />
                    <asp:Parameter Name="Position" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Surname" Type="String" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Age" Type="Int32" />
                    <asp:Parameter Name="Gender" Type="String" />
                    <asp:Parameter Name="Position" Type="String" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>


    </div>
    </form>
</body>
</html>
