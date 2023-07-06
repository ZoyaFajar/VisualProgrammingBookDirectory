<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthorPage.aspx.cs" Inherits="OELVP.AuthorPage" %>

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
    <title>Book Store Author Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="background">
    <div style="background-color: white; margin-left: 500px; margin-top: 30px; padding: 50px; height: 750px; width: 600px;">
        <div class="container"> </div> 
        <div class="form-row"> 
            <div class="col-sm-12 text-center  p-2"> 
                <h1>AUTHOR</h1>
            </div>
            <div class="col-sm-12 text-center  p-2"> 
                <asp:GridView ID="GridView1" runat="server" Width="502px" Height="122px"></asp:GridView>
            </div>
             <div class="col-sm-12 text-center  p-2"> 
                <asp:Button ID="btnInsertAuthor" runat="server" Text="Insert Author" OnClick="btnInsertAuthor_Click" />
            </div>
           <div class="col-sm-12 text-center  p-2"> 
                <asp:Button ID="btnUpdateAuthor" runat="server" Text="Update Author" OnClick="btnUpdateAuthor_Click" />
            </div>
             <div class="col-sm-12 text-center  p-2"> 
                <asp:Button ID="btnDeleteAuthor" runat="server" Text="Delete Author" OnClick="btnDeleteAuthor_Click" />
            </div>
            <div class="col-sm-12 text-center  p-2"> 
                <asp:Button ID="btnHome" runat="server" Text="Home" OnClick="btnHome_Click" />
            </div>
            
    </div>
</div>
    </form>
</body>
</html>
