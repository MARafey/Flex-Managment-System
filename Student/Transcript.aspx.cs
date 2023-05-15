using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;

public partial class Student_Transcript : System.Web.UI.Page
{
    protected string getGPA(string grade)
    {
        if (grade == "A"|| grade=="A+")
            return "4.00";
        else if (grade == "A-")
            return "3.67";
        else if (grade == "B+")
            return "3.33";
        else if (grade == "B")
            return "3.00";
        else if (grade == "B-")
            return "2.67";
        else if (grade == "C+")
            return "2.33";
        else if (grade == "C")
            return "2.00";
        else if (grade == "C-")
            return "1.67";
        else if (grade == "D+")
            return "1.33";
        else if (grade == "D")
            return "1.00";
        else if (grade == "F")
            return "0.0";
        else
            return "0.0";
        

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        float CGPA;
        float obtained=0;
        float total=0;
        string crdHrs;
        if (!IsPostBack)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Select Course, Grade from Record where Record.Student_Name = @stud";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("Course");
                    table.Columns.Add("CreditHrs");
                    table.Columns.Add("Grade");
                    table.Columns.Add("GPA");

                    cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                    conn.Open();

                    SqlDataReader dr = cmdSQL.ExecuteReader();
                    while (dr.Read())
                    {
                        DataRow row= table.NewRow();

                        row[0]= dr.GetValue(0).ToString();
                        row[2]= dr.GetValue(1).ToString();
                        row[3] = getGPA(row[2].ToString());

                        using (SqlConnection conn1 = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
                        {
                            string strSql1 = " Select Course.CreditHrs from Course where Course.CourseID =@course";

                            using (SqlCommand cmdSQL1 = new SqlCommand(strSql1, conn1))
                            {
                                cmdSQL1.Parameters.Add("@course", SqlDbType.NVarChar).Value = dr.GetValue(0).ToString();
                                conn1.Open();
                                crdHrs = cmdSQL1.ExecuteScalar().ToString();
                            }
                        }
                        row[1] = crdHrs;
                        
                        obtained += (float.Parse(getGPA(row[2].ToString()))* float.Parse(crdHrs));
                        total+= float.Parse(crdHrs);
                        table.Rows.Add(row);
                    }

                    // now bind
                    gvTranscript.DataSource = table;
                    gvTranscript.DataBind();
                }

            }

            if (total == 0)
                CGPA = 0;
            else
                CGPA=obtained/total;

            lblCGPA.Text = CGPA.ToString();

            //using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            //{
            //    string strSql = "Select Users.Name1 from Users where Users.Username =@stud";

            //    using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            //    {
            //        cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
            //        conn.Open();
            //        SqlDataReader dr = cmdSQL.ExecuteReader();
            //        while (dr.Read())
            //        {
            //            Label1.Text = dr.GetValue(0).ToString();
            //        }
            //    }
            //}


            
        }
    }
        
    
 
     protected void btnHome_Click(object sender, EventArgs e)
     {
          Response.Redirect("Student Main.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void btnAttendance_Click1(object sender, EventArgs e)
     {
          Response.Redirect("Attendance.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void btnMarks_Click1(object sender, EventArgs e)
     {
          Response.Redirect("Marks.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

     protected void btnFeedback_Click1(object sender, EventArgs e)
     {
          Response.Redirect("Feedback.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }
     
     protected void btnTranscript_Click1(object sender, EventArgs e)
     {
          Response.Redirect("Transcript.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
     }

}