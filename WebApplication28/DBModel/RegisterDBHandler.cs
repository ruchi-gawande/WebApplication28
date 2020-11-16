using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication28.DBModel
{
    public class RegisterDBHandler
    {
        //this class is used for handling db quiries
        private SqlConnection con;
        //method for db connection
        private void connection()
        {
            string connn = ConfigurationManager.ConnectionStrings["dxc"].ToString();
            con = new SqlConnection(connn);

        }
        //code for inerting data
        public bool InsertUser(Registration registration)
        {
            connection();
            string q = "Insert into Registration values(" + registration.userid + ",'" + registration.username + "'," + registration.age + ",'"+registration.email+"','"+registration.address+"','"+registration.city+"','"+registration.state+"','"+registration.country+"','"+registration.gender+"',"+registration.contact+")";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }
        public List<Registration> GetUsers()
        {
            connection();
            List<Registration> registrations = new List<Registration>();
            string q = "select * from Registration";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            ad.Fill(dt);
            con.Close();
            //fecth


            foreach (DataRow dr in dt.Rows)
            {
                registrations.Add(new Registration
                {
                    userid = Convert.ToInt32(dr["userid"]),
                    username = Convert.ToString(dr["username"]),
                    age = Convert.ToInt32(dr["age"]),
                    email = Convert.ToString(dr["email"]),
                    address = Convert.ToString(dr["address"]),
                    city = Convert.ToString(dr["city"]),
                    state = Convert.ToString(dr["state"]),
                    country = Convert.ToString(dr["country"]),
                    gender = Convert.ToString(dr["gender"]),
                   contact = Convert.ToInt32(dr["contact"])
                });

            }
            return registrations;
        }
        public bool updateUser(Registration registration)
        {
            connection();
            string q = "update Registration set Name=" + registration.userid + ",'" + registration.username + "'," + registration.age + ",'" + registration.email + "','" + registration.address + "','" + registration.city + "','" + registration.state + "','" + registration.country + "','" + registration.gender + "'," + registration.contact + " where userid=" + registration.userid;
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else return false;
        }

        public bool DelUser(int id)
        {
            connection();
            string q = "delete from Registration where Id=" + id;
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;

        }
        //public ActionResult Details(int id)
        //{
        //    CourseDBHandler dBHandler = new CourseDBHandler();
        //    return View(dBHandler.GetCourses().Find(Course => Course.Id == id));
        //}
    }
}
