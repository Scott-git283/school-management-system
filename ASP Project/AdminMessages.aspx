<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminMessages.aspx.cs" Inherits="ASP_Project.AdminMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Contact Messages</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        OnRowDeleting="GridView1_RowDeleting" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging"
        CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Subject" HeaderText="Subject" />
            <asp:BoundField DataField="Message" HeaderText="Message" />
            <asp:BoundField DataField="CreatedAt" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
