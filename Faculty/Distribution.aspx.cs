using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

public partial class MarksDistribution : System.Web.UI.Page
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

    protected void SaveDistributionBtn_Click(object sender, EventArgs e)
    {
        if (Int32.Parse(TextBox1.Text) + Int32.Parse(TextBox2.Text) + Int32.Parse(TextBox3.Text) + Int32.Parse(TextBox4.Text) != 100)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please enter correct values" + "');", true);
            return;
        }

        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = " Select* from Marks_Distribution where Marks_Distribution.Course = @course and Marks_Distribution.Sec_Name = @sec";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                conn.Open();
                if (cmdSQL.ExecuteReader().HasRows)
                {
                    using (SqlConnection conn1 = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
                    {
                        string strSql1 = "Update Marks_Distribution Set Assignments_Distr = @ass, Sessional_Distr = @sess, Quizes_Distr = @quiz, Finals_Distr = @final where Marks_Distribution.Course =@course and Marks_Distribution.Sec_Name =@sec ";

                        using (SqlCommand cmdSQL1 = new SqlCommand(strSql1, conn1))
                        {
                            cmdSQL1.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                            cmdSQL1.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                            cmdSQL1.Parameters.Add("@ass", SqlDbType.Int).Value = int.Parse(TextBox2.Text);
                            cmdSQL1.Parameters.Add("@sess", SqlDbType.Int).Value = int.Parse(TextBox3.Text);
                            cmdSQL1.Parameters.Add("@quiz", SqlDbType.Int).Value = int.Parse(TextBox1.Text);
                            cmdSQL1.Parameters.Add("@final", SqlDbType.Int).Value = int.Parse(TextBox4.Text);

                            conn1.Open();
                            if (cmdSQL1.ExecuteNonQuery() != 0)
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Succesfuly updated" + "');", true);
                                return;
                            }

                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Error updating" + "');", true);
                                return;
                            }

                        }
                    }

                }


            }
        }

        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = " Insert Into Marks_Distribution Values (@course, @sec, @ass, @sess, @quiz, @final)";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                cmdSQL.Parameters.Add("@ass", SqlDbType.Int).Value = int.Parse(TextBox2.Text);
                cmdSQL.Parameters.Add("@sess", SqlDbType.Int).Value = int.Parse(TextBox3.Text);
                cmdSQL.Parameters.Add("@quiz", SqlDbType.Int).Value = int.Parse(TextBox1.Text);
                cmdSQL.Parameters.Add("@final", SqlDbType.Int).Value = int.Parse(TextBox4.Text);

                conn.Open();
                if (cmdSQL.ExecuteNonQuery() != 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Succesfuly added" + "');", true);
                }

                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Error adding" + "');", true);
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
       


       
     }
}