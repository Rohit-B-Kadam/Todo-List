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
    public partial class Login : System.Web.UI.Page
    {

      
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            /**connection string*/
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string email = TxtEmail.Text;
            string password = TxtPassword.Text;
            //User is reserve keyword so write in []
            string queryString = "SELECT * FROM [User] WHERE [Email] = '"+email+"' AND [Password]='"+password+"';";
            
            /**Create and open connection*/
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //create command
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.Read())
                    {
                        //Match
                        // Setting Session
                        Session["UserId"] = reader[0];
                        Response.Redirect("../DashBoard/TodoLists.aspx");
                    }
                    else
                    {
                        LblShowErrorMessage.Text = "Email and Password inValid";
                    }
                }catch(Exception ex)
                {
                    Response.Write(ex);
                }
            }
            
        }
    }
}
