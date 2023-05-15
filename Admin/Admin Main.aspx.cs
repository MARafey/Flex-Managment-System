using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Main : System.Web.UI.Page
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
    

    protected void StudentRegistrationBtn_Click(object sender, EventArgs e)
    {

    }

}