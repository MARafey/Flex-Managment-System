using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

public partial class ManageInstructorsSections : System.Web.UI.Page
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
                    //cmdSQL.Parameters.Add("@City", SqlDbType.NVarChar).Value = testcity;
                    conn.Open();
                    DropDownList1.DataSource = cmdSQL.ExecuteReader();
                    DropDownList1.DataBind();
                }
            }



            string result = DropDownList1.SelectedItem.Value;

            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Select Section.Sec_Name from Section inner join Course on Section.Course = Course.CourseID where Course = @course";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = result;
                    conn.Open();
                    DropDownList2.DataSource = cmdSQL.ExecuteReader();
                    DropDownList2.DataBind();
                }
            }

            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Select CONCAT(Users.Username, '  ' , Users.Name1) as inst from Users where Users.Role1 = 2;";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    conn.Open();
                    DropDownList3.DataSource = cmdSQL.ExecuteReader();
                    DropDownList3.DataBind();
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

        string teacherString = DropDownList3.SelectedItem.Value;
        string courseString = DropDownList1.SelectedItem.Value;
        string sectionString = DropDownList2.SelectedItem.Value;

        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = "Update Section Set Section.Instructor = (Select Users.Username from Users where Users.Role1 = 2 and CONCAT(Users.Username, '  ' , Users.Name1)  = @teacher) where Section.Course = @course and Section.Sec_Name = @sec";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionString;
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseString;
                cmdSQL.Parameters.Add("@teacher", SqlDbType.NVarChar).Value = teacherString;

                //check count of sections a teacher is teaching
                string strSql1 = " Select COUNT(*) as Secs from Section where Section.Instructor = (Select Users.Username from Users where Users.Role1 = 2 and CONCAT(Users.Username, '  ' , Users.Name1)  = @teacher)";
                SqlCommand cmdSQL1 = new SqlCommand(strSql1, conn);
                cmdSQL1.Parameters.Add("@teacher", SqlDbType.NVarChar).Value = teacherString;
                conn.Open();

                string res = cmdSQL1.ExecuteScalar().ToString();
                int result= Convert.ToInt32(res);

                if (result >= 3)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Update Unsucessful because instructor has 3 sections" + "');", true);
                    return;
                }

                
                cmdSQL.Dispose();


                if (cmdSQL.ExecuteNonQuery() == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Update Unsucessful" + "');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Update Sucessful" + "');", true);
                }
     
            }

        }

    }



    
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string result = DropDownList1.SelectedItem.Value;

        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = "Select Section.Sec_Name from Section inner join Course on Section.Course = Course.CourseID where Course = @course";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = result;
                conn.Open();
                DropDownList2.DataSource = cmdSQL.ExecuteReader();
                DropDownList2.DataBind();
            }
        }


        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = "Select CONCAT(Users.Username, '  ' , Users.Name1) as inst from Users where Users.Role1 = 2;";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                conn.Open();
                DropDownList3.DataSource = cmdSQL.ExecuteReader();
                DropDownList3.DataBind();
            }
        }

    }
}