<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HospitalWebForm.aspx.cs" Inherits="HospitalWebApplication.HospitalWebForm" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        /*body {
            background-color: <%=Color%>;
        } */

        body {
            overflow: hidden;
            height: 100%;
            margin: 0;
            padding: 0;
            font-size: 12px;
            font-family: Verdana, Helvetica, Sans-Serif;
            color: #000000;
            background-color: #fff;
        }

        div {
            position: absolute;
            text-align: center;
            font-weight: bold;
        }

            div.first {
                width: 1500px;
                height: 1500px;
                left: 0px;
                top: 0px;
                z-index: 2;
            }

        img {
            width: 100%;
            height: 100%;
        }

        div.site-container {
            width: 650px;
            margin: auto;
        }

        div.ads-container {
            width: 130px;
            margin: auto;
            position: fixed;
            right: 5px;
            top: 5px;
        }

        div.main-header {
            border: 1px solid #CCCCCC;
            padding: 10px;
            margin-bottom: 5px;
            background-color: #ECF2F6;
        }

            div.main-header h1 {
                margin: 0px;
            }

        div.top-navigation {
            border: 1px solid #CCCCCC;
            padding: 4px;
            margin-bottom: 5px;
            background-color: #ECF2F6;
        }

            div.top-navigation a {
                padding-left: 2px;
                padding-right: 2px;
                font-weight: bold;
            }

        div.content-container {
            border: 1px solid #CCCCCC;
            padding: 10px;
            background-color: #F5F5F5;
            margin-bottom: 5px;
        }

            div.content-container h1, div.content-container h2, div.content-container h3, div.content-container h4, div.content-container h5 {
                color: rgb(23, 130, 239);
            }

        div.main-footer {
            border: 1px solid #CCCCCC;
            padding: 4px;
            margin-bottom: 5px;
            background-color: #ECF2F6;
            text-align: center;
        }

        h2 {
            font-size: 18px;
            font-weight: bold;
            margin-top: 0px;
        }

        h3 {
            font-size: 12px;
            font-weight: bold;
        }

        a {
            color: blue;
            text-decoration: none;
        }

            a:hover {
                color: red;
                text-decoration: underline;
            }

        /* DOCUMENTS */

        .api-option-header {
            border: 1px solid #CCCCCC;
            background-color: #c9e0fd;
            padding: 2px;
            margin-top: 10px;
        }

            .api-option-header div {
                display: inline;
                padding-right: 20px;
            }

            .api-option-header .option-name {
                font-weight: bold;
            }

        .expandable-header {
            color: #000066;
            cursor: pointer;
        }

        .expandable-content {
            display: none;
        }

        /* OTHERS */

        .news-date {
            color: #0f0f87;
            font-style: italic;
        }
    </style>

    <img id="bg" alt="background" src="" />

    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.tmpl.js"></script>
    <script type="text/javascript" src="MyScripts/errorHandling.js"></script>
    <script type="text/javascript" src="MyScripts/TemplateLoader.js"></script>
    <script type="text/javascript" src="MyScripts/rainyday.js"></script>

    
    <link href="/Content/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="/Scripts/jtable/themes/lightcolor/blue/jtable.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/modernizr-2.8.3.js" type="text/javascript"></script>

    <script type="text/javascript" src="Scripts/jquery-ui-1.12.1.js"></script>




    <!-- JTABLES LIB'S-->

    

    <script src="/MyScripts/jtablesite.js" type="text/javascript"></script>


    <!-- jTable style file -->
    
    



    <!-- A helper library for JSON serialization -->
    <script type="text/javascript" src="Scripts/jtable/external/json2.js"></script>
    <!-- Core jTable script file -->
    <script type="text/javascript" src="/Scripts/jtable/jquery.jtable.js"></script>
    <!-- ASP.NET Web Forms extension for jTable -->
    <script type="text/javascript" src="/Scripts/jtable/extensions/jquery.jtable.aspnetpagemethods.js"></script>

    
    
