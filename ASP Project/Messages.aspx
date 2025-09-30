<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="ASP_Project.Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Messages</title>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <h2>📩 Contact Messages</h2>

    <asp:GridView ID="gvMessages" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
        DataKeyNames="Id" OnRowCommand="gvMessages_RowCommand" OnRowDeleting="gvMessages_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Subject" HeaderText="Subject" />

            <asp:TemplateField HeaderText="Message Preview">
                <ItemTemplate>
                    <%# (Eval("Message") != null && Eval("Message").ToString().Length > 50)
                        ? Eval("Message").ToString().Substring(0, 50) + "..."
                        : Eval("Message").ToString() %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="CreatedAt" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy HH:mm}" />

            <asp:TemplateField HeaderText="View">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkView" runat="server" CommandName="ViewMessage"
                        CommandArgument='<%# Eval("Id") %>' Text="👁 View"
                        CssClass="btn btn-sm btn-info" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Reply">
                <ItemTemplate>
                    <a class="btn btn-sm btn-warning"
                        href='<%# "mailto:" + Eval("Email") + "?subject=Re: " + Eval("Subject") %>'
                        target="_blank">✉ Reply</a>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="🗑 Delete" />
        </Columns>
    </asp:GridView>

    <!-- Bootstrap Modal -->
    <div class="modal fade" id="viewMessageModal" tabindex="-1" aria-labelledby="viewMessageLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="viewMessageLabel">Message Details</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p><strong>Name:</strong> <asp:Label ID="lblName" runat="server" /></p>
                    <p><strong>Email:</strong> <asp:Label ID="lblEmail" runat="server" /></p>
                    <p><strong>Subject:</strong> <asp:Label ID="lblSubject" runat="server" /></p>
                    <hr />
                    <p><strong>Message:</strong></p>
                    <p><asp:Label ID="lblFullMessage" runat="server" /></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Bootstrap JS Bundle -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
