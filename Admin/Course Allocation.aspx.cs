using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

public partial class CourseAllocation : System.Web.UI.Page
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
                    CourseSelect.DataSource = cmdSQL.ExecuteReader();
                    CourseSelect.DataBind();
                }
            }



            string result = CourseSelect.SelectedItem.Value;

            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Select Section.Sec_Name from Section inner join Course on Section.Course = Course.CourseID where Course = @course";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = result;
                    conn.Open();
                    SectionSelect.DataSource = cmdSQL.ExecuteReader();
                    SectionSelect.DataBind();
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



    protected void StudentID_TextChanged(object sender, EventArgs e)
    {

    }

    protected void CourseSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        string result = CourseSelect.SelectedItem.Value;

        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = "Select Section.Sec_Name from Section inner join Course on Section.Course = Course.CourseID where Course = @course";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = result;
                conn.Open();
                SectionSelect.DataSource = cmdSQL.ExecuteReader();
                SectionSelect.DataBind();
            }
        }
    }

    protected void SectionSelect_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void AllocateCourseBtn_Click(object sender, EventArgs e)
    {
        //check to see if student exists in DB
        SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True");
        conn.Open();
        SqlCommand cm;
        string un = StudentID.Text;
        string query = "SELECT * FROM Student WHERE Student.Username = '" + un + "'";
        cm = new SqlCommand(query, conn);

        SqlDataReader res = cm.ExecuteReader();

        if (!res.HasRows)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No such student is found" + "');", true);
            return;
        }


        //check for pre req
        using (SqlConnection connPre = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSqlPre = " Select* from Course where (Course.PreReq = '' or Course.PreReq is NULL) AND Course.CourseID=@course";

            using (SqlCommand cmdSQLPre = new SqlCommand(strSqlPre, connPre))
            {
                cmdSQLPre.Parameters.Add("@course", SqlDbType.NVarChar).Value = CourseSelect.SelectedItem.Value;
                connPre.Open();
                SqlDataReader resPre = cmdSQLPre.ExecuteReader();

                //if course has prequisite
                if (!resPre.HasRows)
                {
                    using (SqlConnection conn1 = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
                    {
                        string strSql = " Select* from Course where Course.PreReq in (Select Record.Course from Record inner join Student on Student.Username = Record.Student_Name inner join Course on Course.CourseID = Record.Course where Student.Username = @stud and Record.Grade not like 'F') and Course.CourseID = @course";

                        using (SqlCommand cmdSQL = new SqlCommand(strSql, conn1))
                        {
                            cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = CourseSelect.SelectedItem.Value;
                            cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = StudentID.Text;
                            conn1.Open();
                            SqlDataReader res1 = cmdSQL.ExecuteReader();

                            if (!res1.HasRows)
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Pre requisite not cleared" + "');", true);
                                return;
                            }

                        }
                    }


                }
            }
        }
        using (SqlConnection conn2 = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql2 = "Select COUNT(Course) from Registers where Registers.StudentID = @stud ";

            using (SqlCommand cmdSQL2 = new SqlCommand(strSql2, conn2))
            {

                cmdSQL2.Parameters.Add("@stud", SqlDbType.NVarChar).Value = StudentID.Text;
                conn2.Open();
                string res2 = cmdSQL2.ExecuteScalar().ToString();
                int result = Convert.ToInt32(res2);


                if (result >= 6)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Student already has 6 courses" + "');", true);
                    return;
                }

            }
        }

        //check if student is already registered for the course
        using (SqlConnection conn3 = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql3 = "Select * from Registers where Registers.StudentID = @stud and Registers.Course = @course and Registers.Section = @sec";

            using (SqlCommand cmdSQL3 = new SqlCommand(strSql3, conn3))
            {
                cmdSQL3.Parameters.Add("@course", SqlDbType.NVarChar).Value = CourseSelect.SelectedItem.Value;
                cmdSQL3.Parameters.Add("@sec", SqlDbType.NVarChar).Value = SectionSelect.SelectedItem.Value;
                cmdSQL3.Parameters.Add("@stud", SqlDbType.NVarChar).Value = StudentID.Text;
                conn3.Open();
                SqlDataReader res3 = cmdSQL3.ExecuteReader();

                if (res3.HasRows)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Student already registered" + "');", true);
                    return;
                }


            }

        }

        //insert into registers
        using (SqlConnection conn4 = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql4 = "Insert Into Registers Values (@stud, @course, @sec);";

            using (SqlCommand cmdSQL4 = new SqlCommand(strSql4, conn4))
            {
                cmdSQL4.Parameters.Add("@course", SqlDbType.NVarChar).Value = CourseSelect.SelectedItem.Value;
                cmdSQL4.Parameters.Add("@sec", SqlDbType.NVarChar).Value = SectionSelect.SelectedItem.Value;
                cmdSQL4.Parameters.Add("@stud", SqlDbType.NVarChar).Value = StudentID.Text;
                conn4.Open();
                
                if (cmdSQL4.ExecuteNonQuery() != 0)
                { 
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Student registered sucessfully" + "');", true);
                    return;
                }

                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Insertion Failed" + "');", true);
                }
            }
        }




       
    }



}