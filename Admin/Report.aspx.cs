using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GenerateReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

     protected void GenerateReportsBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Report.aspx");
     }

     protected void CourseAllocationBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Course Allocation.aspx");
     }

     protected void InstructorSectionBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Instruction Section.aspx");
     }

     protected void ManageInstructorsBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Instruction Section.aspx");
     }

     protected void CourseRegistrationBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Course offered.aspx");
     }
     protected void OfferCoursesBtn_Click(object sender, EventArgs e)
     {
          Response.Redirect("Course offered.aspx");
     }


     protected void ManageStudentsBtn_Click(object sender, EventArgs e)
    {

    }


    protected void GenerateReportBtn_Click(object sender, EventArgs e)
    {
        if(DropDownList1.SelectedItem.ToString() == "Offered Courses Report")
        {
            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Select Course.CourseID, Course.Title, Course.CreditHrs from Course";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    //cmdSQL.Parameters.Add("@City", SqlDbType.NVarChar).Value = testcity;
                    conn.Open();
                    GridView1.DataSource = cmdSQL.ExecuteReader();
                    GridView1.DataBind();
                }
            }
        }

        if (DropDownList1.SelectedItem.ToString() == "Student Section Report")
        {
          
            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Select Student.Username, Section.Course, Section.Sec_Name from Student inner join registers on Student.Username = Registers.StudentID inner join Section on Section.Course = Registers.Course and Section.Sec_Name = Registers.Section";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    //cmdSQL.Parameters.Add("@City", SqlDbType.NVarChar).Value = testcity;
                    conn.Open();
                    GridView1.DataSource = cmdSQL.ExecuteReader();
                    GridView1.DataBind();
                }
            }
        }

        if (DropDownList1.SelectedItem.ToString() == "Course Allocation Report")
        {
            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Select Course.CourseID, Course.Title, Course.CreditHrs, Section.Sec_Name, u2.Name1 AS Instructor, u1.Name1 AS Coordinator from Course inner join Section on Course.CourseID = Section.Course inner join Users as u1 on Course.Coordinator = u1.Username inner join Users as u2 on Section.Instructor = u2.Username group by Course.CourseID, Course.Title, Course.CreditHrs, Section.Sec_Name, u2.Name1, u1.Name1";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    //cmdSQL.Parameters.Add("@City", SqlDbType.NVarChar).Value = testcity;
                    conn.Open();
                    GridView1.DataSource = cmdSQL.ExecuteReader();
                    GridView1.DataBind();
                }
            }
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }



    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}