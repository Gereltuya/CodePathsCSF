using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


namespace CodePathsCSF
{
    public partial class getjson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            string connectionString = ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString;
            string queryString = "SELECT * FROM dbo.member;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try {
                    Response.Write("{\"Records\":[");
                    int x = 0;
                while (reader.Read())
                {
                    if (x == 0)
                    {
                        //format should look like this:  {“sql01”:”sql02”}

                        Response.Write(String.Format("{0}, {1},{2},{3},{4},{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], "{", "\"", "}"));
                    }
                    else
                    {
                        //format should look like this: ,{“sql01”:”sql02”}

                        Response.Write(String.Format(",{0}, {1},{2},{3},{4},{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], "{", "\"", "}"));
                    }
                    x = x + 1;

                }
                //format should look like this: ]}   

                Response.Write(String.Format("{0} {1}", "]", "}")); }

                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }

        }
    }
}