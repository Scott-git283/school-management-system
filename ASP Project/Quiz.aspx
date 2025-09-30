<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="ASP_Project.Quiz" ValidateRequest="false" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Quiz</title>
    <style>
        body {
            font-family: Arial;
            background: #f8f8f8;
        }

        .quiz-container {
            width: 70%;
            margin: auto;
            margin-top: 30px;
        }

        .question-box {
            margin-bottom: 20px;
            padding: 15px;
            border: 1px solid #ccc;
            border-radius: 8px;
            background: #fff;
        }

            .question-box strong {
                display: block;
                margin-bottom: 5px;
            }

        .btn-submit {
            padding: 10px 20px;
            background: green;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .result {
            font-weight: bold;
            font-size: 18px;
            color: darkgreen;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="quiz-container" style="width: 700px; margin: 30px auto; font-family: Arial;">

            <!-- Course Selection -->
            <h2>Select a Course</h2>
            <asp:DropDownList ID="ddlCourses" runat="server" AutoPostBack="true"
                OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged" Width="300px">
            </asp:DropDownList>
            <hr />

            <!-- Title of the quiz -->
            <h3>Quiz for Course:
                <asp:Label ID="lblTitle" runat="server" />
            </h3>
            <br />

            <!-- Questions Repeater -->
            <asp:Repeater ID="rptQuestions" runat="server" OnItemDataBound="rptQuestions_ItemDataBound">
                <ItemTemplate>
                    <div class="question-box">
                        <strong>Q<%# Container.ItemIndex + 1 %>:</strong>
                        <%# Eval("QuestionText") %><br />

                        <asp:RadioButtonList ID="rblOptions" runat="server" RepeatDirection="Vertical"></asp:RadioButtonList>

                        <asp:HiddenField ID="hfCorrectAnswer" runat="server" Value='<%# Eval("CorrectOption") %>' />
                        <asp:HiddenField ID="hfOptionA" runat="server" Value='<%# Eval("OptionA") %>' />
                        <asp:HiddenField ID="hfOptionB" runat="server" Value='<%# Eval("OptionB") %>' />
                        <asp:HiddenField ID="hfOptionC" runat="server" Value='<%# Eval("OptionC") %>' />
                        <asp:HiddenField ID="hfOptionD" runat="server" Value='<%# Eval("OptionD") %>' />

                        <asp:Label ID="lblFeedback" runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


            <asp:Button ID="btnSubmitQuiz" runat="server" Text="Submit Quiz"
                CssClass="btn-submit" OnClick="btnSubmitQuiz_Click" />

            &nbsp;
            <asp:Button ID="btnRestart" runat="server" Text="Restart Quiz"
                CssClass="btn-restart" OnClick="btnRestart_Click" />
            <br />
            <br />

            <!-- Result -->
            <asp:Label ID="lblResult" runat="server" CssClass="result" ForeColor="Blue"></asp:Label>
        </div>
    </form>
</body>
</html>
