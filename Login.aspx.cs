using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True");
        conn.Open();
        SqlCommand cm;
        string un = email.Text;
        string pass = password.Text;
        string query = "SELECT * FROM Users WHERE Username = '" + un + "' AND Passwd = '" + pass + "'";
        cm = new SqlCommand(query, conn);

        SqlDataReader res = cm.ExecuteReader();

        if (!res.HasRows)
        {
           ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No such username found or password is incorrect" + "');", true);

        }
        else
        {

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Successfully logged in!" + "');", true);

            if (un[2] == 'A')
                Response.Redirect("/NewFolder1/Admin Main.aspx");

            else if (un[2] == 'S')
                Response.Redirect("/Student/Student Main.aspx?Parameter=" + email.Text);

            else if (un[2] == 'T')
                Response.Redirect("/Faculty/Faculty Main.aspx?Parameter=" + email.Text);
        }

        Console.WriteLine("After method call, value of res : {0}", res);
        cm.Dispose();
        conn.Close();
        
    }

    protected void password_TextChanged(object sender, EventArgs e)
    {

    }

    protected void email_TextChanged(object sender, EventArgs e)
    {
       
    }
}