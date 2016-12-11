<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HospitalWebForm.aspx.cs" Inherits="HospitalWebApplication.HospitalWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Hospital Web Application</title>

    <link href="/Content/Site.css" rel="stylesheet" type="text/css" />

    <style>
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

        div.first {
            position: absolute;
            width: 1500px;
            height: 1500px;
            left: 0px;
            top: 0px;
            z-index: 1;
        }

        img {
            width: 100%;
            height: 100%;
        }
    </style>

    <!-- Для Background изображения -->
    <img id="bg" alt="background" src="" />

    <script type="text/javascript" src="Scripts/jquery-1.9.0.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.tmpl.js"></script>
    <script type="text/javascript" src="Scripts/MyScripts/errorHandling.js"></script>
    <script type="text/javascript" src="Scripts/MyScripts/TemplateLoader.js"></script>
    <script type="text/javascript" src="Scripts/MyScripts/rainyday.js"></script>

    <link href="/Content/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="/Scripts/jtable/themes/lightcolor/red/jtable.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/modernizr-2.6.2.js" type="text/javascript"></script>

    <script type="text/javascript" src="Scripts/jquery-ui-1.10.0.js"></script>
    <script src="/Scripts/jtablesite.js" type="text/javascript"></script>
 
    <!-- A helper library for JSON serialization -->
    <script type="text/javascript" src="Scripts/jtable/external/json2.js"></script>
    <!-- Core jTable script file -->
    <script type="text/javascript" src="/Scripts/jtable/jquery.jtable.js"></script>
    <!-- ASP.NET Web Forms extension for jTable -->
    <script type="text/javascript" src="/Scripts/jtable/extensions/jquery.jtable.aspnetpagemethods.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <!-- Поле для вывода ошибки -->
        <asp:Label ID="lblError" CssClass="cc" runat="server" ForeColor="Red"></asp:Label>
        <!-- Класс, в котором выводятся таблицы -->
        <div class="first">

            <!-- Сюда будет встраиваться JTables таблица -->
            <div id="DoctorTableContainer" style="width: 650px;"></div>

            <!-- Описание JTables таблицы с помощью JS -->
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
                                width: '23%'
                            },
                            Name: {
                                title: 'Name',
                                width: '23%'
                            },
                            Age: {
                                title: 'Age',
                                width: '10%'
                            },
                            Gender: {
                                title: 'Gender',
                                width: '15%',
                                options: { 'Male': 'Male', 'Female': 'Female' }
                            },
                            Position: {
                                title: 'Position',
                                width: '25%'
                            }
                        }
                    });

                    //Load doctors list from server
                    $('#DoctorTableContainer').jtable('load');
                });

            </script>





            <br />
            <!-- Перенос строки-->
            <br />
            <br />


            <br />
            <!-- Перенос строки-->
            <br />
            <br />

 

        </div>

        <!-- Вывод фонового динамического изображения -->
        <div class="first2">
            <script type="text/javascript">

                function run() {
                    var image = document.getElementById('bg');
                    image.onload = function () {
                        var engine = new RainyDay({
                            image: this
                        });
                        engine.rain([[1, 2, 8000]]);
                        engine.rain([[3, 3, 0.88], [5, 5, 0.9], [6, 2, 1]], 100);
                    };
                    image.crossOrigin = 'anonymous';
                    image.src = '/Content/images/autumn.jpg';
                }

                run();

                //var rootURL = "<%=Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Authority%>";

                /*templateLoader.registerTemplate('errorMessage', rootURL + '/Templates/error.html');

                function hideAfter(selector, sec) {
                    setTimeout(function () {
                        $(selector).hide(1000);
                    }, sec * 1000);
                }

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