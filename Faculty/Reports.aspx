<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="GradeReport" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
       border-style: none;
           border-color: inherit;
           border-width: medium;
           background-color: #0077b6;
           color: white;
           padding: 10px 20px;
           border-radius: 5px;
           font-size: 18px;
           cursor: pointer;
           width: 238px;
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

.button {
    background-color: #0077b6;
    color: white;
    padding: 10px 20px;
    border: none;
    border-radius: 5px;
    font-size: 18px;
    cursor: pointer;
}
.button-style {
       border-style: none;
           border-color: inherit;
           border-width: medium;
           background-color: #0077b6;
           color: white;
           padding: 10px 20px;
           border-radius: 5px;
           font-size: 18px;
           cursor: pointer;
           margin-bottom: 0px;
       }

.button-style:hover {
    background-color: #005691;
}

.button:hover {
    background-color: #005691;
}
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Faculty Mode</h1>
        </header>

        <nav>
            <ul>
                <li><asp:Button ID="HomeBtn" runat="server" Text="Home" CssClass="nav-button" OnClick="HomeBtn_Click" /></li>
                <li><asp:Button ID="AttendanceMarksBtn" runat="server" Text="Attendance Marks" CssClass="nav-button" OnClick="AttendanceMarksBtn_Click" /></li>
                <li><asp:Button ID="EvaluationBtn" runat="server" Text="Evaluation" CssClass="nav-button" OnClick="EvaluationBtn_Click" /></li>
                <li><asp:Button ID="MarksDistributionBtn" runat="server" Text="Marks Distribution" CssClass="nav-button" OnClick="MarksDistributionBtn_Click" /></li>
                <li><asp:Button ID="GradeReportBtn" runat="server" Text="Reports" CssClass="nav-button" OnClick="GradeReportBtn_Click" /></li>
                <li><asp:Button ID="CountOfGradeReportBtn" runat="server" Text="Generate Grade" CssClass="nav-button" OnClick="CountOfGradeReportBtn_Click" /></li>
                <li><asp:Button ID="FeedbackFromStudentsBtn" runat="server" Text="Feedback from Students" CssClass="nav-button" OnClick="FeedbackFromStudentsBtn_Click" /></li>
            </ul>
        </nav>

              <section style="text-align: center;">
                    <h2>Generate Report Page</h2>
                        Type:&nbsp;
                        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                           <asp:ListItem Value="Attendance">Attendance Report</asp:ListItem>
                                    <asp:ListItem Value="Evaluation">Evaluation Report</asp:ListItem>
                                    <asp:ListItem Value="Grade">Grade Report</asp:ListItem>
                                    <asp:ListItem Value="Count">Count of Grade Report</asp:ListItem>
                        </asp:DropDownList>
                    &nbsp;&nbsp; Course:&nbsp;
                <asp:DropDownList ID="courseDropdown" runat="server" OnSelectedIndexChanged="courseDropdown_SelectedIndexChanged" AutoPostBack="True" DataValueField="Course"></asp:DropDownList>
                &nbsp;&nbsp; Sec:<asp:DropDownList ID="sectionDropdown" runat="server" OnSelectedIndexChanged="sectionDropdown_SelectedIndexChanged" AutoPostBack="True" DataValueField="Sec_Name"></asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" Text="Generate Report" CssClass="button-style" OnClick="btnGenerateReport_Click" />
                    <div id="Div2" runat="server"></div>
                  <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
            </section>



            <div id="grade-report"></div>
        </section>
    </form>
</body>
</html>
