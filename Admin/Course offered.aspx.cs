using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OfferCourses : System.Web.UI.Page
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


    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        if(CourseNameTxt.Text == "" || CourseTitle.Text == "" || CreditHrs.SelectedItem.Value == "" || CType.SelectedItem.Value == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please fill all the fields" + "');", true);
            return;
        }

        if(CourseNameTxt.Text.Length!=6)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Course Name and Pre-Requisite must be of 6 characters" + "');", true);
            return;
        }

        if (CourseNameTxt.Text == PreReq.Text)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Course Name cannot be same" + "');", true);
            return;
        }

        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = "Select CourseID from Course where Course.CourseID =@course";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = CourseNameTxt.Text;
                conn.Open();

                SqlDataReader res = cmdSQL.ExecuteReader();

                if (res.HasRows)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Course already exists" + "');", true);
                    return;
                }
            }
        }

        if (PreReq.Text!="") {
            if(PreReq.Text.Length != 6)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Pre-Requisite must be of 6 characters" + "');", true);
                return;
            }
            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Select CourseID from Course where Course.CourseID =@course";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = PreReq.Text;
                    conn.Open();

                    SqlDataReader res = cmdSQL.ExecuteReader();

                    if (!res.HasRows)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Pre Requiste does not exists" + "');", true);
                        return;
                    }
                }
            } 
        }



        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = "Select Faculty.Username from Faculty where Faculty.Username = @username";
            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@username", SqlDbType.NVarChar).Value = Coordinator.Text;
                conn.Open();
                SqlDataReader res = cmdSQL.ExecuteReader();
                if (!res.HasRows)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Coordinator does not exist" + "');", true);
                    return;
                }
            }
        }


        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = "Insert Into Course Values ( @courseid, @coursetitle, @prereq, @credithrs, @ctype, @coordinator);";
            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@courseid", SqlDbType.NVarChar).Value = CourseNameTxt.Text;
                cmdSQL.Parameters.Add("@coursetitle", SqlDbType.NVarChar).Value = CourseTitle.Text;
                cmdSQL.Parameters.Add("@prereq", SqlDbType.NVarChar).Value = PreReq.Text;
                cmdSQL.Parameters.Add("@credithrs", SqlDbType.NVarChar).Value = CreditHrs.Text;
                cmdSQL.Parameters.Add("@ctype", SqlDbType.NVarChar).Value = CType.Text;
                cmdSQL.Parameters.Add("@coordinator", SqlDbType.NVarChar).Value = Coordinator.Text;
                conn.Open();

                if (cmdSQL.ExecuteNonQuery() == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Insertion Unsucessful" + "');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Insertion Sucessful" + "');", true);
                }
            }
        }

    }
}