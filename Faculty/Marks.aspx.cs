using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Activities.Statements;

public partial class Evaluation : Page
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

               using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
               {
                    string strSql = "Select Registers.StudentID from Registers where Registers.Course = @course and Registers.Section = @sec";
                    using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                    {
                         cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                         cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                         conn.Open();
                         studentDropdown.DataSource = cmdSQL.ExecuteReader();
                         studentDropdown.DataBind();
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

          using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
          {
               string strSql = "Select Registers.StudentID from Registers where Registers.Course = @course and Registers.Section = @sec";
               using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
               {
                    cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                    cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                    conn.Open();
                    studentDropdown.DataSource = cmdSQL.ExecuteReader();
                    studentDropdown.DataBind();
               }
          }
     }
          protected void sectionDropdown_SelectedIndexChanged(object sender, EventArgs e)
     {
          using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
          {
               string strSql = "Select Registers.StudentID from Registers where Registers.Course = @course and Registers.Section = @sec";
               using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
               {
                    cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                    cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                    conn.Open();
                    studentDropdown.DataSource = cmdSQL.ExecuteReader();
                    studentDropdown.DataBind();
               }
          }
     }

     protected void studentDropdown_SelectedIndexChanged(object sender, EventArgs e)
     {
          // Add your logic for handling the selected index change event of studentDropdown here
     }

     protected void TextBox1_TextChanged(object sender, EventArgs e)
     {
          // Add your logic for handling the text changed event of TextBox1 here
     }

     protected void TextBox2_TextChanged(object sender, EventArgs e)
     {
          // Add your logic for handling the text changed event of TextBox2 here
     }

     protected void TextBox3_TextChanged(object sender, EventArgs e)
     {
          // Add your logic for handling the text changed event of TextBox3 here
     }

     protected void TextBox4_TextChanged(object sender, EventArgs e)
     {
          // Add your logic for handling the text changed event of TextBox4 here
     }

     protected void ShowStudentsBtn_Click(object sender, EventArgs e)
     {


          //Get marks distribution
          int quizTotal, assTotal, sessTotal, finalTotal;
          using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
          {
               string strSql = " Select Marks_Distribution.Assignments_Distr from Marks_Distribution where Marks_Distribution.Course = @course and Marks_Distribution.Sec_Name = @sec";

               using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
               {
                    cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                    cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                    conn.Open();
                    string res = cmdSQL.ExecuteScalar().ToString();
                    assTotal = Convert.ToInt32(res);
               }
          }

          using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
          {
               string strSql = " Select Marks_Distribution.Sessional_Distr from Marks_Distribution where Marks_Distribution.Course = @course and Marks_Distribution.Sec_Name = @sec";

               using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
               {
                    cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                    cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                    conn.Open();
                    string res = cmdSQL.ExecuteScalar().ToString();
                    sessTotal = Convert.ToInt32(res);
               }
          }

          using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
          {
               string strSql = " Select Marks_Distribution.Quizes_Distr from Marks_Distribution where Marks_Distribution.Course = @course and Marks_Distribution.Sec_Name = @sec";

               using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
               {
                    cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                    cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                    conn.Open();
                    string res = cmdSQL.ExecuteScalar().ToString();
                    quizTotal = Convert.ToInt32(res);
               }
          }

          using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
          {
               string strSql = " Select Marks_Distribution.Finals_Distr from Marks_Distribution where Marks_Distribution.Course = @course and Marks_Distribution.Sec_Name = @sec";

               using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
               {
                    cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                    cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                    conn.Open();
                    string res = cmdSQL.ExecuteScalar().ToString();
                    finalTotal = Convert.ToInt32(res);
               }
          }
          ////
          ///

          if (quizTotal < int.Parse(TextBox1.Text) || assTotal < int.Parse(TextBox2.Text) || sessTotal < int.Parse(TextBox3.Text) || finalTotal < int.Parse(TextBox4.Text))
          {
               ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Marks are greater than the distribution');", true);
               return;
          }

          using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
          {
               string strSql = "Select* from MARKS where MARKS.Course =@course and MARKS.Sec_Name = @sec and MARKS.StudentID =@stud";

               using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
               {
                    cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                    cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                    cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = studentDropdown.SelectedItem.Value;

                    conn.Open();
                    if (cmdSQL.ExecuteReader().HasRows)
                    {

                         using (SqlConnection conn1 = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
                         {
                              string strSql1 = "  Update MARKS Set Assignments_Marks = @ass, Sessional_Marks = @sess, Quizes_Marks = @quiz, Finals_Marks = @final Where MARKS.StudentID = @stud and MARKS.Course = @course and MARKS.Sec_Name = @sec";

                              using (SqlCommand cmdSQL1 = new SqlCommand(strSql1, conn1))
                              {
                                   cmdSQL1.Parameters.Add("@course", SqlDbType.NVarChar).Value = courseDropdown.SelectedItem.Value;
                                   cmdSQL1.Parameters.Add("@sec", SqlDbType.NVarChar).Value = sectionDropdown.SelectedItem.Value;
                                   cmdSQL1.Parameters.Add("@stud", SqlDbType.NVarChar).Value = studentDropdown.SelectedItem.Value;
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
               string strSql = " Insert Into MARKS Values (@stud, @course, @sec, @ass, @sess, @quiz, @final)";

               using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
               {
                    cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = studentDropdown.SelectedItem.Value;
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

     protected void evaluationTypeDropdown_SelectedIndexChanged(object sender, EventArgs e)
     {
          string evaluationType = evaluationTypeDropdown.SelectedValue;

          marksTextBox.Visible = evaluationType == "sessional" || evaluationType == "quiz" || evaluationType == "final";
          sessionalMarksTextBox.Visible = evaluationType == "sessional";
          quizMarksTextBox.Visible = evaluationType == "quiz";
          finalMarksTextBox.Visible = evaluationType == "final";
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