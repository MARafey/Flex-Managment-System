using System;
using System.Activities.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

public partial class Student_Attendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Select Registers.Course from Registers where Registers.StudentID =@stud";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                    conn.Open();
                    ddlCourses.DataSource = cmdSQL.ExecuteReader();
                    ddlCourses.DataBind();
                }
            }
           
        }


    }

    protected void btnTranscript_Click(object sender, EventArgs e)
    {
          Response.Redirect("Transcript.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
    }

    protected void SubmitCourse(object sender, EventArgs e)
    {

        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = "Select Attendance.ADate,Attendance.P_A AS Attendance from Attendance where Attendance.CourseID = @course and Attendance.Username =@stud;";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = ddlCourses.SelectedItem.Value;
                cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                conn.Open();
                gvAttendance.DataSource = cmdSQL.ExecuteReader();
                gvAttendance.DataBind();
            }
        }
        int presents = 0;
        int absents = 0;
        using (SqlConnection conn = new SqlConnection("Data Source = ABDUL_LAP\\SQLEXPRESS; Initial Catalog = Flex; Integrated Security = True"))
        {
            string strSql = "Select COUNT(Attendance.ADate) from Attendance where Attendance.CourseID = @course and Attendance.Username = @stud and Attendance.P_A='P'";
            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = ddlCourses.SelectedItem.Value;
                cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                conn.Open();

                string res = cmdSQL.ExecuteScalar().ToString();
                presents = Convert.ToInt32(res);
            }
        }

        using (SqlConnection conn = new SqlConnection("Data Source = ABDUL_LAP\\SQLEXPRESS; Initial Catalog = Flex; Integrated Security = True"))
        {
            string strSql = "Select COUNT(Attendance.ADate) from Attendance where Attendance.CourseID = @course and Attendance.Username = @stud and Attendance.P_A='A'";
            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = ddlCourses.SelectedItem.Value;
                cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                conn.Open();

                string res = cmdSQL.ExecuteScalar().ToString();
                absents = Convert.ToInt32(res);
            }
        }

        //populate Chart1 with variable presents and absents
        Chart1.Series["Series1"].Points.AddXY("Presents", presents);
        Chart1.Series["Series1"].Points.AddXY("Absents", absents);
        Chart1.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
        Chart1.Series["Series1"].IsValueShownAsLabel = true;
        Chart1.Series["Series1"].Label = "#PERCENT{P0}";
        Chart1.Series["Series1"].LegendText = "#VALX";
        Chart1.Series["Series1"].Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold);
        Chart1.Series["Series1"].LabelForeColor = System.Drawing.Color.White;
        Chart1.Series["Series1"].Points[0].Color = System.Drawing.Color.DarkBlue;
        Chart1.Series["Series1"].Points[1].Color = System.Drawing.Color.LightBlue;
        Chart1.Series["Series1"].Points[0].Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold);
        Chart1.Series["Series1"].Points[1].Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold);
        Chart1.Series["Series1"].Points[0].LabelForeColor = System.Drawing.Color.White;
        Chart1.Series["Series1"].Points[1].LabelForeColor = System.Drawing.Color.White;
        Chart1.Series["Series1"].Points[0].Label = presents.ToString();
        Chart1.Series["Series1"].Points[1].Label = absents.ToString();
        Chart1.Series["Series1"].Points[0].LegendText = "Presents";
        Chart1.Series["Series1"].Points[1].LegendText = "Absents";

        Chart1.Series["Series1"].Points[0].Label = "#PERCENT{P0}";
        Chart1.Series["Series1"].Points[1].Label = "#PERCENT{P0}";

        
        


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

    protected void ddlCourses0_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void gvAttendance_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}