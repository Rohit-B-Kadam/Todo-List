using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.View
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Registration
        protected void Button1_Click(object sender, EventArgs e)
        {

            /**connection string*/
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //User is reserve keyword so write in []
            string queryString = "INSERT INTO [User]([UserName],[Password],[Email]) values(@uname,@pass,@email)";

            int UserId = GetUserId(TxtEmail.Text);

            if(UserId != -1)
            {
                // alredy email is taken
                LblShowErrorMessage.Text = "Acoount Already Exist";
                return;
            }
            /**Create and open connection*/
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //create command
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@uname", TxtUserName.Text);
                command.Parameters.AddWithValue("@pass", TxtPassword.Text);
                command.Parameters.AddWithValue("@email", TxtEmail.Text);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    // ReDirect
                    UserId = GetUserId(TxtEmail.Text);
                    Session["UserId"] = UserId;
                    Response.Redirect("../DashBoard/TodoLists.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
                
            
        }

        public int GetUserId(string email)
        {
            int UserId = -1;
            /**connection string*/
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //User is reserve keyword so write in []
            string queryString = "SELECT * FROM [User] WHERE Email = @email;";

            /**Create and open connection*/
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //create command
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@email", email);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {

                        UserId = Convert.ToInt32(reader[0].ToString());
                        Response.Write(UserId);
                    }
                    else
                    {
                        UserId = -1;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }

            return UserId;
        }
    }
}