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
using System.Xml.Linq;

public partial class Student_Feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
            {
                string strSql = "Select Registers.Course from Registers where Registers.StudentID = @stud";

                using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
                {
                    cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                    conn.Open();
                    DropDownList1.DataSource = cmdSQL.ExecuteReader();
                    DropDownList1.DataBind();
                }
            }
        }
    }


    protected int returnTotal()
    {
        int total = 0;
        int notSelected=0;

        foreach (ListItem li in RadioButtonList2.Items)
        {
            if (!li.Selected)
                notSelected++;

            else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
            
        }
        if (notSelected == 5 ) {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;
        }

        notSelected = 0;
        foreach (ListItem li in RadioButtonList3.Items)
        {
            if (!li.Selected)
                notSelected++;
            else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }

        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;
        }


        notSelected = 0;
        foreach (ListItem li in RadioButtonList4.Items)
        {
            if (!li.Selected)
                notSelected++;

            else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }


        notSelected = 0;
        foreach (ListItem li in RadioButtonList5.Items)
        {
            if (!li.Selected)
                notSelected++;

          else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }

        notSelected = 0;
        foreach (ListItem li in RadioButtonList6.Items)
        {
            if (!li.Selected)
                notSelected++;

          else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }

        notSelected = 0;
        foreach (ListItem li in RadioButtonList7.Items)
        {
            if (!li.Selected)
                notSelected++;

          else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }


        notSelected = 0;
        foreach (ListItem li in RadioButtonList8.Items)
        {
            if (!li.Selected)
                notSelected++;

          else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }


        notSelected = 0;
        foreach (ListItem li in RadioButtonList9.Items)
        {
            if (!li.Selected)
                notSelected++;

          else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }



        notSelected = 0;
        foreach (ListItem li in RadioButtonList10.Items)
        {
            if (!li.Selected)
                notSelected++;

          else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }



        notSelected = 0;
        foreach (ListItem li in RadioButtonList11.Items)
        {
            if (!li.Selected)
                notSelected++;

          else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }



        notSelected = 0;
        foreach (ListItem li in RadioButtonList12.Items)
        {
            if (!li.Selected)
                notSelected++;
            else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }


        notSelected = 0;
        foreach (ListItem li in RadioButtonList13.Items)
        {
            if (!li.Selected)
                notSelected++;

            else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }




        notSelected = 0;
        foreach (ListItem li in RadioButtonList14.Items)
        {
            if (!li.Selected)
                notSelected++;

            else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }




        notSelected = 0;
        foreach (ListItem li in RadioButtonList15.Items)
        {
            if (!li.Selected)
                notSelected++;

          else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }



        notSelected = 0;
        foreach (ListItem li in RadioButtonList16.Items)
        {
            if (!li.Selected)
                notSelected++;

          else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }



        notSelected = 0;
        foreach (ListItem li in RadioButtonList17.Items)
        {
            if (!li.Selected)
                notSelected++;
            else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }

        notSelected = 0;
        foreach (ListItem li in RadioButtonList18.Items)
        {
            if (!li.Selected)
                notSelected++;
            else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }
        notSelected = 0;



        foreach (ListItem li in RadioButtonList19.Items)
        {
            if (!li.Selected)
                notSelected++;
            else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }   
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }




        notSelected = 0;
        foreach (ListItem li in RadioButtonList20.Items)
        {
            if (!li.Selected)
                notSelected++;
            else if (li.Selected)
            {
                total += Convert.ToInt32(li.Text);
            }
        }
        if (notSelected == 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return 0;

        }



        return total;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string section;
        string instructor;
        int percentage;


        if (Datebox.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Enter All fields" + "');", true);
            return;
        }

        
       

        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = " Select Registers.Section from Registers where Registers.StudentID =@stud and Registers.Course =@course";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = DropDownList1.Text;
                conn.Open();
                section = cmdSQL.ExecuteScalar().ToString();
            }
        }

        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = " Select Section.Instructor from Section where Section.Course =@course and Section.Sec_Name =@sec";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = DropDownList1.Text;
                cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = section;
                conn.Open();
                instructor = cmdSQL.ExecuteScalar().ToString();
            }
        }

        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = " Select* from Feedback where Feedback.StudentID =@stud and Feedback.Course =@course and Feedback.Section =@sec";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = DropDownList1.Text;
                cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = section;
                conn.Open();
                if (cmdSQL.ExecuteReader().HasRows)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Feedback already given" + "');", true);
                    return;
                }

            }
        }

        percentage = (returnTotal() / 95) * 100;       //95 total points obtainable, returnTotal returns total points obtained
        if (percentage == 0)
            return;
        using (SqlConnection conn = new SqlConnection("Data Source=ABDUL_LAP\\SQLEXPRESS;Initial Catalog=Flex;Integrated Security=True"))
        {
            string strSql = " Insert into Feedback Values (@stud, @instr, @course, @sec, @date, @per, @comment);";

            using (SqlCommand cmdSQL = new SqlCommand(strSql, conn))
            {
                cmdSQL.Parameters.Add("@course", SqlDbType.NVarChar).Value = DropDownList1.Text;
                cmdSQL.Parameters.Add("@stud", SqlDbType.NVarChar).Value = Request.QueryString["Parameter"].ToString();
                cmdSQL.Parameters.Add("@instr", SqlDbType.NVarChar).Value = instructor;
                cmdSQL.Parameters.Add("@sec", SqlDbType.NVarChar).Value = section;
                cmdSQL.Parameters.Add("@date", SqlDbType.NVarChar).Value = Datebox.Text;
                cmdSQL.Parameters.Add("@per", SqlDbType.NVarChar).Value = percentage;
                cmdSQL.Parameters.Add("@comment", SqlDbType.NVarChar).Value = TextBox5.Text;
                conn.Open();
                if (cmdSQL.ExecuteNonQuery() == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Update Failed" + "');", true);
                    return;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Feedback Given" + "');", true);
                }
            }
        }

        //delay for 2 secs
        System.Threading.Thread.Sleep(2000);
        Response.Redirect("Student Main.aspx?Parameter=" + Request.QueryString["Parameter"].ToString());
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {

    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}