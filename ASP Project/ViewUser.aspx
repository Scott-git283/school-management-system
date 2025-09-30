<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="ASP_Project.assets.css.ViewUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>View User</title>
    <style>
        body {
            font-family: "Segoe UI", sans-serif;
            background: #f0f2f5;
            padding: 20px;
        }
        .card {
            background: #fff;
            padding: 30px;
            border-radius: 12px;
            max-width: 500px;
            margin: 50px auto;
            box-shadow: 0 6px 15px rgba(0,0,0,0.08);
        }
        .card h2 {
            text-align: center;
            color: #2c3e50;
            margin-bottom: 25px;
        }
        .user-info label {
            font-weight: 600;
            display: block;
            margin-top: 15px;
            color: #34495e;
        }
        .user-info span {
            display: block;
            padding: 10px;
            background: #fafafa;
            border-radius: 6px;
            margin-top: 5px;
        }
        .user-photo {
            text-align: center;
            margin-bottom: 20px;
        }
        .user-photo img {
            width: 120px;
            height: 120px;
            border-radius: 50%;
            object-fit: cover;
            border: 2px solid #1abc9c;
        }
        .back-btn {
            display: block;
            margin: 20px auto 0;
            width: 120px;
            text-align: center;
            padding: 10px;
            background: #1abc9c;
            color: #fff;
            border-radius: 8px;
            text-decoration: none;
            font-weight: bold;
        }
        .back-btn:hover {
            background: #16a085;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>View User</h2>

        <div class="user-photo">
            <asp:Image ID="imgPhoto" runat="server" Width="120px" Height="120px" />
        </div>

        <div class="user-info">
            <label>User ID:</label>
            <asp:Literal ID="lblUserID" runat="server"></asp:Literal>

            <label>Full Name:</label>
            <asp:Literal ID="lblFullName" runat="server"></asp:Literal>

            <label>Email:</label>
            <asp:Literal ID="lblEmail" runat="server"></asp:Literal>

            <label>Password:</label>
            <asp:Literal ID="lblPassword" runat="server"></asp:Literal>

            <label>Created At:</label>
            <asp:Literal ID="lblCreatedAt" runat="server"></asp:Literal>
        </div>

        <a href="ManageUsers.aspx" class="back-btn">Back</a>
        </div>
    </form>
</body>
</html>
