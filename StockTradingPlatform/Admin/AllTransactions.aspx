<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllTransactions.aspx.cs" Inherits="StockTradingPlatform.Admin.AllTransactions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transactions</title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.7 -->
    <link href="~/Styles/OtherHelperStyles/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="~/Styles/OtherHelperStyles/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="~/Styles/OtherHelperStyles/Ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="../Styles/OtherHelperStyles/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="~/Styles/OtherHelperStyles/AdminLTE.min.css" rel="stylesheet" />
    <link href="~/Styles/OtherHelperStyles/skins/_all-skins.min.css" rel="stylesheet" />

    
   <link rel="stylesheet" type="text/css" href="../Styles/addUser.css" />
   <!-- Google Font -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
</head>
<body class="hold-transition skin-blue fixed sidebar-mini">
    <!-- Site wrapper -->
    <div class="wrapper">

        <header class="main-header">
            <!-- Logo -->
            <a href="/Admin/Index" class="logo">
                <!-- mini logo for sidebar mini 50x50 pixels -->
                <span class="logo-mini"><b>CME</b></span>
                <!-- logo for regular state and mobile devices -->
                <span class="logo-lg"><img src="../Images/whitelogo.jpg" class=" img-circle " alt="User Image" height="30px" />&nbsp;<b>CME</b> GROUP</span>
            </a>
            <!-- Header Navbar: style can be found in header.less -->
            <nav class="navbar navbar-static-top">
                <!-- Sidebar toggle button-->
                <a href="#"  data-toggle="push-menu" role="button">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </a>

                <div class="navbar-custom-menu">
                       <ul class="nav navbar-nav">
                        <!-- Messages: style can be found in dropdown.less-->
                        <!-- Notifications: style can be found in dropdown.less -->
                        <!-- Tasks: style can be found in dropdown.less -->
                        <!-- User Account: style can be found in dropdown.less -->
                        <li class="dropdown user user-menu">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                <img src="../Images/admin.png" class="user-image" alt="User Image"/>
                                <span class="hidden-xs"><%= fname %>&nbsp;<%= lname %></span>
                            </a>
                            <ul class="dropdown-menu">
                                <!-- User image -->
                                <li class="user-header">
                                    <img src="../Images/admin.png" class="img-circle" alt="User Image">

                                    <p>
                                        <%= fname %> &nbsp;<%= lname %> - Web Developer
                                        <small>Member since July. 2018</small>
                                    </p>
                                </li>
                                <!-- Menu Body -->
                                <!-- Menu Footer-->
                                <li class="user-footer">
                                    <div class="pull-left">
                                        <a href="/Admin/profile" class="btn btn-primary">Profile</a>
                                    </div>
                                    <div class="pull-right">
                                        <a href="/Admin/Logout" class="btn btn-primary">Logout</a>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <!-- Control Sidebar Toggle Button -->
                        <li>
                            <a href="/Admin/Logout"> <i class="fa fa-sign-out" aria-hidden="true"></i> Logout</a>
                        </li>
                    </ul>
                </div>
            </nav>
        </header>

        <!-- =============================================== -->
        <!-- Left side column. contains the sidebar -->
       <aside class="main-sidebar">
            <!-- sidebar: style can be found in sidebar.less -->
            <section class="sidebar">
                <br/>
                <!-- Sidebar user panel -->
                <div class="user-panel">
                    <div class="pull-left image">
                        <img src="../Images/admin.png" class="img-circle" alt="User Image">
                    </div>
                    <div class="pull-left info">
                        <p><%= fname %> &nbsp;<%= lname %></p>
                        <a href="/Admin/profile"><i class="fa fa-circle text-success"></i> Online</a>
                    </div>
                </div>
                <br/>
               

                <!-- /.search form -->
                <!-- sidebar menu: : style can be found in sidebar.less -->
                <ul class="sidebar-menu" data-widget="tree">
                    <li class="header">MAIN NAVIGATION</li>
                    <li><a href="/Admin/Index"><i class="fa fa-book"></i> <span>Dashboard</span></a></li>

                    <li class="treeview">
                        <a href="#">
                            <i class="fa fa-dashboard"></i><span>Stocks</span>
                            <span class="pull-right-container">
                                <i class="fa fa-angle-left pull-right"></i>
                            </span>
                        </a>
                        <ul class="treeview-menu">
                            <li>
                                <a href="/Admin/ListOfStocks"><i class="fa fa-circle-o"></i>View/Modify Stock</a>
                            </li>
                            <li>
                                <a href="/Admin/AddStock"><i class="fa fa-circle-o"></i>Add Stock</a>
                            </li>
                        </ul>
                    </li>

                    <li class="treeview">
                        <a href="#">
                            <i class="fa fa-dashboard"></i> <span>Users</span>
                            <span class="pull-right-container">
                                <i class="fa fa-angle-left pull-right"></i>
                            </span>
                        </a>
                        <ul class="treeview-menu">
                            <li><a href="~/Admin/AddUser.aspx"><i class="fa fa-circle-o"></i>Add User</a></li>
                            <li><a href="/Admin/ViewUsers"><i class="fa fa-circle-o"></i>View Users</a></li>
                            <li><a href="/Admin/AllUsersTradeRequests"><i class="fa fa-circle-o"></i>View Trade Requests</a></li>
                            <li><a href="/Admin/AllTransactions.aspx"><i class="fa fa-circle-o"></i>View Transactions</a></li>
                        </ul>
                    </li>

                    <li class="header">Account</li>
                    <li><a href="/Admin/Logout"><i class="fa fa-circle-o "></i> <span>Logout</span></a></li>

                </ul>
            </section>
            <!-- /.sidebar -->
        </aside>

        <!-- =============================================== -->
        <!-- Content Wrapper. Contains page content -->
        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                
                
            </section>

            <!-- Main content -->
            <section class="content">
            <div class="container rounded ">
                 <div class="form-div">
                    <h2 align="center">All Transaction</h2><br/>
  	                    <form id="form1" runat="server">
                            <div class="continer rounded">
                                 <div class="row col-sm-12">
                                     <div class="form-group col-sm-2 pull-right">
                                        <asp:Button ID="Button2" class="form-control btn btn-primary" runat="server" OnClick="Button1_Click" Text="Search" />
                                    </div>
                                    <div class="form-group col-sm-3 pull-right">
                                        <asp:TextBox ID="TextBox1" class="form-control border border-primary" runat="server" placeholder="Search By Seller/Buyer/Stock Name"></asp:TextBox>
                                    </div>
                                 </div>
                                <asp:GridView ID="GridView1" runat="server" ShowHeaderWhenEmpty="true" AllowSorting="True" CellPadding="4" CssClass="wrapper table
                                    " ForeColor="#333333" GridLines="None" HorizontalAlign="Center" style="left: 0px; top: 0px">
                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                                
                            </div>
                        </form>
                     </div>
    </div>

    <!-- this is where form ends -->



            </section>
            <!-- /.content -->
        </div>
        <!-- /.content-wrapper -->

        <footer class="main-footer">
            
            <strong>&copy;2018 .NET Team CME Stock Trading Platform</strong>
        </footer>

       
        <!-- Add the sidebar's background. This div must be placed
     immediately after the control sidebar -->
        <div class="control-sidebar-bg"></div>
    </div>
    <!-- ./wrapper -->
    <!-- jQuery 3 -->
 
    <script src="../Scripts/OtherHelperScripts/jquery/dist/jquery.min.js"></script>
    <script>
        $.widget.bridge('uibutton', $.ui.button);
    </script>
    <!-- Bootstrap 3.3.7 -->
    <script src="../Scripts/OtherHelperScripts/bootstrap.min.js"></script>

    <!-- SlimScroll -->
    <script src="../Scripts/OtherHelperScripts/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="../Scripts/OtherHelperScripts/fastclick/lib/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="../Scripts/OtherHelperScripts/js/adminlte.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../Scripts/OtherHelperScripts/js/demo.js"></script>
</body>
</html>
