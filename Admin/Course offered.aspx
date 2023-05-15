
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Course offered.aspx.cs" Inherits="OfferCourses" %>

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
    background: none;
    border: none;
    font-size: 18px;
    color: #0077b6;
    cursor: pointer;
    text-decoration: none;
    font-weight: bold;
    padding: 0;
    margin: 0;
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
            <h2>Offer Courses Registration</h2>
            <p>Here you can offer courses and allow students to register for them.</p>
           <div> 
            <asp:Label ID="CourseNameLbl" runat="server" AssociatedControlID="CourseNameTxt" Text="Course ID:" />
            <asp:TextBox ID="CourseNameTxt" runat="server" />
        <asp:Label ID="Label1" runat="server" Text="Course Title: "></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="CourseTitle" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="Label2" runat="server" Text="Pre Requisite Course ID: "></asp:Label>
        <asp:TextBox ID="PreReq" runat="server"></asp:TextBox>
               <br />
               <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label3" runat="server" Text="Credit Hours: "></asp:Label>
        <asp:DropDownList ID="CreditHrs" runat="server">
            <asp:ListItem Text= "1" Value="1"></asp:ListItem>
            <asp:ListItem Text= "2" Value="2"></asp:ListItem>
            <asp:ListItem Text= "3" Value="3"></asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:Label ID="Label4" runat="server" Text="Course Type"></asp:Label>
        <asp:DropDownList ID="CType" runat="server">
            <asp:ListItem Text= "Core" Value="Core"></asp:ListItem>
            <asp:ListItem Text= "Elective" Value="Elective"></asp:ListItem>
        </asp:DropDownList>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Label ID="Label5" runat="server" Text="Coordinator: "></asp:Label>
        <asp:TextBox ID="Coordinator" runat="server"></asp:TextBox>
        <br />
        <br />
        <br /><br />
            </div>
            <asp:Button class="button" ID="SubmitBtn" runat="server" Text="Offer Course" OnClick="SubmitBtn_Click" />
        </main>
    </form>
    
    <footer>
        <p>&copy; 2023 Course Management System</p>
    </footer>
</body>
</html>
