using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Marks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Select Registers.Course from Registers where Registers.StudentID =@stud";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                    conn.Open();
                    ddlCourses.DataSource = cmdSQL.ExecuteReader();
                    ddlCourses.DataBind();
                }
            }

            

        }
    }

    protected void SubmitCourse(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = "Select MARKS.Assignments_Marks, MARKS.Sessional_Marks, MARKS.Quizes_Marks, MARKS.Finals_Marks from MARKS where MARKS.StudentID = @stud and MARKS.Course = @course;";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                conn.Open();
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = ddlCourses.SelectedItem.Value;
                cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                gvMarks.DataSource = cmdSQL.ExecuteReader();
                gvMarks.DataBind();
            }
        }
    }


    protected void btnHome_Click(object sender, EventArgs e)
    {

    }

     protected void btnAttendance_Click1(object sender, EventArgs e)
     {
          Response.Redirect("Attendance.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void btnMarks_Click1(object sender, EventArgs e)
     {
          Response.Redirect("Marks.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void btnTranscript_Click1(object sender, EventArgs e)
     {
          Response.Redirect("Transcript.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void btnFeedback_Click1(object sender, EventArgs e)
     {
          Response.Redirect("Feedback.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

    protected void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}