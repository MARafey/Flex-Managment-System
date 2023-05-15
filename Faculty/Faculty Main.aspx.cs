using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Faculty_Faculty_Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }

    protected void AttendenceMarksBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Attendance.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
    }

    protected void MarksDistributionBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Distribution.aspx?Parameter="+ Request.QueryString["Parameter"].ToString());
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
}