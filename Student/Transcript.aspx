<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Transcript.aspx.cs" Inherits="Student_Transcript" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>Student Transcript</title>
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

         h2 {
            text-align: center;
            color: #1a237e;
        }
         .cgpa {
            text-align: center;
            color: #1a237e;
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
            margin-right: 10px;
            margin-top: 0;
            margin-bottom: 0;
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

        /* style the transcript table */
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Student Transcript</h1>
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
            <h2>Transcript</h2>
        <asp:GridView ID="gvTranscript" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Course" HeaderText="Course" />
                <asp:BoundField DataField="CreditHrs" HeaderText="CreditHrs" />
                <asp:BoundField DataField="Grade" HeaderText="Grade" />
                <asp:BoundField DataField="GPA" HeaderText="GPA" />


            </Columns>
        </asp:GridView>
        <p>
            <asp:Label ID="Label1" Text= "CGPA" CssClass="cgpa" runat="server"></asp:Label>:<asp:Label ID="lblCGPA" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
