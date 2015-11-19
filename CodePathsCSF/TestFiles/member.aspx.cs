using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace CodePathsCSF
{
    public partial class member1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static Member GetMemberById(int memberId)


        {
            Member member = new Member();
            string cs = ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetMemberId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = memberId
                });

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    member.ID = Convert.ToInt32(rdr["Id"]);
                    member.FirstName = rdr["Firstname"].ToString();
                    member.Lastname = rdr["Lastname"].ToString();
                    member.Subscriber = rdr["Subscriber"].ToString();
                    member.Relationship = rdr["Relationship"].ToString();
                }

            }
            return member;

        }
    }
}