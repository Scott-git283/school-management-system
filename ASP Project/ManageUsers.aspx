<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="ASP_Project.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Manage Users</h2>

    <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" CssClass="table"
        OnRowCommand="GridViewUsers_RowCommand" OnSelectedIndexChanged="GridViewUsers_SelectedIndexChanged">

        <Columns>
            <asp:TemplateField HeaderText="Photo">
                <ItemTemplate>
                    <asp:Image ID="imgUser" runat="server" ImageUrl='<%# "~/uploads/" + Eval("Photo") %>'
                        Width="50px" Height="50px" CssClass="user-photo" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="UserID" HeaderText="User ID" />
            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Password" HeaderText="Password" />
            <asp:BoundField DataField="CreatedAt" HeaderText="Created At" DataFormatString="{0:yyyy-MM-dd}" />

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnView" runat="server" Text="View" CommandName="View"
                        CssClass="action-btn btn-view" CommandArgument='<%# Eval("UserID") %>' />
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit"
                        CssClass="action-btn btn-edit" CommandArgument='<%# Eval("UserID") %>' />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete"
                        CommandName="CustomDelete" CssClass="action-btn btn-delete"
                        CommandArgument='<%# Eval("UserID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


</asp:Content>
