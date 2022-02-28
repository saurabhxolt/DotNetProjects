using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistrationWithLogin.Models;

namespace UserRegistrationWithLogin.Controllers
{
    public class UsersController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=jkjan22;Integrated Security=True;";
            cn.Open();
           // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=jkjan22;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from User1 ";

            List<User> obj = new List<User>();
            try
            {
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    obj.Add(new User { LoginName = dr["LoginName"].ToString(), Password = dr["Password"].ToString(), ConPasssword = dr["ConPasssword"].ToString(), FullName = dr["FullName"].ToString(), EmailId = dr["EmailId"].ToString(), City = dr["City"].ToString(), Phone = dr.GetInt32(6) });
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                ViewBag.err = ex.Message;
            }
            cn.Close();
            ViewBag.checking = "Done";
            return View(obj);

        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {

            return View();
        }

       
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
               

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=jkjan22;Integrated Security=True;";
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                //cmdInsert.CommandText = "select * from Empoloyees where EmpNo=@EmpNo ";
                //cmdInsert.CommandText = "Update Empoloyees set Name=name,EmpNo=empno,Basic=basic,DeptNo=deptno where EmpNo=@EmpNo  ";
                cmdInsert.CommandText = "Insert into User1 values(@LoginName,@Password,@ConPasssword,@FullName,@EmailId,@City,@Phone)";

                cmdInsert.Parameters.AddWithValue("@LoginName", user.LoginName);
                cmdInsert.Parameters.AddWithValue("@Password", user.Password);
                cmdInsert.Parameters.AddWithValue("@ConPasssword", user.ConPasssword);
                cmdInsert.Parameters.AddWithValue("@FullName", user.FullName);
                cmdInsert.Parameters.AddWithValue("@EmailId", user.EmailId);
                cmdInsert.Parameters.AddWithValue("@City", user.City);
                cmdInsert.Parameters.AddWithValue("@Phone", user.Phone);

                cmdInsert.ExecuteNonQuery();
                cn.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
