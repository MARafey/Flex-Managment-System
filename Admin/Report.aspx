<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="GenerateReports" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Admin Management System</title>
         <style>
        body {
     font-family: Arial, sans-serif;
     background-color: #f2f2f2;
     margin: 0;
     padding: 0;
}

header {
     background-color: #0077b6;
     color: white;
     padding: 20px;
}

h1 {
     margin: 0;
     font-size: 36px;
}

nav {
     background-color: white;
     border-bottom: 1px solid #0077b6;
     padding: 10px;
}

ul {
     list-style: none;
     margin: 0;
     padding: 0;
     display: flex;
}

li {
             margin-right: 10px;
                 margin-top: 0;
                 margin-bottom: 0;
             }

a {
     color: #0077b6;
     text-decoration: none;
     font-weight: bold;
     font-size: 18px;
}

section {
     background-color: white;
     padding: 20px;
     margin: 20px;
     box-shadow: 0 2px 6px rgba(0,0,0,0.3);
}

h2 {
     font-size: 24px;
     margin-top: 0;
}

p {
     font-size: 16px;
     line-height: 1.5;
}

.button {
     background-color: #0077b6;
     color: white;
     padding: 10px 20px;
     border: none;
     border-radius: 5px;
     font-size: 18px;
     cursor: pointer;
}

     .button:hover {
          background-color: #005691;
     }
     .nav-button {
             border-style: none;
                 border-color: inherit;
                 border-width: medium;
                 background: ;
                 font-size: 18px;
                 color: #0077b6;
                 cursor: pointer;
                 text-decoration: none;
                 font-weight: bold;
                 padding: 0;
                 margin-left: 0;
                 margin-right: 0;
                 margin-bottom: 0;
             }

.nav-button:hover {
    color: white;
    background-color: #0077b6;
    padding: 10px;
    border-radius: 5px;
}

nav ul li:hover a {
     color: white;
     background-color: #0077b6;
     padding: 10px;
     border-radius: 5px;
}

main {
     display: flex;
     flex-direction: column;
     align-items: center;
}

form {
     margin: 20px;
}

label, select {
     font-size: 1.2em;
     margin-right: 10px;
}

table {
     border-collapse: collapse;
     margin-top: 20px;
     }

th, td {
     padding: 10px;
     text-align: left;
}

th {
     background-color: #0077b6;
     color: white;
     font-weight: normal;
}

tr:nth-child(even) {
     background-color: #f2f2f2;
}

tr:hover {
     background-color: #ddd;
}

    </style>
    <script src="Admin_script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>ADMIN Management System</h1>
        </header>
        <nav>
            <ul>
               <li><asp:Button ID="OfferCoursesBtn" runat="server" Text="Offer Courses Registration" OnClick="OfferCoursesBtn_Click" CssClass="nav-button" /></li>
                <li>
                    <asp:Button ID="ManageInstructorsBtn" runat="server" Text="Manage Instructors' Sections" OnClick="ManageInstructorsBtn_Click" CssClass="nav-button" />
                </li>
                <li>
                    <asp:Button ID="GenerateReportsBtn" runat="server" Text="Generate Reports" OnClick="GenerateReportsBtn_Click" CssClass="nav-button" />
                </li>
                <li>
                    <asp:Button ID="CourseAllocationBtn" runat="server" Text="Course Allocation" OnClick="CourseAllocationBtn_Click" CssClass="nav-button" />
                </li>
            </ul>
        </nav>

        <main>
            <h2>Generate Reports</h2>
            <p>Here you can generate reports for the students who have registered for a specific course.</p>
&nbsp;<br />
            <label for="report-type">Select Report Type:</label>&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Text= "Offered Courses Report" Value="1"></asp:ListItem>
            <asp:ListItem Text= "Student Section Report" Value="2"></asp:ListItem>
            <asp:ListItem Text= "Course Allocation Report" Value="3"></asp:ListItem>
        </asp:DropDownList>
            <br />
            <br />
            <asp:Button CssClass="button" ID="GenerateReportBtn" runat="server" Text="Generate Report" OnClick="GenerateReportBtn_Click" />
            <br />
            <table id="report-table">
            </table>
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1355px">
        </asp:GridView>
        </main>
    </form>

    <footer>
        <p>&copy; 2023 Course Management System</p>
    </footer>
</body>
</html>
