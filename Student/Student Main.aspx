<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student Main.aspx.cs" Inherits="Student_Student_Main" %>
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

        /* style the welcome message */
        h2 {
            margin-top: 50px;
            text-align: center;
        }

        p {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Student Main</h1>
        </header>

        <nav>
            <ul>
                <li><asp:Button ID="btnHome" runat="server" Text="Home" CssClass="nav-button" OnClick="btnHome_Click" /></li>
                <li><asp:Button ID="btnAttendance" runat="server" Text="Attendance" CssClass="nav-button" OnClick="btnAttendance_Click" /></li>
                <li><asp:Button ID="btnMarks" runat="server" Text="Marks" CssClass="nav-button" OnClick="btnMarks_Click" /></li>
                <li><asp:Button ID="btnTranscript" runat="server" Text="Transcript" CssClass="nav-button" OnClick="btnTranscript_Click" /></li>
                <li><asp:Button ID="btnFeedback" runat="server" Text="Feedback" CssClass="nav-button" OnClick="btnFeedback_Click" /></li>
            </ul>
        </nav>

    <h2>Welcome to the Flex Management System <asp:Label ID="Label1" runat="server" ></asp:Label>
        </h2>
    <p>Please select one of the options above to get started.</p>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <asp:GridView ID="GridView1" runat="server" Height="164px" Width="1843px">
            <HeaderStyle BackColor="#00539C" ForeColor="#F4F4F4" />
            <RowStyle BackColor="#A4E1FF" BorderColor="#D5FFFF" HorizontalAlign="Center" />
        </asp:GridView>
    </form>

    </body>
</html>