</head>
<body >
    <form id="form1" runat="server">

     <asp:Label id="lblError" CssClass="cc" runat="server" ForeColor="Red"></asp:Label>
    <!--<asp:Label ID="Label4" runat="server" Text="Фоновый цвет: " ForeColor ="White" Width="450px" Font-Names="Franklin Gothic Medium"></asp:Label> <asp:DropDownList ID="ddlSchema" runat="server" AutoPostBack="true"></asp:DropDownList>  -->
    


       <div class="first" >

           <table style="position: absolute; left: 0px; top: 0px;">
               <tr>
                   <td width="450" valign="top">


                       


                       <div id="DoctorTableContainer"></div>
                       <!-- Сюда будет встраиваться JTables таблица -->



                       <script type="text/javascript">
                           $(document).ready(function () {

                               //Prepare jtable plugin
                               $('#DoctorTableContainer').jtable({
                                   title: 'Doctor',
                                   paging: true, //Enables paging
                                   pageSize: 10, //Actually this is not needed since default value is 10.
                                   sorting: true, //Enables sorting
                                   
                                   defaultSorting: 'Surname ASC', //Optional. Default sorting on first load.
                                   actions: {
                                       listAction: '/HospitalWebForm.aspx/DoctorList',
                                       createAction: '/HospitalWebForm.aspx/CreateDoctor',
                                       updateAction: '/HospitalWebForm.aspx/UpdateDoctor',
                                       deleteAction: '/HospitalWebForm.aspx/DeleteDoctor'
                                   },
                                   fields: {
                                       Id: {
                                           key: true,
                                           create: false,
                                           edit: false,
                                           list: false
                                       },
                                       Surname: {
                                           title: 'Surname',
                                           width: '15%'
                                       },
                                       Name: {
                                           title: 'Name',
                                           width: '15%'
                                       },
                                       Age: {
                                           title: 'Age',
                                           width: '10%'
                                       },
                                       Gender: {
                                           title: 'Gender',
                                           width: '15%'
                                       },
                                       Position: {
                                           title: 'Position',
                                           width: '20%'
                                       }
                                   }
                               });

                               //Load doctors list from server
                               $('#DoctorTableContainer').jtable('load');
                           });
                     
                       </script>








<!--

                           <div>
                           <asp:Label ID="Label1" runat="server" Text="TABLE ''DOCTOR''" ForeColor="White" Width="" Font-Names="Franklin Gothic Medium"></asp:Label>
                       </div>
        <asp:Button ID="Button1" runat="server" Text="ADD DATA" BackColor ="#333399" ForeColor ="White" OnClick="Button1_Click" BorderColor="White" Font-Names="Franklin Gothic Medium" />


        <asp:GridView ID="gridDoctor" runat="server" OnRowDeleting="gridDoctor_RowDeleting" OnRowEditing="gridDoctor_RowEditing" AllowSorting="false" AutoGenerateColumns="false" BackColor="White" BorderColor="#E7E7FF" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" EmptyDataText="Нет записей для отображения." GridLines="Horizontal" BorderStyle="None" Font-Size="X-Small" AllowPaging="True" OnPageIndexChanging="gridDoctor_PageIndexChanging" PageSize="20">

            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="False" ButtonType="Link" ControlStyle-BorderColor="Purple" ControlStyle-Font-Overline="false" ControlStyle-Font-Underline="false" ControlStyle-Font-Bold="true"  ControlStyle-Font-Size="X-Small" >                
<ControlStyle BorderColor="Purple" Font-Bold="True" Font-Overline="False" Font-Size="X-Small" Font-Underline="False"></ControlStyle>
                </asp:CommandField>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:BoundField DataField="Position" HeaderText="Position" SortExpression="Position" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerSettings Mode="NextPrevious" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                            <SortedDescendingHeaderStyle BackColor="#3E3277" />

        </asp:GridView>
                 -->

       <!-- style="position: absolute; left: 100px; top: 50px;" 
           -->

     <br />    <!-- Перенос строки-->
     <br /> 
     <br /> 


                 </td>
                 <td width="450" valign="top">

