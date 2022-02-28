using SohanSirZindabad.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SohanSirZindabad.Controllers
{
    public class ProductController : Controller
    {

        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamPrep;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        // GET: Product
        public ActionResult Index()
        {
            //select ProductId,ProductName,Rate,Description,CategoryName from Products natural join Categories where Products.CategoryId=Categories.CategoryId
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Product";
            List<Product> plist = new List<Product>();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    plist.Add(new Product {ProductId=(int)dr["ProductId"],ProductName=(string)dr["ProductName"],Rate=(decimal)dr["Rate"],Description=(string)dr["Description"],CategoryId=(int)dr["CategoryId"] });

                }
                dr.Close();

            }
            catch (Exception ex)
            {
                ViewBag.err = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return View(plist);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.list = GetCategories();
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product prd)
        {

            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into Product values(@ProductName,@Rate,@Description,@CategoryId)";

            cmd.Parameters.AddWithValue("@ProductName",prd.ProductName);
            cmd.Parameters.AddWithValue("@Rate", prd.Rate);
            cmd.Parameters.AddWithValue("@Description", prd.Description);
            cmd.Parameters.AddWithValue("@CategoryId", prd.CategoryId);

            try
            {
                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.err = ex;
                return View();
            }
            finally {

                conn.Close();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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

        public IEnumerable<Categories> GetCategories()
        {
            List<Categories> list1 = new List<Categories>();

            conn.Open();
            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Categories";

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list1.Add(new Categories {CategoryId=(int)dr["CategoryId"],CategoryName=(string)dr["CategoryName"] });
                }
                dr.Close();
            } catch (Exception ex)
            {
                ViewBag.err = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return list1;
        }
    }
}
