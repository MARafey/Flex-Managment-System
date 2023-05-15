using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Student_Student_Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = "Select Users.Name1 from Users where Users.Username =@stud";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                conn.Open();
                SqlDataReader dr = cmdSQL.ExecuteReader();
                while (dr.Read())
                {
                    Label1.Text = dr.GetValue(0).ToString();
                } 
            }
        }

        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        { 
            string strSql = "Select Student.Email, Student.Degree, Student.DOB as 'Date Of Birth', Student.MobileNo, Student.Address1 as 'Address', Student.CNIC from Student where Student.Username =@stud";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                conn.Open();
                GridView1.DataSource = cmdSQL.ExecuteReader();
                GridView1.DataBind();
            }
        }
    }

    protected void btnHome_Click(object sender, EventArgs e)
    {

    }

     protected void btnAttendance_Click(object sender, EventArgs e)
     {
          Response.Redirect("Attendance.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void btnMarks_Click(object sender, EventArgs e)
     {
          Response.Redirect("Marks.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void btnTranscript_Click(object sender, EventArgs e)
     {
          Response.Redirect("Transcript.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void btnFeedback_Click(object sender, EventArgs e)
     {
          Response.Redirect("Feedback.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

}