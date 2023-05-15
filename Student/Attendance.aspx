<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Attendance.aspx.cs" Inherits="Student_Attendance" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>Student Attendance</title>
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

        /* style the attendance table */
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
            margin: 0 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Student Attendance</h1>
        </header>

        <nav>
            <ul>
                <li><asp:Button ID="btnHome" runat="server" Text="Home" CssClass="nav-button" OnClick="btnHome_Click" /></li>
                <li><asp:Button ID="btnAttendance" runat="server" Text="Attendance" CssClass="nav-button" OnClick="btnAttendance_Click1" /></li>
                <li><asp:Button ID="btnMarks" runat="server" Text="Marks" CssClass="nav-button" OnClick="btnMarks_Click1" /></li>
                <li><asp:Button ID="btnTranscript" runat="server" Text="Transcript" CssClass="nav-button" OnClick="btnTranscript_Click" /></li>
                <li><asp:Button ID="btnFeedback" runat="server" Text="Feedback" CssClass="nav-button" OnClick="btnFeedback_Click1" /></li>
            </ul>
        </nav>

        <div class="course-selection">
            Course:<asp:DropDownList ID="ddlCourses" runat="server" CssClass="course-dropdown" AutoPostBack="True" DataValueField="Course" OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged">
                <asp:ListItem Text="Select Course" Value="0" />
                
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSubmitCourse" runat="server" Text="Submit" CssClass="submit-button" OnClick="SubmitCourse" />
    </div>

        <asp:GridView ID="gvAttendance" runat="server">
        </asp:GridView>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Chart ID="Chart1" runat="server" Width="745px">
            <Series>
                <asp:Series Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <br />
</form>

