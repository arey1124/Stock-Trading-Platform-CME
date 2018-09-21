<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="StockTradingPlatform.Admin.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add/Modify User</title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.7 -->
    <link href="../Styles/OtherHelperStyles/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="../Styles/OtherHelperStyles/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../Styles/OtherHelperStyles/Ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="../Styles/OtherHelperStyles/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../Styles/OtherHelperStyles/AdminLTE.min.css" rel="stylesheet" />
    <link href="../Styles/OtherHelperStyles/skins/_all-skins.min.css" rel="stylesheet" />

    
   <link rel="stylesheet" type="text/css" href="../Styles/addUser.css" />
   <!-- Google Font -->
  <link rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
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
                <span class="logo-lg"><b>CME</b> GROUP</span>
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
                                <img src="../Images/admin.png" class="user-image" alt="User Image">
                                <span class="hidden-xs">@ViewBag.fname &nbsp;@ViewBag.lname</span>
                            </a>
                            <ul class="dropdown-menu">
                                <!-- User image -->
                                <li class="user-header">
                                    <img src="../Images/admin.png" class="img-circle" alt="User Image">

                                    <p>
                                        @ViewBag.fname &nbsp;@ViewBag.lname - Web Developer
                                        <small>Member since July. 2018</small>
                                    </p>
                                </li>
                                <!-- Menu Body -->
                                <!-- Menu Footer-->
                                <li class="user-footer">
                                    <div class="pull-left">
                                        <a href="#" class="btn btn-default btn-flat">Profile</a>
                                    </div>
                                    <div class="pull-right">
                                        <a href="#" class="btn btn-default btn-flat">Logout</a>
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
                <!-- Sidebar user panel -->
                <br/>
                <!-- Sidebar user panel -->
                <div class="user-panel">
                    <div class="pull-left image">
                        <img src="../Images/admin.png" class="img-circle" alt="User Image">
                    </div>
                    <div class="pull-left info">
                        <p>@ViewBag.fname &nbsp;@ViewBag.lname</p>
                        <a href="#"><i class="fa fa-circle text-success"></i> Online</a>
                    </div>
                </div>
                <br/>
                

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
                                                           <li><asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="../Admin/AddUser.aspx"><i class="fa fa-circle-o"></i>Add Users</asp:HyperLink> </li>

                                                           <li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/ViewUsers"><i class="fa fa-circle-o"></i>View Users</asp:HyperLink> </li>

                                                           <li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/AllUsersTradeRequests"><i class="fa fa-circle-o"></i>View Trade Requests</asp:HyperLink> </li>

                                                           <li><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="../Admin/AllTransactions.aspx"><i class="fa fa-circle-o"></i>View Transactions</asp:HyperLink> </li>

                           s
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

               <!-- this is where form starts -->
    <div class="container rounded ">
        <div class="form-div">
            <h2 align="center">Add/Modify User</h2><br/><br/>
  			<p>&nbsp;&nbsp;&nbsp; Basic Information :</p>
            <form id="form1" runat="server">
                <div class="container">
                <div class=" row form-group">
                    <div class="form-group col-sm-6">
                        <asp:TextBox ID="fname" class="form-control border border-primary" runat="server" placeholder="First Name" onkeyup="validateFName()" onblur="validateFName()" required></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fname" ErrorMessage="First Name is Mandatory"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-sm-6">
                        <asp:TextBox ID="lname" class="form-control border border-primary" runat="server" placeholder="Last Name" onkeyup="validateLName()" onblur="validateLName()" required ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lname" ErrorMessage="Last Name is Mandatory"></asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form-group col-sm-6">
                        <asp:TextBox ID="email" runat="server" class="form-control border border-primary" placeholder="email" onkeyup="validateEmail()" onblur="validateEmail()" required TextMode="Email"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" ErrorMessage="Email is Incorrect" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group col-sm-6">
                        <asp:TextBox ID="mob" runat="server" class="form-control border border-primary" placeholder="Mobile Number" onkeyup="validatePhone()" onblur="validatePhone()" required TextMode="Phone"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="mob" ErrorMessage="Mobile Number Is Incorrect" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group-add col-sm-6">
                        <asp:TextBox ID="address" runat="server" class="form-control border border-primary" placeholder="Address" onkeyup="validateAddress()" onblur="validateAddress()"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="address" ErrorMessage="Address is Mandatory"></asp:RequiredFieldValidator>
                    </div>  
                    <div class="col-sm-6">
                        <asp:TextBox ID="dob" runat="server" class="form-control border border-primary" onchange="validateDOB()" onkeyup="validateDOB()" onblur="validateDOB()" placeholder="Date of Birth" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dob" ErrorMessage="Date Of Birth is Mandatory"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-5">
                        <p>Authentication Information :</p>
                    </div>
                    <div class="col-sm-12"></div>
                    <div class="form-group col-sm-6">
                        <asp:TextBox ID="uname" class="form-control border border-primary" placeholder="User Name" onkeyup="validateUname()" onblur="validateUname()" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="uname" ErrorMessage="UserName is Mandatory"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-sm-6">
                        <asp:TextBox ID="pwd" class="form-control border border-primary" placeholder="Password" onkeyup="validatePassword()" onblur="validatePassword()" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="pwd" ErrorMessage="Password is Incorrect" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group col-sm-6">
                        <asp:DropDownList ID="role" class="form-control" runat="server" onblur="validateRole()" oninput="validateRole()">
                            <asp:ListItem value="-1" Selected>Role</asp:ListItem>
                            <asp:ListItem Value="A">Admin</asp:ListItem>
                            <asp:ListItem Value="U">Trader</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="role" ErrorMessage="Choose Role" InitialValue="-1"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-sm-6">
                        <asp:DropDownList ID="status" class="form-control" runat="server">
                            <asp:ListItem value="A" Selected>Active</asp:ListItem>
                            <asp:ListItem Value="S">Inactive</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    </div>
                   
                    <div style="text-align:center">
                        <asp:Button ID="Button1" runat="server" Text="Submit" class="button btn btn-primary btn_submit" style="width:200px;" OnClick="Button1_Click" Font-Size="Medium" />
                    </div> 
                    </div>
                
            </form>
            <asp:Label ID="Label1" runat="server"></asp:Label>
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
   


    <script src="../Scripts/OtherHelperScripts/jquery/dist/jquery.min.js"></script>
    <script src="../Scripts/OtherHelperScripts/bootstrap.min.js"></script>
    <script src="../Styles/OtherHelperStyles/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
     <!-- SlimScroll -->
    <script src="../Scripts/OtherHelperScripts/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="../Scripts/OtherHelperScripts/fastclick/lib/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="../Scripts/OtherHelperScripts/js/adminlte.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../Scripts/OtherHelperScripts/js/demo.js"></script>
<script>
  $(function () {
   

    //Date picker
    $('#dob').datepicker({
      autoclose: true
    })

   
  })
</script>   
</body>
</html>
