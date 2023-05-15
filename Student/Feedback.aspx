<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Student_Feedback" %>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Teacher Assessment Form</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f4f8;
            color: #444;
        }

        h1 {
            text-align: center;
            color: #1a237e;
        }

        form {
            max-width: 800px;
            margin: 20px auto;
            background-color: #fff;
            padding: 20px;
            border: 1px solid #1a237e;
            border-radius: 8px;
        }

        label {
            display: block;
            margin-bottom: 5px;
        }

        input,
        textarea {
            margin-bottom: 20px;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .rating {
            display: inline-block;
            margin-right: 10px;
        }

        .rating label {
            margin-bottom: 0;
        }

        button {
            display: block;
            width: 150px;
            margin: 0 auto;
            padding: 10px;
            background-color: #1a237e;
            color: #fff;
            font-size: 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        .submit-button {
        display: block;
        width: 150px;
        margin: 0 auto;
        padding: 10px;
        background-color: #1a237e;
        color: #fff;
        font-size: 16px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

    .submit-button:hover {
        background-color: #303f9f;
    }
        button:hover {
            background-color: #303f9f;
        }
    </style>
</head>

<body>
    <h1>Teacher Assessment Form</h1>
    <form id="form1" runat="server">
        <label for="date">Date:<br />
        </label>

        <label for="teacherName">
        <asp:TextBox ID="Datebox" runat="server" TextMode="Date" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </label>
        &nbsp;

        <label for="teacherName">Course:<br />
        </label>
        &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" DataValueField="Course" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="117px">
        </asp:DropDownList>
        <br />

        <div>
            <h4>Teacher attends class in a well-presentable manner: </h4><br />
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <h6>Teacher shows enthusiasm when teaching in class : </h6><br>
            <asp:RadioButtonList ID="RadioButtonList3" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <h6>Teacher shows initiative and flexibility in teaching : </h6>
            <asp:RadioButtonList ID="RadioButtonList4" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
            <br>
        </div>

        <div>
            <h6>Teacher is well articulated and shows full knowledge of the subject in teaching : </h6>
            <asp:RadioButtonList ID="RadioButtonList5" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
            <br>
        </div>

        <div>
            <h7>Teacher shows professionalism in class : </h7><br>
            <asp:RadioButtonList ID="RadioButtonList6" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <h8>Teacher shows commitment to teaching the class : </h8><br>
            <asp:RadioButtonList ID="RadioButtonList7" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <h9>Teacher encourages students to engage in class discussions and ask questions : </h9><br>
            <asp:RadioButtonList ID="RadioButtonList8" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <h10>Teacher handles criticisms and suggestions professionally : </h10><br>
            <asp:RadioButtonList ID="RadioButtonList9" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <h10>Teacher ends class on time : </h10><br>
            <asp:RadioButtonList ID="RadioButtonList10" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <h11>Teacher comes to class on time : </h11><br>
            <asp:RadioButtonList ID="RadioButtonList11" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <h12>Teacher shows well rounded knowledge over the subject matter : </h12><br>
            <asp:RadioButtonList ID="RadioButtonList12" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <h12>Teacher has organized the lesson conducive for easy understanding of students : </h12><br>
            <asp:RadioButtonList ID="RadioButtonList13" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <h12>Teacher shows dynamism and enthusiasm : </h12><br>
            <asp:RadioButtonList ID="RadioButtonList14" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <h12>Teacher stimulates the critical thinking of students : </h12><br>
            <asp:RadioButtonList ID="RadioButtonList15" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <h12>Teacher handles the class environment conducive for learning : </h12><br>
            <asp:RadioButtonList ID="RadioButtonList16" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <h12>Teacher believes that students can learn from the class : </h12><br>
            <asp:RadioButtonList ID="RadioButtonList17" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <h12>Teacher shows equal respect to various cultural backgrounds, individuals, religion, and race : </h12>
            <br>
            <asp:RadioButtonList ID="RadioButtonList18" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
</div>

        <div>
            <h12>Teacher finds the students strengths as basis for growth and weaknesses for opportunities for
                improvement : </h12><br>
            <asp:RadioButtonList ID="RadioButtonList19" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <h12>Teacher understands the weakness of a student and helps in the student's improvement : </h12><br>
            <asp:RadioButtonList ID="RadioButtonList20" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Height="61px" RepeatDirection="Horizontal" Width="419px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        
        <div>
            <label for="comment">Add a comment about the teacher:<br />
                &nbsp;<asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TextBox5_TextChanged" Height="103px" Width="748px"></asp:TextBox>
            </label>
            <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" CssClass="submit-button" />

    
        </div>

    </form>
 
</body>

</html>
<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Student_Feedback" %>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Teacher Assessment Form</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f4f8;
            color: #444;
        }

        h1 {
            text-align: center;
            color: #1a237e;
        }

        form {
            max-width: 800px;
            margin: 20px auto;
            background-color: #fff;
            padding: 20px;
            border: 1px solid #1a237e;
            border-radius: 8px;
        }

        label {
            display: block;
            margin-bottom: 5px;
        }

        input,
        textarea {
            width: 100%;
            margin-bottom: 20px;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .rating {
            display: inline-block;
            margin-right: 10px;
        }

        .rating label {
            margin-bottom: 0;
        }

        button {
            display: block;
            width: 150px;
            margin: 0 auto;
            padding: 10px;
            background-color: #1a237e;
            color: #fff;
            font-size: 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        button:hover {
            background-color: #303f9f;
        }
    </style>
</head>

<body>
    <h1>Teacher Assessment Form</h1>
    <form id="form1" runat="server">
        <label for="date">Date:</label>
        <input type="date" id="date" name="date" required>

        <label for="teacherName">Teacher Name:</label>
        <input type="text" id="teacherName" name="teacherName" required>

        <label for="subject">Subject:</label>
        <input type="text" id="subject" name="subject" required>

        <label for="roomNumber">Room Number:</label>
        <input type="text" id="roomNumber" name="roomNumber" required>

        <label for="schoolYear">School Year:</label>
        <input type="text" id="schoolYear" name="schoolYear" required>

        <h3>Rate the teacher from 1-5:</h3>
        <p>1 - Poor, 2 - Fair, 3 - Good, 4 - Very Good, 5 - Excellent</p>
        <div>
            <span class="rating">
                <input type="radio" id="rating1" name="rating" value="1" required>
                <label for="rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="rating2" name="rating" value="2">
                <label for="rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="rating3" name="rating" value="3">
                <label for="rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="rating4" name="rating" value="4">
                <label for="rating4">
                    4</label>
            </span>
            <span class="rating">
                <input type="radio" id="rating5" name="rating" value="5">
                <label for="rating5">5</label>
            </span>
        </div>
        <div>
            <h4>Teacher attends class in a well-presentable manner:</h4><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>
        <div>
            <h5>Teacher shows enthusiasm when teaching in class : </h5><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>

        <div>
            <h6>Teacher shows initiative and flexibility in teaching : </h6><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>


        <div>
            <h6>Teacher is well articulated and shows full knowledge of the subject in teaching : </h6><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>

        <div>
            <h7>Teacher shows professionalism in class : </h7><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>

        <div>
            <h8>Teacher shows commitment to teaching the class : </h8><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>


        <div>
            <h9>Teacher encourages students to engage in class discussions and ask questions : </h9><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>

        <div>
            <h10>Teacher handles criticisms and suggestions professionally : </h10><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>

        <div>
            <h10>Teacher ends class on time : </h10><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>


        <div>
            <h11>Teacher comes to class on time : </h11><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>

        <div>
            <h12>Teacher shows well rounded knowledge over the subject matter : </h12><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>

        <div>
            <h12>Teacher has organized the lesson conducive for easy understanding of students : </h12><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>

        <div>
            <h12>Teacher shows dynamism and enthusiasm : </h12><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>

        <div>
            <h12>Teacher stimulates the critical thinking of students : </h12><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>

        <div>
            <h12>Teacher handles the class environment conducive for learning : </h12><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>

        <div>
            <h12>Teacher believes that students can learn from the class : </h12><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>

        <div>
            <h12>Teacher shows equal respect to various cultural backgrounds, individuals, religion, and race : </h12>
            <br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>

        <div>
            <h12>Teacher finds the students strengths as basis for growth and weaknesses for opportunities for
                improvement : </h12><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>


        <div>
            <h12>Teacher understands the weakness of a student and helps in the student's improvement : </h12><br>
            <span class="rating">
                <input type="radio" id="q1_rating1" name="q1_rating" value="1" required>
                <label for="q1_rating1">1</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating2" name="q1_rating" value="2">
                <label for="q1_rating2">2</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating3" name="q1_rating" value="3">
                <label for="q1_rating3">3</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating4" name="q1_rating" value="4">
                <label for="q1_rating4">4</label>
            </span>
            <span class="rating">
                <input type="radio" id="q1_rating5" name="q1_rating" value="5">
                <label for="q1_rating5">5</label>
            </span>
        </div>

        <label for="comment">Add a comment about the teacher:</label>

        <label for="comment">
        
        </label>
        
        <textarea id="comment" name="comment" rows="4" required></textarea>
        <asp:Button ID="Button1" runat="server" Text="Button" CssClass="nav-button" OnClick="Button1_Click1" />
        </form>
</body>

</html>--%>