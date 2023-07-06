<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="OELVP.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!--Bootstrap Links-->
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css">
 
    <!-- jQuery library -->
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.0/dist/jquery.slim.min.js"></script>
 
    <!-- Popper JS -->
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
 
    <!-- Latest compiled JavaScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js"></script>
    <style>
     .background{
     background-image: linear-gradient(250deg, rgb(0, 17, 255), rgb(219,112,147));
     background-repeat: no-repeat;
     height: 100vh;
     overflow: auto;
     }
    input{
    display: block;
    width: 100%;
    margin-top: 5px;
    border-radius: 5px;
    padding: 8px;
    outline: none;
     }
 </style>
    <title>Book Store Login Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="background">
    <div style="background-color: white; margin-left: 500px; margin-top: 30px; padding: 50px; height: 450px; width: 540px;">
        <div class="container"> </div> 
        <div class="form-row"> 
            <div class="col-sm-12 text-center  p-2"> 
                <h1>LOGIN</h1>
            </div>
            <div class="col-sm-6 text-center  p-2"> 
                Username:
            </div>
            <div class="col-sm-6 text-center  p-2"> 
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-6 text-center  p-2"> 
                Password:
            </div>
            <div class="col-sm-6 text-center  p-2"> 
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-12 text-center  p-2"> 
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>
            <div class="col-sm-12 text-center  p-2"> 
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
    </div>
</div>
    </form>
</body>
</html>
