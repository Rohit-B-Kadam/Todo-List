using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.View.DashBoard
{
    public partial class CompleteTaskList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void Done_Click(object sender, EventArgs e)
        {
            LblShowStatus.Text = (sender as Button).ID;
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            LblShowStatus.Text = (sender as Button).ID;
        }

        protected void grdTaskView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

       
        protected void Button1_Click(object sender, EventArgs e)//delete method
        {
            foreach (GridViewRow row in grdTaskView.Rows)
            {
                CheckBox cbox = (row.Cells[0].FindControl("Chk") as CheckBox);
                int taskId = Convert.ToInt32(row.Cells[1].Text);

                if (cbox.Checked)
                {
                    DeleteRow(taskId);
                }

            }
            grdTaskView.DataBind();
            LblShowStatus.Text = "Selected Task has been Deleted";
        }

        private void DeleteRow(int taskId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete", con);
                cmd.Parameters.AddWithValue("@Id", taskId);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
        }
    }
}