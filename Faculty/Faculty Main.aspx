﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Faculty Main.aspx.cs" Inherits="Faculty_Faculty_Main" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Faculty Attendance</title>
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
    margin: 0 10px;
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

form label {
    font-size: 1.2em;
    margin-right: 10px;
}

form input[type="date"] {
    font-size: 1.2em;
    padding: 10px;
    border: none;
    border-radius: 5px;
    background-color: #0077b6;
    color: white;
    margin-right: 10px;
}

form button[type="submit"] {
    background-color: #0077b6;
    color: white;
    padding: 10px 20px;
    border: none;
    border-radius: 5px;
    font-size: 18px;
    cursor: pointer;
}

form button[type="submit"]:hover {
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
            <h1>Faculty Main</h1>
        </header>

        <nav>
            <ul>
                <li><asp:Button ID="HomeBtn" runat="server" Text="Home" OnClick="HomeBtn_Click" CssClass="nav-button" /></li>
                <li><asp:Button ID="AttendenceMarksBtn" runat="server" Text="Attendence Marks" OnClick="AttendenceMarksBtn_Click" CssClass="nav-button" /></li>
                <li><asp:Button ID="EvaluationBtn" runat="server" Text="Evaluation" OnClick="EvaluationBtn_Click" CssClass="nav-button" /></li>
                <li><asp:Button ID="MarksDistributionBtn" runat="server" Text="Marks Distribution" OnClick="MarksDistributionBtn_Click" CssClass="nav-button" /></li>
                <li><asp:Button ID="GradeReportBtn" runat="server" Text="Reports" OnClick="GradeReportBtn_Click" CssClass="nav-button" /></li>
                <li><asp:Button ID="CountGradeReportBtn" runat="server" Text="Generate Grade" OnClick="CountGradeReportBtn_Click" CssClass="nav-button" /></li>
                <li><asp:Button ID="FeedbackStudentsBtn" runat="server" Text="Feedback from Students" OnClick="FeedbackStudentsBtn_Click" CssClass="nav-button" /></li>
            </ul>
        </nav>

      
<section>
            <h2>Welcome to the Flex Management System</h2>
            <p>Please select one of the options above to get started.</p>
            <button onclick="showMessage('Welcome Respected Sir/Maam')">Learn More</button>
        </section>
    </form>

    <script>
        function showMessage(message) {
            alert(message);
        }
    </script>
</body>
</html>
