<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminSetup.aspx.cs" Inherits="ASP_Project.AdminSetup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Create Admin (one time)</h3>
            <asp:Label ID="lblInfo" runat="server" ForeColor="Red"></asp:Label><br />
            <div>
                Email:
                <asp:TextBox ID="txtEmail" runat="server" />
            </div>
            <div>
                Full name:
                <asp:TextBox ID="txtName" runat="server" />
            </div>
            <div>
                Password:
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
            </div>
            <div style="margin-top: 10px;">
                <asp:Button ID="btnCreate" runat="server" Text="Create Admin" OnClick="btnCreate_Click" />
            </div>
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
