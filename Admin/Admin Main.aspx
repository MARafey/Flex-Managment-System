<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin Main.aspx.cs" Inherits="Admin_Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            margin-top: 0;
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
     width: 80%;
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
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Admin Management System</h1>
        </header>

        <nav>
            <ul>
                <li><asp:Button ID="CourseRegistrationBtn" runat="server" Text="Offer Courses Registration" OnClick="CourseRegistrationBtn_Click" CssClass="nav-button" /></li>
                <li>
                    <asp:Button ID="InstructorSectionBtn" runat="server" Text="Manage Instructors' Sections" OnClick="InstructorSectionBtn_Click" CssClass="nav-button" />
                </li>
                <li>
                    <asp:Button ID="GenerateReportsBtn" runat="server" Text="Generate Reports" OnClick="GenerateReportsBtn_Click" CssClass="nav-button" />
                </li>
                <li>
                    <asp:Button ID="CourseAllocationBtn" runat="server" Text="Course Allocation" OnClick="CourseAllocationBtn_Click" CssClass="nav-button" />
                </li>
         
            </ul>
        </nav>

        <section>
            <h2>Welcome to the Course Management System</h2>
            <p>Please select one of the options above to get started.</p>
            <button class="button" onclick="showMessage('SIUUUUUUUU')">Learn More</button>
        </section>
    </form>

    <script>
        function showMessage(message) {
            alert(message);
        }
    </script>

</body>
</html>
