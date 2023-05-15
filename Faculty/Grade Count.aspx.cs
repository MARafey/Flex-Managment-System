using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GradeCount : Page
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
          // Add your logic for handling the selected index change event of sectionDropdown here
     }
     protected void GetGradeReportBtn_Click(object sender, EventArgs e)
     {
          using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
          {
               string strSql = "Select MARKS.StudentID, (MARKS.Assignments_Marks + MARKS.Sessional_Marks + MARKS.Quizes_Marks + MARKS.Finals_Marks) as 'Marks' Into #temp_table from MARKS where MARKS.Course = @course and MARKS.Sec_Name = @sec SELECT StudentID,  CASE  WHEN marks >= 90 THEN 'A+'    WHEN marks >= 86 AND marks <= 89 THEN 'A'   WHEN marks >= 82 AND marks <= 85 THEN 'A-'    WHEN marks >= 78 AND marks <= 81 THEN 'B+'  WHEN marks >= 74 AND marks <= 77 THEN 'B'   WHEN marks >= 70 AND marks <= 73 THEN 'B-'    WHEN marks >= 66 AND marks <= 69 THEN 'C+'    WHEN marks >= 62 AND marks <= 65 THEN 'C'    WHEN marks >= 58 AND marks <= 61 THEN 'C-'   WHEN marks >= 54 AND marks <= 57 THEN 'D+'   WHEN marks >= 50 AND marks <= 53 THEN 'D'    ELSE 'F'  END AS grade FROM #temp_table; drop table #temp_table;";
               using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
               {
                    cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                    cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                    conn.Open();
                    GridView1.DataSource = cmdSQL.ExecuteReader();
                    GridView1.DataBind();
               }
          }

          foreach (GridViewRow gr in GridView1.Rows)
          {
               using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
               {
                    string strSql = "Select* from Record where Record.Student_Name = @stud and Record.Course = @course and Record.Grade = @grade";

                    using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                    {
                         cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                         cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = gr.Cells[0].Text;
                         cmdSQL.Parameters.Add("@grade", SqlDbType.NVarChar).Value = gr.Cells[1].Text;

                         conn.Open();
                         if (cmdSQL.ExecuteReader().HasRows)
                         {
                              ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Grade Already Added for " + gr.Cells[0].Text + "');", true);
                              break;
                         }
                    }
               }

               using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
               {
                    string strSql = "Insert Into Record Values (@stud, @course, @grade)";
                    using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                    {
                         cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = gr.Cells[0].Text;
                         cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                         cmdSQL.Parameters.Add("@grade", SqlDbType.NVarChar).Value = gr.Cells[1].Text;
                         conn.Open();
                         if (cmdSQL.ExecuteNonQuery() == 0)
                         {
                              ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Error Adding " + "');", true);
                         }
                    }
               }
          }
          ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Grade Succesfully Added " + "');", true);

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
     protected void AttendanceMarksBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Attendance.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }
     protected void CountOfGradeReportBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Grade Count.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }
     protected void FeedbackFromStudentsBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Feedback.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }
}