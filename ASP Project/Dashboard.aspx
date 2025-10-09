<%@ Page Title="" Language="C#" MasterPageFile="~/project.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ASP_Project.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        /* ===== Dashboard Page Styles ===== */

        .dashboard-container {
            background-color: #f9fafc;
            border-radius: 15px;
            box-shadow: 0 5px 20px rgba(0,0,0,0.1);
            padding: 40px;
            margin-top: 50px;
        }

            .dashboard-container h2 {
                font-weight: 700;
                color: #333;
            }

        .profile-section {
            text-align: center;
            padding: 20px;
        }

        .profile-pic {
            width: 120px;
            height: 120px;
            border-radius: 50%;
            object-fit: cover;
            border: 3px solid #ddd;
            margin-bottom: 10px;
        }

        .profile-name {
            font-size: 20px;
            font-weight: bold;
        }

        .profile-email {
            font-size: 14px;
            color: #666;
        }


        .progress {
            background-color: #e9ecef;
            border-radius: 20px;
            overflow: hidden;
        }

        .progress-bar {
            font-weight: bold;
            text-align: center;
            font-size: 14px;
            transition: width 0.5s ease;
        }

        h4.section-title {
            font-size: 1.4rem;
            font-weight: 600;
            color: #444;
            margin-bottom: 15px;
            border-left: 5px solid #007bff;
            padding-left: 10px;
        }

        .table {
            background-color: #fff;
            border-radius: 8px;
            overflow: hidden;
            box-shadow: 0 3px 10px rgba(0,0,0,0.05);
        }

            .table thead {
                background-color: #007bff;
                color: #fff;
            }

        .btn-logout {
            border-radius: 30px;
            font-weight: 500;
            padding: 10px 30px;
            box-shadow: 0 3px 6px rgba(255,0,0,0.3);
            transition: all 0.3s;
        }

            .btn-logout:hover {
                transform: scale(1.05);
                background-color: #dc3545 !important;
            }

        @media (max-width: 768px) {
            .dashboard-container {
                padding: 20px;
            }

            .profile-section {
                text-align: center;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container dashboard-container">
        <h2 class="text-center mb-4">Welcome to Your Dashboard</h2>

        <!-- Profile Section -->
        <div class="profile-section">
            <asp:Image ID="profilePic" runat="server" CssClass="profile-pic" />
            <asp:Label ID="lblName" runat="server" CssClass="profile-name"></asp:Label>
            <asp:Label ID="lblEmail" runat="server" CssClass="profile-email"></asp:Label>
        </div>


        <!-- Progress -->
        <h4 class="section-title">Course Progress</h4>
        <div class="progress mb-5" style="height: 25px;">
            <div id="progressFill" runat="server" class="progress-bar bg-success" style="width: 60%">60%</div>
        </div>

        <!-- My Courses -->
        <h4 class="section-title">My Courses</h4>
        <asp:GridView ID="gvCourses" runat="server" CssClass="table table-bordered table-striped mb-5"></asp:GridView>

        <!-- My Quiz Results -->
        <h4 class="section-title">My Quiz Results</h4>
        <asp:GridView ID="gvResults" runat="server" CssClass="table table-bordered table-striped mb-5"></asp:GridView>

        <div class="text-center mt-5">
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger btn-logout" OnClick="btnLogout_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
