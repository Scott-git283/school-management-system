<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="ASP_Project.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <link href="assets/css/form-style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="max-width: 400px; margin: 60px auto;">
        <!-- ? Preloader Start -->
        <div id="preloader-active">
            <div class="preloader d-flex align-items-center justify-content-center">
                <div class="preloader-inner position-relative">
                    <div class="preloader-circle">
                    </div>
                    <div class="preloader-img pere-text">
                        <img src="assets/img/logo/loder.png" alt=""/>
                    </div>
                </div>
            </div>
        </div>
        <!-- Preloader Start -->
        <div>
            <h2>Admin Login</h2>
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label><br />
            <div>
                <label>Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
            </div>
            <div>
                <label>Password</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
            </div>
            <div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
