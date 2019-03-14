using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using WebApplication1.Model;
namespace WebApplication1.View.DashBoard
{
    public partial class TodoLists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void AddTask_Click(object sender, EventArgs e)
        {
            if (TxtTitle.Text != "")
            {
                int UserId = Convert.ToInt32(Session["UserId"].ToString());
                AddTaskInDataBase(TxtTitle.Text, Convert.ToInt32(DDPrioritySelected.Text), UserId);
                TxtTitle.Text = "";
                grdTaskView.DataBind();
            }
            else
            {
                lblSuccess.Text = "First give the Title";
            }
        }

        public void AddTaskInDataBase(string title , int priority, int userId)
        {
            /**connection string*/
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //User is reserve keyword so write in []
            
            /**Create and open connection*/
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //create command

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Insert", connection);

                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@status", "incomplete");
                    command.Parameters.AddWithValue("@priority", priority);
                    command.Parameters.AddWithValue("@userId", userId);
                
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    lblSuccess.Text = "Task is successfully Added";
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }


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

        protected void BtnComplete_Click(object sender, EventArgs e)
        {
            
            foreach (GridViewRow row in grdTaskView.Rows)
            {
                CheckBox cbox = (row.Cells[0].FindControl("Chk") as CheckBox);
                int taskId = Convert.ToInt32(row.Cells[1].Text);

                if (cbox.Checked)
                {
                    CompleteRow(taskId);
                }

            }
            grdTaskView.DataBind();
            LblShowStatus.Text = "Selected Task is set as Complete";
        }
    
        
        private void CompleteRow(int taskId)
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