<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseDetails.aspx.cs" Inherits="ASP_Project.CourseDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Details</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pnlCourse" runat="server" Visible="false" CssClass="card shadow-lg p-4">
                <div class="row">
                    <!-- Left: Image -->
                    <div class="col-md-5">
                        <asp:Image ID="imgCourse" runat="server" CssClass="img-fluid rounded" />
                    </div>

                    <!-- Right: Details -->
                    <div class="col-md-7">
                        <h2>
                            <asp:Label ID="lblTitle" runat="server" /></h2>
                        <p class="text-muted">
                            <asp:Label ID="lblCategory" runat="server" />
                        </p>
                        <p>
                            <asp:Label ID="lblDescription" runat="server" />
                        </p>

                        <div class="mt-3">
                            <strong>Price: </strong>
                            <span class="text-primary fw-bold">$<asp:Label ID="lblPrice" runat="server" /></span>
                        </div>

                        <div class="mt-2">
                            <strong>Rating: </strong>
                            <asp:Label ID="lblRating" runat="server" />
                            (<asp:Label ID="lblReviews" runat="server" />
                            reviews)
                        </div>

                        <div class="mt-4">
                            <a href="Courses.aspx" class="btn btn-secondary">Back to Courses</a>
                            <asp:Button ID="btnEnroll" runat="server" Text="Enroll Now"
                                CssClass="btn btn-primary mt-3" OnClick="btnEnroll_Click" />
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false" />
        </div>
    </form>
</body>
</html>
