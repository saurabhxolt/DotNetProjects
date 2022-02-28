using ExamPractice2WithWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace ExamPractice2WithWebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        // GET: api/Students
        public IEnumerable<Student> Get()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamPractice;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            cn.Open();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.Connection = cn;
            cmdSelect.CommandType = System.Data.CommandType.Text;
            cmdSelect.CommandText = "Select * from Students";

            List<Student> list = new List<Student>();

            SqlDataReader dr = cmdSelect.ExecuteReader();
            while(dr.Read())
            {
                list.Add(new Student { StudentId = dr.GetInt32(0), Name = dr.GetString(1), JavaMarks = dr.GetInt32(2), DotNetMarks = dr.GetInt32(3) } );
            }

            dr.Close();
            cn.Close();
            return list;
        }

        // GET: api/Students/5
        public Student Get(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString= @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamPractice;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            cn.Open();

            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.Connection = cn;
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.CommandText = "SelectStudent";

            cmdSelect.Parameters.AddWithValue("@StudentId", id);
            SqlDataReader dr = cmdSelect.ExecuteReader();
            Student stu = null;
            while(dr.Read())
            {
                stu = new Student {StudentId=id, Name=dr.GetString(1), JavaMarks=dr.GetInt32(2), DotNetMarks=dr.GetInt32(3) };
            }
            dr.Close();
            cn.Close();
            return stu;
        }

        // POST: api/Students
        public void Post([FromBody]Student stu)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamPractice;Integrated Security=True;";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsert.CommandText = "InsertStudent";


            cmdInsert.Parameters.AddWithValue("@StudentId", stu.StudentId);
            cmdInsert.Parameters.AddWithValue("@Name", stu.Name);
            cmdInsert.Parameters.AddWithValue("@JavaMarks", stu.JavaMarks);
            cmdInsert.Parameters.AddWithValue("@DotNetMarks", stu.DotNetMarks);


            try
            {
                cmdInsert.ExecuteNonQuery();

            }catch(Exception e)
            {
               
            }

            cn.Close();

        }

        // PUT: api/Students/5
        public void Put(int id, [FromBody]Student stu)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamPractice;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            cn.Open();

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUpdate.CommandText = "UpdateStudent";

            Student obj = new Student { StudentId = id, Name = stu.Name, JavaMarks = stu.JavaMarks, DotNetMarks = stu.DotNetMarks };
            cmdUpdate.Parameters.AddWithValue("@StudentId", obj.StudentId);
            cmdUpdate.Parameters.AddWithValue("@Name", obj.Name);
            cmdUpdate.Parameters.AddWithValue("@JavaMarks", obj.JavaMarks);
            cmdUpdate.Parameters.AddWithValue("@DotNetMarks", obj.DotNetMarks);

            try
            {
                cmdUpdate.ExecuteNonQuery();
            }catch(Exception e)
            {

            }
            cn.Close();

        }

        // DELETE: api/Students/5
        public void Delete(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamPractice;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            cn.Open();

            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = cn;
            cmdDelete.CommandType = System.Data.CommandType.Text;
            cmdDelete.CommandText = "Delete from Students where StudentId=@StudentId";

            cmdDelete.Parameters.AddWithValue("@StudentId", id);
            cmdDelete.ExecuteNonQuery();
            cn.Close();

        }
    }
}
