<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login Form</title>
     <style>
         body {
     background: linear-gradient(to bottom, #0080ff, #87cefa);
     height: 100vh;
     display: flex;
     justify-content: center;
     align-items: center;
}

.container {
     width: 300px;
     background-color: #fff;
     border-radius: 10px;
     padding: 20px;
     box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.2);
     display: flex;
     flex-direction: column;
     align-items: center;
}

h1 {
     font-size: 2rem;
     margin-bottom: 20px;
}

input[type="text"],
input[type="password"],
input[type="submit"] {
     width: 100%;
     padding: 10px;
     margin: 5px 0;
     border: none;
     border-radius: 5px;
}

input[type="submit"] {
     background-color: linear-gradient(to bottom, #0077ff, #ffffff);
     color: #fff;
     cursor: pointer;
     transition: background-color 0.3s ease;
}

input[type="submit"] {
     background-color: blue;
     color: #fff;
     cursor: pointer;
     transition: background-color 0.3s ease;
}


.pulse {
     animation-name: pulse;
     animation-duration: 1s;
     animation-timing-function: ease-out;
     animation-iteration-count: infinite;
}

@keyframes pulse {
     0% {
          transform: scale(1);
     }

     50% {
          transform: scale(1.2);
     }

     100% {
          transform: scale(1);
     }
}

     </style>
</head>
<body style="height: 578px">
    <form id="form1" runat="server">
        <div class="container">
            <h1>FLEX LOGIN</h1>
            <label for="email">Username:</label>
            <asp:TextBox ID="email" runat="server" TextMode="SingleLine" OnTextChanged="email_TextChanged"></asp:TextBox>
            <label for="password">Password:</label>
            <asp:TextBox ID="password" runat="server" TextMode="Password" OnTextChanged="password_TextChanged"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
