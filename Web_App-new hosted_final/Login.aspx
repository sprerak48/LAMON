<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>LAN Monitaring</title>
    <meta name="keywords" content="mini social, free download, website templates, CSS, HTML" />
    <meta name="description" content="Mini Social is a free website template from templatemo.com" />
    <link href="templatemo_style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/coda-slider.css" type="text/css" media="screen"
        charset="utf-8" />
    <script src="js/jquery-1.2.6.js" type="text/javascript"></script>
    <script src="js/jquery.scrollTo-1.3.3.js" type="text/javascript"></script>
    <script src="js/jquery.localscroll-1.2.5.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/jquery.serialScroll-1.2.1.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/coda-slider.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/jquery.easing.1.3.js" type="text/javascript" charset="utf-8"></script>
    <style type="text/css">
        .style1
        {
            width: 74px;
        }
        .style2
        {
            width: 165px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="slider">
        <div id="templatemo_sidebar">
            <div id="templatemo_header">
            <img src="images/logo.png" alt="Mini Social" width="100%" height="65%" />
                <a href="#" target="_parent">
                    </a>
            </div>
            <!-- end of header -->
            <ul class="navigation">
                <li><a href="#home">Login<span class="ui_icon home"></span></a></li>
            </ul>
        </div>
        <!-- end of sidebar -->
        <div id="templatemo_main">
            <ul id="social_box">
                <li><a href="#">
                    <img src="images/lamon.jpg" alt="facebook" /></a></li>
            </ul>
            <div id="content">
                <!-- scroll -->
                <div class="scroll">
                    <div class="scrollContainer">
                        <div class="panel" id="home">
                            <h1>
                                Admin Login</h1>
                            <table style="width: 530px; height: 159px;" >
                                <tr>
                                    <td class="style1">
                                    </td>
                                    <td class="style2">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        Username:
                                    </td>
                                    <td class="style2">
                                        <asp:TextBox ID="txtUsername" runat="server" Width="143px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
                                            ErrorMessage="Username Required"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        Password:
                                    </td>
                                    <td class="style2">
                                        <asp:TextBox ID="txtPassword" runat="server" Width="142px" TextMode="Password"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                            ErrorMessage="Password REquired"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                    </td>
                                    <td class="style2">
                                        <asp:Button ID="btnLogin" runat="server" Text="Login" Width="63px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblShow" runat="server" Font-Bold="True" Font-Size="Medium" 
                                            ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div class="btn_more">
                            </div>
                        <!-- end of home -->
                    </div>
                </div>
                <!-- end of scroll -->
            </div>
            <!-- end of content -->
            <div id="templatemo_footer">
                Copyright © 2014 <a href="#"></a>| <a href="http://www.iwebsitetemplate.com" target="_parent">
                    s</a> <a href="http://www.templatemo.com" target="_parent"></a>
            </div>
            <!-- end of templatemo_footer -->
        </div>
        <!-- end of main -->
    </div>
    </form>
</body>
</html>
