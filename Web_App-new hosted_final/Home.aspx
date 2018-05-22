<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Home" MaintainScrollPositionOnPostback="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <script type="text/javascript">
        function RadioCheck(rb) {
            var gv = document.getElementById("<%=GridView1.ClientID%>");
            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }
                }
            }
        }     
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="slider">
        <div id="templatemo_sidebar">
            <div id="templatemo_header">
                <a href="#" target="_parent">
                  <img src="images/logo.png" alt="Mini Social" width="100%" height="65%"/></a>
            </div>
            <!-- end of header -->
            <ul class="navigation">
                <li><a href="#home">Home<span class="ui_icon home"></span></a></li>
                <li><a href="#aboutus">About Us<span class="ui_icon aboutus"></span></a></li>
                <li><a href="#services">Process List<span class="ui_icon services"></span></a></li>
                <%--<li><a href="Login.aspx">Logout</a></li>--%>
                <li><a href="#contactus">Manage Computer<span class="ui_icon contactus"></span></a></li>
                <li><a href="#gallery">Logout<span class="ui_icon gallery"></span></a></li>
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
                                INTRODUCING LAMON</h1>
                            <%--<div class="image_wrapper image_fl">
                                <img src="images/templatemo_image_01.jpg" alt="image" /></div>--%>
                            <p>
                                <em>The most highly demanding task in the field of IT industries is the efficient computer
                                    network management. There are many urgent issues or requests related to such networks
                                    which network manager needs to solve immediately for avoiding the any kind of interruptions.
                                    But sometimes, network managers may be situated at different places, so in such
                                    cases there is not possible to resolve any urgent issues with the office network
                                    tasks. Thus in order to solve such problems in this project we describes the architecture
                                    of a novel tool for network management using GSM/GPRS mobile devices. In a concern,
                                    computers are grouped together to form a network. To manage and control the activities
                                    of the network while in office is an easy task. But, while you are outstation /
                                    away from office, how do you go about with monitoring and controlling of network?
                                    Instead of depending on third party information, you can always have your cell phone
                                    serve the purpose. Just load the project in your cell phone, login anytime to the
                                    application and see who is busy with what in the office. Consider a LAN setup with
                                    the server machine connected to GSM service provider via a GSM modem. The interaction
                                    between the clients and the wireless media happens through this server. At the end,
                                    it shows results by depicting the screen of several mobile devices, which provide
                                    network management information. </em>
                            </p>
                            <div class="btn_more">
                                <a href="#aboutus">More <span>&raquo;</span></a></div>
                        </div>
                        <!-- end of home -->
                        <div class="panel" id="aboutus">
                            <%-- <h1>
                                About Us</h1>--%>
                            <div class="image_wrapper image_fl">
                                <img src="images/network_monitor.jpg" alt="image" width="500px" height="300px" /><br />
                               <%-- <p>DEVELOP BY:-</p>
                                <p>PRERAK SHAH(1380048)</p><p>AAKASH SHAH(1380044)</p><p>DHARMIL SHAH(1380051)</p>--%>
                            </div>
                            <%--<p>
                                <em>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse in lectus turpis.
                                    Vivamus cursus tortor quis leo ullamcorper auctor quis tincidunt metus.</em></p>
                            <p>
                                Vestibulum vitae lectus a leo commodo egestas. Sed et ligula mauris. Donec interdum
                                iaculis eros, sed porttitor justo ornare ac. Suspendisse ultrices arcu auctor sapien
                                malesuada dictum. <a href="#">Vivamus non</a> ante sit amet ligula dignissim blandit
                                ut sit amet purus. Sed tristique euismod lectus sed scelerisque. Curabitur convallis
                                fringilla ante, eget eleifend magna iaculis eget. Praesent at nunc tellus. Sed sed
                                auctor odio. Maecenas ut mauris eu ligula placerat tempor vel ac augue. Integer
                                fermentum, ante eget sodales lacinia, nisl diam semper elit, non hendrerit nunc
                                urna vitae erat. Etiam vel nisi risus.</p>--%>
                            <%-- <p>
                                Vestibulum tempus porttitor ipsum, ut dictum metus molestie eu. Donec interdum,
                                mi ut facilisis posuere, neque sapien lacinia urna, nec hendrerit dolor arcu sed
                                justo. Aenean rhoncus porttitor dolor non posuere. Nulla eu mi id tellus vehicula
                                pellentesque et vitae magna.
                            </p>--%>
                        </div>
                        <div class="panel" id="services">
                            <h1>
                                Process List&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" /></h1>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                DataSourceID="SqlDataSource1" Font-Size="Large" ForeColor="#333333" GridLines="None"
                                Width="550px" AllowPaging="True" AllowSorting="True">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="P_id" HeaderText="PID" SortExpression="PID">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IPAddress" HeaderText="IPAddress" SortExpression="IPAddress">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Name" HeaderText="Process Name" SortExpression="Name">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <%-- <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:RadioButton ID="RadioButton1" runat="server" onclick="RadioCheck(this);" />
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("P_Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:HyperLinkField DataNavigateUrlFields="P_id" DataNavigateUrlFormatString="kill.aspx?action=edit&amp;P_id={0}"
                                        HeaderText="Action" Text="Kill" Target="_self">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:HyperLinkField>
                                    <%--<asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandArgument='<%#Eval("L_id") %>'
                                                CommandName="Delete" OnCommand="Delete_row" Text="Delete" OnClientClick="return confirm('Are you certain you want to delete this?');"
                                                ForeColor="Red"></asp:LinkButton></ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                    </asp:TemplateField>--%>
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Location_trackingConnectionString %>"
                                SelectCommand="SELECT * FROM [ProcessList]">
                                <DeleteParameters>
                                    <asp:Parameter Name="p_id" />
                                </DeleteParameters>
                            </asp:SqlDataSource>
                            <br />
                            <%-- <asp:Button ID="btnkill" Text="Kill" Width="100px" Height="40px" runat="server" />--%>
                        </div>
                        <div class="panel" id="contactus">
                            <h1>
                                Manage Computer</h1>
                            <div id="contact_form">
                                <div style="text-align: center;">
                                    Select IP Address:
                                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                                        DataTextField="IPAddress" DataValueField="IPAddress" Height="25px" Width="123px"
                                        AutoPostBack="false">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Location_trackingConnectionString %>"
                                        SelectCommand=" select distinct ipaddress from processlist"></asp:SqlDataSource>
                                    <br />
                                    <br />
                                    <center>  
                                    <table style="height:100px; width:100px;">
                                        <tr>
                                            <td>
                                            Shutdown
                                            </td>
                                            
                                            <td>
                                            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="manage" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            Restart
                                            </td>
                                            <td>
                                             <asp:RadioButton ID="RadioButton2" runat="server" GroupName="manage" />
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                            LogOff
                                            </td>
                                            <td>
                                             <asp:RadioButton ID="RadioButton3" runat="server" GroupName="manage"/>
                                            </td>
                                        </tr>
                                        <tr><td colspan="2"><asp:Button ID="btnSubmit" runat="server" Text="Submit"></asp:Button></td></tr>
                                    </table>
                                    </center>
                                    <%-- 
                                     <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                                    DataTextField="description" DataValueField="user_type_id" Height="25px" Width="123px"
                                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="0">Select User Type</asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:tpo_dbConnectionString %>"
                                    SelectCommand="SELECT [user_type_id], [description] FROM [user_type_auto] where description<> 'Admin'">
                                </asp:SqlDataSource>
                                    --%>
                                </div>
                            </div>
                        </div>
                        <div class="panel" id="gallery">
                            <h1>
                                Logout</h1>
                            <div id="gallery_container">
                                <table>
                                    <tr>
                                        <td>
                                            Are You Sure You To Logout
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnlogout" runat="server" Text="Logout" Height="35px" Width="100px" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                <div class="cleaner">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end of scroll -->
            </div>
            <!-- end of content -->
            <div id="templatemo_footer">
                Copyright © 2016 <a href="#"></a>| <a href="" target="_parent"></a><a href="" target="_parent">
                </a>
            </div>
            <!-- end of templatemo_footer -->
        </div>
        <!-- end of main -->
    </div>
    </form>
</body>
</html>
