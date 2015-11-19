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
            string queryString = "SELECT * FROM Member where ID=1 ;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try {
                    Response.Write("{\"Records\":[");
                    int x = 0;
                    string patient_name = "";
                    string patient_dob = "";
                    string subscriber_name = "";
                    while (reader.Read())
                    {
                        patient_name = reader[1] + " " + reader[2];
                        patient_dob = reader[3].ToString();
                        subscriber_name = reader[4].ToString();
                        Response.Write("{");
                        Response.Write(String.Format("\"patient_name\":\"{0}\"", patient_name));
                        Response.Write(",");
                        Response.Write(String.Format("\"patient_dob\":\"{0}\"", patient_dob));
                        Response.Write(",");
                        Response.Write(String.Format("\"subscriber_name\":\"{0}\"", subscriber_name));
                        Response.Write(",");
                        Response.Write("}");
                        Response.Write("]");
                        Response.Write("}");


                        //                        Response.Write(String.Format("{2}{3}{0}{3}:{3}{1}{3}{4}", reader[0], reader[1], "{", "\"", "}"));


                        //format should look like this: ,{“sql01”:”sql02”}

                        //                            Response.Write(String.Format(",{2}{3}{0}{3}:{3}{1}{3}{4}", reader[0], reader[1], "{", "\"", "}"));
                        x = x + 1;


                    }
                }
                //format should look like this: ]}   

                //                    Response.Write(String.Format("{0} {1}", "]", "}")); }

                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            }

        }
    }
