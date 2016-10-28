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
    TABLE "DOCTOR"
    </div>

    <asp:Repeater ID="rptTable" runat="server">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <td>
                                ID
                            </td>
                            <td>
                                SURNAME
                            </td>
                            <td>
                                NAME
                            </td>
                            <td>
                                AGE
                            </td>
                            <td>
                                GENDER
                            </td>
                            <td>
                                POSITION
                            </td>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("Id") %>
                    </td>
                    <td>
                        <%# Eval("Surname") %>
                    </td>
                    <td>
                        <%# Eval("Name") %>
                    </td>
                    <td>
                        <%# Eval("Age") %>
                    </td>
                    <td>
                        <%# Eval("Gender") %>
                    </td>
                    <td>
                        <%# Eval("Position") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>

     <br />    <!-- Перенос строки-->

    <div>
    TABLE "PATIENT"
    <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
    </div>
       
    <asp:Repeater ID="RepeaterPatient" runat="server">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <td>
                                ID
                            </td>
                            <td>
                                SURNAME
                            </td>
                            <td>
                                NAME
                            </td>
                            <td>
                                AGE
                            </td>
                            <td>
                                GENDER
                            </td>
                            <td>
                                CONTRAINDICATIONS
                            </td>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("Id") %>
                    </td>
                    <td>
                        <%# Eval("Surname") %>
                    </td>
                    <td>
                        <%# Eval("Name") %>
                    </td>
                    <td>
                        <%# Eval("Age") %>
                    </td>
                    <td>
                        <%# Eval("Gender") %>
                    </td>
                    <td>
                        <%# Eval("Contraindications") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <br />    <!-- Перенос строки-->

    <div>
    TABLE "RECEPTION"
    </div>
       
    <asp:Repeater ID="RepeaterReception" runat="server">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <td>
                                ID
                            </td>
                            <td>
                                DOCTOR_ID
                            </td>
                            <td>
                                PATIENT_ID
                            </td>
                            <td>
                                DATE
                            </td>
                            <td>
                                TIME
                            </td>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("Id") %>
                    </td>
                    <td>
                        <%# Eval("Doctor_Id") %>
                    </td>
                    <td>
                        <%# Eval("Patient_Id") %>
                    </td>
                    <td>
                        <%# Eval("Date") %>
                    </td>
                    <td>
                        <%# Eval("Time") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>

    </form>
</body>
</html>