<!--
    <div>
    <asp:Label ID="Label2" runat="server" Text="TABLE ''PATIENT''" ForeColor ="White" Font-Names="Franklin Gothic Medium"></asp:Label>
    </div>

        <asp:Button ID="Button2" runat="server" Text="ADD DATA" BackColor ="#333399" ForeColor ="White" OnClick="Button2_Click" BorderColor="White" Font-Names="Franklin Gothic Medium" />


    <asp:GridView ID="gridPatient" runat="server" OnRowDeleting="gridPatient_RowDeleting" OnRowEditing="gridPatient_RowEditing" AllowSorting="false" AutoGenerateColumns="false" BackColor="White" BorderColor="#E7E7FF" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" EmptyDataText="Нет записей для отображения." GridLines="Horizontal" BorderStyle="None" Font-Size="X-Small" AllowPaging="True" OnPageIndexChanging="gridPatient_PageIndexChanging" PageSize="20">

            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="False" ButtonType="Link" ControlStyle-BorderColor="Purple" ControlStyle-Font-Overline="false" ControlStyle-Font-Underline="false" ControlStyle-Font-Bold="true"  ControlStyle-Font-Size="X-Small" >
<ControlStyle BorderColor="Purple" Font-Bold="True" Font-Overline="False" Font-Size="X-Small" Font-Underline="False"></ControlStyle>
                </asp:CommandField>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:BoundField DataField="Contraindications" HeaderText="Contraindications" SortExpression="Contraindications" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerSettings Mode="NextPrevious" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                            <SortedDescendingHeaderStyle BackColor="#3E3277" />

        </asp:GridView>
                     -->

        <br />    <!-- Перенос строки-->
        <br /> 
        <br /> 


                     </td>
                     <td width="450" valign="top">

<!--
    <div>
    <asp:Label ID="Label3" runat="server" Text="TABLE ''RECEPTION''" ForeColor ="White" Font-Names="Franklin Gothic Medium"></asp:Label>
    </div>

        <asp:Button ID="Button3" runat="server" Text="ADD DATA" BackColor ="#333399" ForeColor ="White" OnClick="Button3_Click" BorderColor="White" Font-Names="Franklin Gothic Medium" />

       
        <asp:GridView ID="gridReception" runat="server" OnRowDeleting="gridReception_RowDeleting" OnRowEditing="gridReception_RowEditing" AllowSorting="false" AutoGenerateColumns="false" BackColor="White" BorderColor="#E7E7FF" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" EmptyDataText="Нет записей для отображения." GridLines="Horizontal" BorderStyle="None" Font-Size="X-Small" AllowPaging="True" OnPageIndexChanging="gridReception_PageIndexChanging" PageSize="20">

            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="False" ButtonType="Link" ControlStyle-BorderColor="Purple" ControlStyle-Font-Overline="false" ControlStyle-Font-Underline="false" ControlStyle-Font-Bold="true"  ControlStyle-Font-Size="X-Small" >
<ControlStyle BorderColor="Purple" Font-Bold="True" Font-Overline="False" Font-Size="X-Small" Font-Underline="False"></ControlStyle>
                </asp:CommandField>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Doctor_Id" HeaderText="Doctor_Id" SortExpression="Doctor_Id" />
                <asp:BoundField DataField="Patient_Id" HeaderText="Patient_Id" SortExpression="Patient_Id" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerSettings Mode="NextPrevious" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                            <SortedDescendingHeaderStyle BackColor="#3E3277" />

        </asp:GridView>

-->

             </td>
             </tr>
          </table>

           </div>


        <div class="first2">
    <script type="text/javascript">
        
        function run() {

            //if (isPostBack) {

                var image = document.getElementById('bg');
                image.onload = function () {
                    var engine = new RainyDay({
                        image: this
                    });
                    engine.rain([[1, 2, 8000]]);
                    engine.rain([[3, 3, 0.88], [5, 5, 0.9], [6, 2, 1]], 100);
                };
                image.crossOrigin = 'anonymous';
                image.src = '/Images/autumn.jpg';

            //}
        }
        
        //if (isNotPostBack)
        run();
        
        var rootURL = "<%=Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Authority%>";
        /*templateLoader.registerTemplate('errorMessage', rootURL + '/Templates/error.html');

        function hideAfter(selector, sec) {
            setTimeout(function () {
                $(selector).hide(1000);
            }, sec * 1000);
        }

        
        $(function () {
            
           
        });

        $.ajax(
        {
            function (result) {
                processError(result, '.errorContainer');
            }
        })
        */
       

    </script>

        </div>
        
    </form>
</body>
</html>