using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

public partial class FacultyAttendance : System.Web.UI.Page
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

    protected void ShowStudentsBtn_Click(object sender, EventArgs e)
    {
        //Select Registers.StudentID from Registers where Registers.Course = '' and Registers.Section = ''

        if(TextBox1.Text=="")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter Date" + "');", true);
            return;
        }

        

        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = "Select Registers.StudentID from Registers where Registers.Course = @course and Registers.Section = @sec";
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

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in GridView1.Rows)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Select * from Attendance where Attendance.Username = @stud and Attendance.CourseID = @course and Attendance.SecName =@sec and Attendance.ADate = @date";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                    cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = gr.Cells[0].Text;
                    cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                    cmdSQL.Parameters.Add("@date", SqlDbType.NVarChar).Value = TextBox1.Text;
                    conn.Open();
                    if (cmdSQL.ExecuteReader().HasRows)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Attendance Already Added " + gr.Cells[1].Text+ "');", true);
                        break;
                    }
                }
            }

            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Insert Into Attendance Values (@stud, @course, @sec, @date,@att);";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                    cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = gr.Cells[0].Text;
                    cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                    cmdSQL.Parameters.Add("@date", SqlDbType.NVarChar).Value = TextBox1.Text;

                    DropDownList ddl = (DropDownList)gr.FindControl("AttendanceList");
                    string selectedvalue = ddl.SelectedValue;
                    string att;
                    if (selectedvalue =="Present")
                    {
                        att = "P";
                    }
                    else 
                    {
                        att = "A";
                    }


                    cmdSQL.Parameters.Add("@att", SqlDbType.NVarChar).Value = att;

                    conn.Open();
                    if (cmdSQL.ExecuteNonQuery() != 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Attendance Added" + "');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Attendance Not Added" + "');", true);
                    }
                }
            }
        }

    }
}