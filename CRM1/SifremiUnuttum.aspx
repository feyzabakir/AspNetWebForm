<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SifremiUnuttum.aspx.cs" Inherits="CRM1.SifremiUnuttum" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Şifremi Unuttum</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="icon" type="image/png" href="Login/images/icons/favicon.ico"/>
	<link rel="stylesheet" type="text/css" href="Login/vendor/bootstrap/css/bootstrap.min.css">
	<link rel="stylesheet" type="text/css" href="Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
	<link rel="stylesheet" type="text/css" href="Login/vendor/animate/animate.css">
	<link rel="stylesheet" type="text/css" href="Login/vendor/css-hamburgers/hamburgers.min.css">
	<link rel="stylesheet" type="text/css" href="Login/vendor/select2/select2.min.css">
	<link rel="stylesheet" type="text/css" href="Login/css/util.css">
	<link rel="stylesheet" type="text/css" href="Login/css/main.css">

</head>
<body>
	
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<div class="login100-pic js-tilt" >
					<img src="Login/images/img-01.png" alt="IMG">
				</div>

				
				<form class="login100-form validate-form" id="form1" runat="server">
					<center>
						<span class="login100-form-title">
					Sifre Yenileme
					</span>
					</center>

					<div class="wrap-input100 validate-input" data-validate = "Valid email is required: ex@abc.xyz">
						<b>Email:</b>
						<br />
						<asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server" placeholder="Emailinizi giriniz"></asp:TextBox>
						
					</div>

					
					
					<div class="container-login100-form-btn">
						 <asp:Button ID="btn_yenile" CssClass="btn btn-success form-control" runat="server" Text="Yenile" OnClick="btn_yenile_Click" />
					</div>

				
					
				</form>
			</div>
		</div>
	</div>
	
	<script src="Login/vendor/jquery/jquery-3.2.1.min.js"></script>
	<script src="Login/vendor/bootstrap/js/popper.js"></script>
	<script src="Login/vendor/bootstrap/js/bootstrap.min.js"></script>
	<script src="Login/vendor/select2/select2.min.js"></script>
	<script src="Login/vendor/tilt/tilt.jquery.min.js"></script>
	<script >
        $('.js-tilt').tilt({
            scale: 1.1
        })
    </script>
	<script src="Login/js/main.js"></script>

</body>
</html>