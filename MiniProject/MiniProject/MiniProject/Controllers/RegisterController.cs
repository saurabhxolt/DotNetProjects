using MiniProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MiniProject;Integrated Security=True;";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Register ";
            List<RegisterModel> reg = new List<RegisterModel>();
            try
            {
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    reg.Add(new RegisterModel
                    {
                        
                        LoginName = dr["LoginName"].ToString(),
                        Password = dr["Password"].ToString(),
                        ConfirmPassword = dr["ConfirmPassword"].ToString(),
                        FullName = dr["FullName"].ToString(),
                        EmailId = dr["EmailId"].ToString(),
                        City = dr["City"].ToString(),
                        Phone = (long)dr["Phone"]
                       
                    });
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            cn.Close();
            return View(reg);

        }

        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        [HttpPost]
        public ActionResult Create(RegisterModel reg)
        {
            try
            {
                // TODO: Add insert logic here
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MiniProject;Integrated Security=True;";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "CreateProcedure";

                cmdInsert.Parameters.AddWithValue("@LoginName", reg.LoginName);
                cmdInsert.Parameters.AddWithValue("@Password", reg.Password);
                cmdInsert.Parameters.AddWithValue("@ConfirmPassword", reg.ConfirmPassword);
                cmdInsert.Parameters.AddWithValue("@FullName", reg.FullName);
                cmdInsert.Parameters.AddWithValue("@EmailId", reg.EmailId);
                cmdInsert.Parameters.AddWithValue("@City", reg.City);
                cmdInsert.Parameters.AddWithValue("@Phone", reg.Phone);

                try
                {
                    cmdInsert.ExecuteNonQuery();
                    //Console.WriteLine("no errors");
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }
                cn.Close();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult login()
        {
            return View();
        }

        // POST: Employee/Login
        [HttpPost]
        public ActionResult login(RegisterModel obj)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MiniProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select LoginName,Password,FullName from Register";
            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    if (
                    ((obj.LoginName).Equals((string)dr["LoginName"])) &&
                    ((obj.Password).Equals((string)dr["Password"])))
                    {

                        Session["LoginName"] = dr["LoginName"];
                        Session["FullName"] = dr["FullName"];
                        return RedirectToAction("WelcomePage");
                    }
                    else
                    {
                        ViewBag.error = "Invalid Account";
                    }

                }
                cn.Close();


            }
            catch
            {

            }

            return View();
        }

        public ActionResult Edit(string LoginName="Snehal")
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MiniProject;Integrated Security=True;";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "Select * from Register where LoginName=@LoginName";
            cmdInsert.Parameters.AddWithValue("@LoginName", LoginName);

            SqlDataReader dr = cmdInsert.ExecuteReader();
            RegisterModel obj = null;

            if (dr.Read())
            {
                obj = new RegisterModel
                {                   
                    FullName = dr["FullName"].ToString(),
                    EmailId = dr["EmailId"].ToString(),
                    City = dr["City"].ToString(),                                        
                    Phone = Convert.ToInt64(dr["Phone"])
                };
            }
            else
            {
                ViewBag.ErrorMessage = "Not found";
            }
            cn.Close();
            return View(obj);

        }

        // POST: Register/Edit/5
        [HttpPost]
        public ActionResult Edit(string LoginName, RegisterModel reg)
        {
            try
            {
                // TODO: Add update logic here
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MiniProject;Integrated Security=True;";

                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "UpdateProcedure";// Stored Procedure name

                cmdInsert.Parameters.AddWithValue("@LoginName", reg.LoginName);
                cmdInsert.Parameters.AddWithValue("@FullName", reg.FullName);
                cmdInsert.Parameters.AddWithValue("@EmailId", reg.EmailId);
                cmdInsert.Parameters.AddWithValue("@City", reg.City);
                cmdInsert.Parameters.AddWithValue("@Phone", reg.Phone);

                try
                {
                    cmdInsert.ExecuteNonQuery();// it return single value // first row,first column
                    Console.WriteLine("No Error");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    cn.Close();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult CancelForm(RegisterModel reg)
        {
            ViewBag.Message = "The operation was cancelled!";
            return View("Edit", reg);
        }
        
        public ActionResult WelcomePage()
        {

            return View();
        }

       
    }
}
