<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEditReceptionData.aspx.cs" Inherits="HospitalWebApplication.WebFormEditReceptionData" %>
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
    
        <lith:TopControl ID ="mytop1" runat="server"></lith:TopControl>

    <div>
    <asp:Label ID="Label1" runat="server" Text="Произведите изменение интересующих строк таблицы ''RECEPTION'':" ForeColor ="#1C5E55" Width="635px"></asp:Label>
    </div>

    <asp:GridView ID="GridView4" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderWidth="1px" CellPadding="3" DataKeyNames="Id" DataSourceID="SqlDataSource4" EmptyDataText="Нет записей для отображения." GridLines="Horizontal" BorderStyle="None">
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="False" />
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

    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [Reception] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Reception] ([Doctor_Id], [Patient_Id], [Date]) VALUES (@Doctor_Id, @Patient_Id, @Date)" ProviderName="<%$ ConnectionStrings:DefaultConnection.ProviderName %>" SelectCommand="SELECT [Id], [Doctor_Id], [Patient_Id], [Date] FROM [Reception]" UpdateCommand="UPDATE [Reception] SET [Doctor_Id] = @Doctor_Id, [Patient_Id] = @Patient_Id, [Date] = @Date WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Doctor_Id" Type="Int32" />
                    <asp:Parameter Name="Patient__Id" Type="Int32" />
                    <asp:Parameter Name="Date" Type="DateTime" /> 
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Doctor_Id" Type="Int32" />
                    <asp:Parameter Name="Patient__Id" Type="Int32" />
                    <asp:Parameter Name="Date" Type="DateTime" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>


    </div>
    </form>
</body>
</html>
