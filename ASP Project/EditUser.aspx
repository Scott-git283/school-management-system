<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="ASP_Project.EditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit User</title>
    <link href="assets/css/admin.css" rel="stylesheet" />
    <style>
        .form-box {
            max-width: 500px;
            margin: 30px auto;
            background: #fff;
            padding: 25px;
            border-radius: 12px;
            box-shadow: 0 6px 15px rgba(0,0,0,0.08);
        }
        .form-box div {
            margin-bottom: 18px;
        }
        .form-box label {
            display: block;
            font-weight: 600;
            margin-bottom: 6px;
        }
        .form-box input[type="text"], 
        .form-box input[type="email"], 
        .form-box input[type="password"],
        .form-box input[type="file"] {
            width: 100%;
            padding: 12px;
            border: 1px solid #dcdfe3;
            border-radius: 8px;
            font-size: 15px;
            background: #fafafa;
        }
        .btn {
            background: #1abc9c;
            color: #fff;
            padding: 12px;
            border-radius: 8px;
            border: none;
            cursor: pointer;
            width: 100%;
            font-size: 16px;
        }
        .btn:hover {
            background: #16a085;
        }
        .profile-img {
            width: 120px;
            height: 120px;
            border-radius: 50%;
            object-fit: cover;
            border: 2px solid #1abc9c;
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div class="form-box">
            <h2>Edit User</h2>

            <asp:HiddenField ID="hfUserID" runat="server" />

            <div>
                <label>Full Name</label>
                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div>
                <label>Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
            </div>

            <div>
                <label>Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>

            <div>
                <label>Profile Photo</label>
                <asp:Image ID="imgPhoto" runat="server" CssClass="profile-img" />
                <asp:FileUpload ID="fuPhoto" runat="server" CssClass="form-control" />
            </div>

            <div>
                <asp:Button ID="btnUpdate" runat="server" Text="Update User" CssClass="btn" OnClick="btnUpdate_Click" />
            </div>

        </div>
    </form>
</body>
</html>
