<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CRM1.Login2" %>


<!DOCTYPE html>
<html lang="en">
<head>
	<title>Gİriş Sayfası</title>
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
					<span class="login100-form-title">
						Kullanıcı Girişi
					</span>

					<div class="wrap-input100 validate-input" data-validate = "Valid email is required: ex@abc.xyz">
						<b>Kullanıcı Adı</b>
						 <asp:TextBox ID="txt_kullaniciadi" CssClass="form-control" runat="server" placeholder="Kullanıcı Adı"></asp:TextBox>
						
					</div>

					<div class="wrap-input100 validate-input" data-validate = "Password is required">
							<b>Şifre</b>
						 <asp:TextBox ID="txt_sifre" TextMode="Password" CssClass="form-control" runat="server"  placeholder="Şifre"></asp:TextBox>
						
					</div>
					
					<div class="container-login100-form-btn">
						 <asp:Button ID="btn_giris" CssClass="btn btn-danger form-control" runat="server" OnClick="login" Text="Giriş Yap" />
					</div>

					<div class="text-center p-t-12">
						
						 <div class="form-group" style="float:right">
                      <a href="SifremiUnuttum.aspx">Şifremi Unuttum</a>
                </div>
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

