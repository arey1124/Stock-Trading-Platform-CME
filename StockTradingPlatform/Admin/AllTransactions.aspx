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
  <link rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
</head>
<body class="hold-transition skin-blue sidebar-collapse sidebar-mini">
    <!-- Site wrapper -->
    <div class="wrapper">

        <header class="main-header">
            <!-- Logo -->
            <a href="/Admin/Index" class="logo">
                <!-- mini logo for sidebar mini 50x50 pixels -->
                <span class="logo-mini"><b>CME</b></span>
                <!-- logo for regular state and mobile devices -->
                <span class="logo-lg"><b>CME</b> GROUP</span>
            </a>
            <!-- Header Navbar: style can be found in header.less -->
            <nav class="navbar navbar-static-top">
                <!-- Sidebar toggle button-->
                <a href="#" class="sidebar-toggle" data-toggle="push-menu" role="button">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </a>

                <div class="navbar-custom-menu">
                    <ul class="nav navbar-nav">
                        <!-- Messages: style can be found in dropdown.less-->
                        <!-- Control Sidebar Toggle Button -->

                    </ul>
                </div>
            </nav>
        </header>

        <!-- =============================================== -->
        <!-- Left side column. contains the sidebar -->
        <aside class="main-sidebar">
            <!-- sidebar: style can be found in sidebar.less -->
            <section class="sidebar">
                <!-- Sidebar user panel -->
                

                <!-- /.search form -->
                <!-- sidebar menu: : style can be found in sidebar.less -->
                <ul class="sidebar-menu" data-widget="tree">
                    <li class="header">MAIN NAVIGATION</li>
                    <li><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Admin/Index"><i class="fa fa-book"></i> <span>Dashboard</span></asp:HyperLink> </li>

                    <li class="treeview">
                        <a href="#">
                            <i class="fa fa-dashboard"></i> <span>Stocks</span>
                            <span class="pull-right-container">
                                <i class="fa fa-angle-left pull-right"></i>
                            </span>
                        </a>
                        <ul class="treeview-menu">
                            <li>
                                
                                
                               <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/ListOfStocks"><i class="fa fa-circle-o"></i>View/Modify Stock</asp:HyperLink> 


                            </li>
                            <li>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/AddStock"><i class="fa fa-circle-o"></i>Add Stock</asp:HyperLink> 
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
                                                           <li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/ViewUsers"><i class="fa fa-circle-o"></i>View Users</asp:HyperLink> </li>

                                                           <li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/AllUsersTradeRequests"><i class="fa fa-circle-o"></i>View Trade Requests</asp:HyperLink> </li>

                                                           <li><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/Index"><i class="fa fa-circle-o"></i>View Transactions</asp:HyperLink> </li>

                           
                        </ul>
                    </li>




                    <li class="header">Account</li>
                    <li><a href="#"><i class="fa fa-circle-o "></i> <span>Logout</span></a></li>

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
</body>
</html>
