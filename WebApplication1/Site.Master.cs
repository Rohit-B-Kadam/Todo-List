using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                int id = Convert.ToInt32(Session["UserId"].ToString());
                LblLoginUser.Text = GetUserName(id);
                
            }
            else
            {
                Response.Redirect("View/Authentication/Login.aspx");
            }
        }
        public string GetUserName(int id)
        {
            string UserName = "";
            /**connection string*/
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //User is reserve keyword so write in []
            string queryString = "SELECT * FROM [User] WHERE [UserId]='" + id + "';";

            /**Create and open connection*/
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //create command
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        //Match
                        // Setting Session
                        UserName = reader[1].ToString();
                    }
                    else
                    {
                        Response.Write("Error");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
            return UserName;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["UserId"] = null;
            Response.Redirect("~/View/Authentication/Login.aspx");
        }
    }
}