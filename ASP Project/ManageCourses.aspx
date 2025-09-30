<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageCourses.aspx.cs" Inherits="ASP_Project.ManageCourses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Manage Courses</h2>

    <!-- Add Course Form -->
    <div style="margin-bottom: 20px; border: 1px solid #ccc; padding: 15px; border-radius: 5px; background: #f9f9f9;">
        <h3>Add New Course</h3>

        <asp:Label ID="lblTitle" runat="server" Text="Course Title:" AssociatedControlID="txtTitle"></asp:Label><br />
        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" /><br />

        <asp:Label ID="lblCategory" runat="server" Text="Category:" AssociatedControlID="txtCategory"></asp:Label><br />
        <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" /><br />

        <asp:Label ID="lblDescription" runat="server" Text="Description:" AssociatedControlID="txtDescription"></asp:Label><br />
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" /><br />

        <asp:Label ID="lblPrice" runat="server" Text="Price:" AssociatedControlID="txtPrice"></asp:Label><br />
        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" /><br />

        <asp:Label ID="lblImage" runat="server" Text="Upload Course Image:" AssociatedControlID="fuImage"></asp:Label><br />
        <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control" /><br />

        <asp:Button ID="btnAddCourse" runat="server" Text="Add Course" CssClass="btn btn-success" OnClick="btnAddCourse_Click" />
    </div>
    <!-- Course Grid -->
    <asp:GridView ID="GridViewCourses" runat="server" AutoGenerateColumns="False" CssClass="table"
        DataKeyNames="CourseID" OnRowCommand="GridViewCourses_RowCommand">

        <Columns>
            <asp:BoundField DataField="CourseID" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Rating" HeaderText="Rating" />
            <asp:BoundField DataField="ReviewsCount" HeaderText="Reviews" />

            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <img src='<%# ResolveUrl("~/uploads/") + Eval("ImageUrl") %>' width="50" height="50" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit"
                        CommandName="EditCourse" CommandArgument='<%# Eval("CourseID") %>' CssClass="btn btn-warning btn-sm" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete"
                        CommandName="DeleteCourse" CommandArgument='<%# Eval("CourseID") %>' CssClass="btn btn-danger btn-sm" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
