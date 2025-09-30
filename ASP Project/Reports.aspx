<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="ASP_Project.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mb-4">📊 Reports Dashboard</h2>

    <div class="row">
        <div class="col-md-3">
            <div class="card text-white bg-primary mb-3 shadow">
                <div class="card-body">
                    <h5 class="card-title">👨‍🎓 Total Students</h5>
                    <h3><asp:Label ID="lblTotalStudents" runat="server" Text="0"></asp:Label></h3>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card text-white bg-success mb-3 shadow">
                <div class="card-body">
                    <h5 class="card-title">📚 Total Courses</h5>
                    <h3><asp:Label ID="lblTotalCourses" runat="server" Text="0"></asp:Label></h3>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card text-white bg-warning mb-3 shadow">
                <div class="card-body">
                    <h5 class="card-title">📝 Quizzes Taken</h5>
                    <h3><asp:Label ID="lblTotalQuizzes" runat="server" Text="0"></asp:Label></h3>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card text-white bg-danger mb-3 shadow">
                <div class="card-body">
                    <h5 class="card-title">📩 Messages</h5>
                    <h3><asp:Label ID="lblTotalMessages" runat="server" Text="0"></asp:Label></h3>
                </div>
            </div>
        </div>
    </div>

    <!-- Future area for charts -->
    <div class="card mt-4 shadow">
        <div class="card-body">
            <h4>📈 Activity Overview</h4>
            <p>This section can be expanded with graphs (students growth, quiz attempts per course, etc.).</p>
        </div>
    </div>
</asp:Content>
