using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Course_Closing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Select Course.CourseID from Course";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    conn.Open();
                    DropDownList1.DataSource = cmdSQL.ExecuteReader();
                    DropDownList1.DataBind();
                }
            }
        }
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

    protected void ViewRegisteredStudentsBtn_Click(object sender, EventArgs e)
    {

        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = "Select* from Registers where Registers.Course = @course";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = DropDownList1.SelectedItem.Value;
                conn.Open();
                GridView1.DataSource = cmdSQL.ExecuteReader();
                GridView1.DataBind();
            }
        }
    }

    protected void CloseCourseRegistrationBtn_Click(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}