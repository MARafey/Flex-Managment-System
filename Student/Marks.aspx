<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Marks.aspx.cs" Inherits="Student_Marks" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>Student Marks</title>
    <style>
        /* set some basic styles for the page */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }

        /* style the header */
        header {
            background-color: #00539C;
            color: white;
            padding: 20px;
        }

        header h1 {
            margin: 0;
        }

        /* style the navigation */
        nav {
            background-color: #F2F2F2;
            padding: 10px;
        }

        nav ul {
            list-style: none;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
        }

        nav li {
            margin: 0 10px;
        }

        .nav-button {
            color: #333;
            text-decoration: none;
            padding: 10px;
            border-radius: 5px;
            background-color: white;
            border: none;
            cursor: pointer;
            font-size: 16px;
        }

        .nav-button:hover {
            background-color: #00539C;
            color: white;
        }

        /* style the marks table */
        table {
            width: 80%;
            margin: 50px auto;
            border-collapse: collapse;
        }

        th, td {
            border: 1px solid #ccc;
            padding: 10px;
            text-align: left;
        }

        th {
            background-color: #F2F2F2;
        }

        tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        /* style the course selection */
        .course-selection {
            display: flex;
            justify-content: center;
            margin-top: 30px;
        }

        .course-dropdown, .submit-button {
            margin-right: 10px;
            margin-top: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Student Marks</h1>
        </header>

        <nav>
            <ul>
                <li><asp:Button ID="btnHome" runat="server" Text="Home" CssClass="nav-button" OnClick="btnHome_Click" /></li>
                <li><asp:Button ID="btnAttendance" runat="server" Text="Attendance" CssClass="nav-button" OnClick="btnAttendance_Click1" /></li>
                <li><asp:Button ID="btnMarks" runat="server" Text="Marks" CssClass="nav-button" OnClick="btnMarks_Click1" /></li>
                <li><asp:Button ID="btnTranscript" runat="server" Text="Transcript" CssClass="nav-button" OnClick="btnTranscript_Click1" /></li>
                <li><asp:Button ID="btnFeedback" runat="server" Text="Feedback" CssClass="nav-button" OnClick="btnFeedback_Click1" /></li>
            </ul>
        </nav>

        <div class="course-selection">
            Course:&nbsp;&nbsp;
            <asp:DropDownList ID="ddlCourses" runat="server" CssClass="course-dropdown" AutoPostBack="True" DataValueField="Course" OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged">
                
        </asp:DropDownList>
            <br />
        </div>
        &nbsp;
        <div class="course-selection">
        <asp:Button ID="btnSubmitCourse" runat="server" Text="Submit" CssClass="nav-button" OnClick="SubmitCourse" Height="45px" />
            <br />
            <br />
            <br />
         </div>

            <asp:GridView ID="gvMarks" runat="server">
            </asp:GridView>
    

</form>
