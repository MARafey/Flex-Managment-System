using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;

public partial class FeedbackFromStudents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Select DISTINCT Section.Course from Section where Section.Instructor = @instr";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    cmdSQL.Parameters.Add("@instr", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                    conn.Open();
                    courseDropdown.DataSource = cmdSQL.ExecuteReader();
                    courseDropdown.DataBind();
                }
            }



            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Select Section.Sec_Name from Section where Section.Instructor = @instr AND Section.Course=@course";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                    cmdSQL.Parameters.Add("@instr", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                    conn.Open();
                    sectionDropdown.DataSource = cmdSQL.ExecuteReader();
                    sectionDropdown.DataBind();
                }
            }
        }

    }

     protected void AttendenceMarksBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Attendance.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void MarksDistributionBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Distribution.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void GradeReportBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Reports.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void CountGradeReportBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Grade Count.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void FeedbackStudentsBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Feedback.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void EvaluationBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Marks.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void HomeBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Faculty Main.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void CountOfGradeReportBtn_Click(object sender, EventArgs e)
    {

    }

    protected void FeedbackFromStudentsBtn_Click(object sender, EventArgs e)
    {
          Response.Redirect("Feedback.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }
     protected void AttendanceMarksBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Attendance.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

    protected void GetFeedbackBtn_Click(object sender, EventArgs e)
    {


        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = "Select SUM(Feedback.Percentage_F) / COUNT(*) as 'Feedback Percentage' from Feedback where Feedback.Course = @course and Feedback.Section = @sec and Feedback.FacultyID = @instr";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@instr", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
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
            string strSql = "Select Feedback.Comment from Feedback where Feedback.Course = @course and Feedback.Section = @sec and Feedback.FacultyID = @instr";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@instr", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                conn.Open();
                GridView1.DataSource = cmdSQL.ExecuteReader();
                GridView1.DataBind();

            }
        }
    }
    protected void courseDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = "Select Section.Sec_Name from Section where Section.Instructor = @instr AND Section.Course=@course";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                cmdSQL.Parameters.Add("@instr", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                conn.Open();
                sectionDropdown.DataSource = cmdSQL.ExecuteReader();
                sectionDropdown.DataBind();
            }
        }
    }
    
    protected void sectionDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {




    }
}