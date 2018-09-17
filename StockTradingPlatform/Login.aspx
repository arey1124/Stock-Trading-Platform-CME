<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StockTradingPlatform.Login" %>

<!DOCTYPE>
<html>
<head>
<title>Login</title>
<script src="jquery.js"></script>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>

<link href="Styles/login.css" rel="stylesheet" />


</head>
<body>
	<nav class="navbar navbar-expand-lg navbar-light bg-light">
	  <a class="navbar-brand" href="#">
	    <img src="Images/logo.png"  height="30" alt="">
	  </a>
	  <div class="collapse navbar-collapse" id="navbarNavDropdown">
	    <ul class="navbar-nav mr-auto">
	      <li class="nav-item active">
	        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
	      </li>
	      <li class="nav-item">
	        <a class="nav-link" href="#">About</a>
	      </li>
	      <li class="nav-item">
	        <a class="nav-link" href="#">Contact</a>
	      </li>
	      <li class="nav-item">
	        <a class="nav-link" href="#">Stock Data</a>
	      </li>
	    </ul>
	    <ul class="navbar-nav">
	    	<li class="nav-item mr-sm-2">
		      <a class="nav-link" href="Login.aspx">Login</a>
		    </li>
	    </ul>
	  </div>
	</nav>
	<div class="curve-image-top">
		<img src="Images/curve.png" width="50%">
	</div>
	<div class="container rounded login-div">
		<img src="Images/logo.png" class="login-logo">
		<div class="form-div">
			<form id="form" runat="server">
			  <div class="form-group">
			    <asp:TextBox runat="server"  class="form-control border border-primary" id="email" aria-describedby="emailHelp" placeholder="Email" ></asp:TextBox>
			  </div>
			  <div class="form-group">
			    <asp:TextBox type="password" runat="server" class="form-control border border-primary" id="password" placeholder="Password" onblur="validatePassword()" onkeyup="validatePassword()" ></asp:TextBox>
			  </div>
              <asp:Button runat="server" class=" col-sm-12 btn btn-primary" Text="Login" OnClick="Unnamed1_Click" />
			  <asp:Label ID="Label1" runat="server" class="col-sm-12 form-text text-center" ></asp:Label>
			  <small id="forgotpass" class="col-sm-12 form-text text-center text-primary forgot-pass">Forgot Password ?</small>
			</form>
		</div>
	</div>
	<div class="curve-image-top" >
		<img src="Images/curve-bottom.png" class="image-bottom">
	</div>

	<script type="text/javascript">
		
		function validateEmail() {
			var obj1 = document.getElementById("email");
			var mail = document.getElementById("email").value;
	 		if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail))  
	  		{  
	  			obj1.style.backgroundColor=""; 
	  		}  
	  		else
	  		{
	  			obj1.style.backgroundColor="#ffc2b3";   
	  		}
		}

		function validatePassword()
		{
			var regex = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}/;
			var obj1 = document.getElementById("password");
			var pwd = document.getElementById("password").value;
			if(!regex.test(pwd))
			{
				obj1.style.backgroundColor="#ffc2b3";
	    	}
	    	else
	    	{
	    		obj1.style.backgroundColor="";
	    	}		
		}
	</script>


</body>
</html>
