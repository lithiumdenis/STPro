<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HospitalWebForm.aspx.cs" Inherits="HospitalWebApplication.HospitalWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Hospital Web Application</title>

    <!-- Site css -->
    <link href="/Scripts/MyScripts/StyleSheetHospitalWebForm.css" rel="stylesheet" type="text/css" />

    <!-- JQuery -->
    <script type="text/javascript" src="Scripts/jquery-1.9.0.min.js"></script>

    <!-- Rain -->
    <script type="text/javascript" src="Scripts/rainyday.js"></script>
    <script type="text/javascript" src="/Scripts/MyScripts/rainStartSettings.js"></script>

    <!-- JTable Design -->
    <link href="/Content/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="/Scripts/jtable/themes/metro/crimson/jtable.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/modernizr-2.6.2.js" type="text/javascript"></script>

    <script type="text/javascript" src="Scripts/jquery-ui-1.10.0.js"></script>
    <script src="/Scripts/jtablesite.js" type="text/javascript"></script>

    <!-- A helper library for JSON serialization -->
    <script type="text/javascript" src="Scripts/jtable/external/json2.js"></script>
    <!-- Core jTable script file -->
    <script type="text/javascript" src="/Scripts/jtable/jquery.jtable.js"></script>
    <!-- ASP.NET Web Forms extension for jTable -->
    <script type="text/javascript" src="/Scripts/jtable/extensions/jquery.jtable.aspnetpagemethods.js"></script>

    <!-- Localization -->
    <script type="text/javascript" src="/Scripts/jtable/localization/jquery.jtables.myRussianLocalization.js"></script>

    <!-- Clock -->
    <script type="text/javascript" src="/Scripts/jquery.thooClock.js"></script>
    <script type="text/javascript" src="/Scripts/MyScripts/analogClockSettings.js"></script>

    <!-- JTables settings -->
    <script type="text/javascript" src="/Scripts/MyScripts/JTableDoctorSettings.js"></script>
    <script type="text/javascript" src="/Scripts/MyScripts/JTablePatientSettings.js"></script>
    <script type="text/javascript" src="/Scripts/MyScripts/JTableReceptionSettings.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <!-- Вывод фонового динамического изображения -->
        <img id="bg" alt="background" src="" />

        <div class="first2">
            <script type="text/javascript">
                runRain();
            </script>
        </div>

        <!-- Поле для вывода ошибки -->
        <asp:Label ID="lblError" CssClass="cc" runat="server" ForeColor="Red"></asp:Label>

        <!-- Класс, в котором выводятся таблицы -->
        <div class="first">
            <div class="firstInner">

                <!-- Таблица, благодаря которой задаётся положение объектов на странице-->
                <div class="left">
                    <div id="DoctorTableContainer"></div>
                    <br />
                    <div id="PatientTableContainer"></div>
                </div>

                <div class="right">
                    <div id="ReceptionTableContainer"></div>
                    <br />
                    <div class="clockContainer">
                        <div id="myclock"></div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>