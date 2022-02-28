using ProductProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductProject.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<MyProductList> list = new List<MyProductList>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Practice;Integrated Security=True";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Products,Categories where Products.CategoryId = Categories.CategoryId";

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new MyProductList { ProductId = (int)dr["ProductId"], ProductName = dr["ProductName"].ToString(), Rate = (decimal)dr["Rate"], Description = (string)dr["Description"], CategoryName = (string)dr["CategoryName"] });
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
            }
            finally
            {
                cn.Close();
            }

            return View(list);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Categories = GetCList();
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Practice;Integrated Security=True";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update Products set  ProductName=@ProductName, Rate=@Rate, Description=@Description, CategoryId= @CategoryId where ProductId = @ProductId";
            cmd.Parameters.AddWithValue("ProductId", id);
            cmd.Parameters.AddWithValue("ProductName", obj.ProductName);
            cmd.Parameters.AddWithValue("Rate", obj.Rate);
            cmd.Parameters.AddWithValue("Description", obj.Description);
            cmd.Parameters.AddWithValue("CategoryId", obj.CategoryId);
           
            try
            {
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex;
            }
            finally
            {
                cn.Close();
            }

            return View();
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
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

        public List<Category> GetCList()
        {
            List<Category> list = new List<Category>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Practice;Integrated Security=True";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from Categories";

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Category { CategoryId = (int)dr["CategoryId"], CategoryName = dr["CategoryName"].ToString() });
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
            }
            finally
            {
                cn.Close();
            }

            return list;
        }

        [ChildActionOnly]
        public ActionResult MyViewe()
        {
            return View();
        }
    }
}
