using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GradeReport : Page
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

     protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
     {
          // Add your logic for handling the selected index change event of DropDownList1 here
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

     protected void btnGenerateReport_Click(object sender, EventArgs e)
     {
          if (DropDownList1.SelectedItem.Value == "Attendance")
          {
               using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
               {
                    string strSql = "Select Username as 'StudentID', ADate as 'Date' from Attendance where Attendance.CourseID = @course and Attendance.SecName = @sec";
                    using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                    {
                         cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                         cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                         conn.Open();
                         GridView1.DataSource = cmdSQL.ExecuteReader();
                         GridView1.DataBind();
                    }
               }
          }

          if (DropDownList1.SelectedItem.Value == "Evaluation")
          {
               using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
               {
                    string strSql = "Select MARKS.StudentID, MARKS.Assignments_Marks, MARKS.Sessional_Marks, MARKS.Quizes_Marks, MARKS.Finals_Marks from MARKS where MARKS.Course = @course and MARKS.Sec_Name =@sec";
                    using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                    {
                         cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                         cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                         conn.Open();
                         GridView1.DataSource = cmdSQL.ExecuteReader();
                         GridView1.DataBind();
                    }
               }
          }

          if (DropDownList1.SelectedItem.Value == "Grade")
          {
               using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
               {
                    string strSql = "Select MARKS.StudentID, (MARKS.Assignments_Marks + MARKS.Sessional_Marks + MARKS.Quizes_Marks + MARKS.Finals_Marks) as 'Marks' Into #temp_table from MARKS where MARKS.Course = @course and MARKS.Sec_Name = @sec SELECT StudentID, Marks,  CASE   WHEN marks >= 90 THEN 'A+'  WHEN marks >= 86 AND marks <= 89 THEN 'A'  WHEN marks >= 82 AND marks <= 85 THEN 'A-'   WHEN marks >= 78 AND marks <= 81 THEN 'B+'  WHEN marks >= 74 AND marks <= 77 THEN 'B'   WHEN marks >= 70 AND marks <= 73 THEN 'B-'   WHEN marks >= 66 AND marks <= 69 THEN 'C+'    WHEN marks >= 62 AND marks <= 65 THEN 'C'  WHEN marks >= 58 AND marks <= 61 THEN 'C-'   WHEN marks >= 54 AND marks <= 57 THEN 'D+'    WHEN marks >= 50 AND marks <= 53 THEN 'D'  ELSE 'F'  END AS grade FROM #temp_table; drop table #temp_table;";
                    using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                    {
                         cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                         cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                         conn.Open();
                         GridView1.DataSource = cmdSQL.ExecuteReader();
                         GridView1.DataBind();
                    }
               }
          }

          if (DropDownList1.SelectedItem.Value == "Count")
          {
               using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
               {
                    string strSql = "Select MARKS.StudentID, (MARKS.Assignments_Marks + MARKS.Sessional_Marks + MARKS.Quizes_Marks + MARKS.Finals_Marks) as 'Marks' Into #temp_table from MARKS where MARKS.Course = @course and MARKS.Sec_Name = @sec SELECT   CASE   WHEN marks >= 90 THEN 'A+'   WHEN marks >= 86 AND marks <= 89 THEN 'A'  WHEN marks >= 82 AND marks <= 85 THEN 'A-'   WHEN marks >= 78 AND marks <= 81 THEN 'B+'    WHEN marks >= 74 AND marks <= 77 THEN 'B'   WHEN marks >= 70 AND marks <= 73 THEN 'B-'    WHEN marks >= 66 AND marks <= 69 THEN 'C+'   WHEN marks >= 62 AND marks <= 65 THEN 'C'    WHEN marks >= 58 AND marks <= 61 THEN 'C-'   WHEN marks >= 54 AND marks <= 57 THEN 'D+'   WHEN marks >= 50 AND marks <= 53 THEN 'D'   ELSE 'F' END AS grade Into #temp_table2 FROM #temp_table; drop table #temp_table; Select #temp_table2.grade, COUNT(grade) as 'Count' from #temp_table2 group by grade drop table #temp_table2;";
                    using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                    {
                         cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                         cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                         conn.Open();
                         GridView1.DataSource = cmdSQL.ExecuteReader();
                         GridView1.DataBind();
                    }
               }
          }


     }

     protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
     {
          // Add your logic for handling the selected index change event of GridView1 here
     }

     protected void HomeBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Faculty Main.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void AttendanceMarksBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Attendance.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void EvaluationBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Marks.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void MarksDistributionBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Distribution.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void GradeReportBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Reports.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
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