<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuizResults.aspx.cs" Inherits="ASP_Project.QuizResults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Quiz Results</title>
    <style>
        .results-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

            .results-table th, .results-table td {
                border: 1px solid #ccc;
                padding: 10px;
                text-align: center;
            }

            .results-table th {
                background-color: #f4f4f4;
            }

        .excellent {
            color: green;
            font-weight: bold;
        }

        .good {
            color: blue;
            font-weight: bold;
        }

        .fair {
            color: orange;
            font-weight: bold;
        }

        .fail {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>📊 My Quiz Results</h2>
        <asp:GridView ID="gvResults" runat="server" AutoGenerateColumns="False"
            CssClass="results-table" OnRowDataBound="gvResults_RowDataBound"
            OnRowCommand="gvResults_RowCommand">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Course" />
                <asp:BoundField DataField="Score" HeaderText="Score" />
                <asp:BoundField DataField="TotalQuestions" HeaderText="Total Questions" />
                <asp:BoundField DataField="Percentage" HeaderText="Percentage" DataFormatString="{0:F2}%" />
                <asp:BoundField DataField="Grade" HeaderText="Grade" />
                <asp:BoundField DataField="AttemptDate" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy HH:mm}" />

                <!-- Retake Quiz button -->
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnRetake" runat="server" Text="Retake Quiz"
                            CommandName="Retake" CommandArgument='<%# Eval("CourseID") %>'
                            CssClass="btn-retake"
                            OnClientClick="return confirm('Are you sure you want to retake this quiz?');" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

    </form>
</body>
</html>
