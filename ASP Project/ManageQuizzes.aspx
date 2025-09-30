<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageQuizzes.aspx.cs" Inherits="ASP_Project.ManageQuizzes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .quiz-form {
            background: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 2px 5px rgba(0,0,0,0.1);
            max-width: 700px;
            margin-bottom: 20px;
        }
        .quiz-form h3 { margin-bottom: 15px; }
        .quiz-form .form-control { margin-bottom: 10px; width: 100%; padding: 8px; }
        .btn { padding: 8px 16px; margin-right: 5px; border: none; cursor: pointer; border-radius: 5px; }
        .btn-primary { background: #007bff; color: #fff; }
        .btn-warning { background: #ffc107; color: #000; }
        .btn-danger { background: #dc3545; color: #fff; }
        .grid { margin-top: 20px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="quiz-form">
        <h3>➕ Add / Update Quiz Question</h3>

        <asp:DropDownList ID="ddlCourses" runat="server" CssClass="form-control"></asp:DropDownList>
        <asp:TextBox ID="txtQuestion" runat="server" CssClass="form-control" placeholder="Enter Question"></asp:TextBox>
        <asp:TextBox ID="txtOptionA" runat="server" CssClass="form-control" placeholder="Option A"></asp:TextBox>
        <asp:TextBox ID="txtOptionB" runat="server" CssClass="form-control" placeholder="Option B"></asp:TextBox>
        <asp:TextBox ID="txtOptionC" runat="server" CssClass="form-control" placeholder="Option C"></asp:TextBox>
        <asp:TextBox ID="txtOptionD" runat="server" CssClass="form-control" placeholder="Option D"></asp:TextBox>

        <asp:DropDownList ID="ddlCorrect" runat="server" CssClass="form-control">
            <asp:ListItem Value="A">A</asp:ListItem>
            <asp:ListItem Value="B">B</asp:ListItem>
            <asp:ListItem Value="C">C</asp:ListItem>
            <asp:ListItem Value="D">D</asp:ListItem>
        </asp:DropDownList>

        <asp:HiddenField ID="hfQuestionID" runat="server" />

        <asp:Button ID="btnAdd" runat="server" Text="Add Question" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update Question" CssClass="btn btn-warning" Visible="false" OnClick="btnUpdate_Click" />
    </div>

    <div class="grid">
        <asp:GridView ID="gvQuestions" runat="server" AutoGenerateColumns="False" CssClass="table"
            OnRowCommand="gvQuestions_RowCommand">
            <Columns>
                <asp:BoundField DataField="QuestionID" HeaderText="ID" />
                <asp:BoundField DataField="CourseTitle" HeaderText="Course" />
                <asp:BoundField DataField="QuestionText" HeaderText="Question" />
                <asp:BoundField DataField="OptionA" HeaderText="A" />
                <asp:BoundField DataField="OptionB" HeaderText="B" />
                <asp:BoundField DataField="OptionC" HeaderText="C" />
                <asp:BoundField DataField="OptionD" HeaderText="D" />
                <asp:BoundField DataField="CorrectOption" HeaderText="Correct" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" CommandName="EditRow" CommandArgument='<%# Eval("QuestionID") %>' Text="✏️ Edit" CssClass="btn btn-warning" />
                        <asp:Button runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("QuestionID") %>' Text="🗑️ Delete" CssClass="btn btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
