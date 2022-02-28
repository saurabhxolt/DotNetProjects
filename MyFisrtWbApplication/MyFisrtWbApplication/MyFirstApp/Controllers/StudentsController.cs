using MyFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApp.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            List<students> stds = new List<students>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FirstWebAppDb;Integrated Security=True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from students";

            
            try {

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {

                    stds.Add(new students { Id = dr.GetInt32(0), Name = dr.GetString(1), Age= dr.GetInt32(2), Course=dr.GetString(3),Mobile=dr.GetString(4)});
                   
                }
                dr.Close();

            } 
            catch(Exception e) {
                // Console.WriteLine(e.Message);
                ViewBag.message = e.Message;
            }

            cn.Close();
            return View(stds);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FirstWebAppDb;Integrated Security=True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from students where Id=@Id";
            cmd.Parameters.AddWithValue("@Id", id);
            students ret = null;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    ret = new students { Id = dr.GetInt32(0), Name = dr.GetString(1), Age = dr.GetInt32(2), Course = dr.GetString(3), Mobile = dr.GetString(4) };
                }



            }
            catch (Exception e)
            {
               
                ViewBag.message = e.Message;
            }

            cn.Close();

            return View(ret);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(students obj)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FirstWebAppDb;Integrated Security=True;";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into students values(@Name,@Age,@Course,@Mobile)";

           
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Age", obj.Age);
            cmd.Parameters.AddWithValue("@Course", obj.Course);
            cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);

            try
            {
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.mesg = ex;
                return View();
            }
            finally{
                conn.Close();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FirstWebAppDb;Integrated Security=True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from students where Id=@Id";
            cmd.Parameters.AddWithValue("@Id", id);
            students ret = null;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    ret = new students { Id = dr.GetInt32(0), Name = dr.GetString(1), Age = dr.GetInt32(2), Course = dr.GetString(3), Mobile = dr.GetString(4) };
                }



            }
            catch (Exception e)
            {

                ViewBag.message = e.Message;
            }

            cn.Close();

           



            return View( ret);
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, students obj)
        {


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FirstWebAppDb;Integrated Security=True;";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update students set Name=@Name,Age=@Age,Course=@Course,Mobile=@Mobile where Id =@Id";

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Age", obj.Age);
            cmd.Parameters.AddWithValue("@Course", obj.Course);
            cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);

            try
            {
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.mesg = ex;
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {


            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FirstWebAppDb;Integrated Security=True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from students where Id=@Id";
            cmd.Parameters.AddWithValue("@Id", id);
            students ret = null;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    ret = new students { Id = dr.GetInt32(0), Name = dr.GetString(1), Age = dr.GetInt32(2), Course = dr.GetString(3), Mobile = dr.GetString(4) };
                }



            }
            catch (Exception e)
            {

                ViewBag.message = e.Message;
            }

            cn.Close();

            return View(ret);
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FirstWebAppDb;Integrated Security=True;";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "delete from  students  where Id =@Id";

            cmd.Parameters.AddWithValue("@Id", id);
           

            try
            {
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.mesg = ex;
                return View();
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
