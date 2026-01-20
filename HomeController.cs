using Paper.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paper.Controllers
{
    public class HomeController : Controller
    {

        int catid;
        public ActionResult Index()
        {
            var category = getcategory();

            DataTable dt = new DataTable();

            ViewBag.category = new SelectList(category.AsDataView(), "CategoryID", "CategoryName");
            ViewBag.product = new SelectList(new DataTable().AsDataView(), "ProductID", "ProductName");


            return View();
        }

        [HttpPost]
        public ActionResult Index(PaperModel obj)
        {
            catid = obj.CategoryID;

            var category = getcategory();

            var product = getproduct();

            ViewBag.category = new SelectList(category.AsDataView(), "CategoryID", "CategoryName");
            ViewBag.product = new SelectList (product.AsDataView(), "ProductID", "ProductName");

            decimal amount = obj.Amount;
            decimal tax = obj.Tax;


            SqlConnection conn = new SqlConnection();
            String query = ""; 






            return View();
        }

        public DataTable getcategory()
        {
            string cnn = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            SqlConnection con = new SqlConnection(cnn);

            SqlDataAdapter adb = new SqlDataAdapter("Select * from TblCategory", con);
            DataTable dt = new DataTable();
            adb.Fill(dt);
            return dt;

        }


        public DataTable getproduct()
        {
            string cnn = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            SqlConnection con = new SqlConnection(cnn);

            SqlDataAdapter adb = new SqlDataAdapter("Select * from TblProduct where CategoryID ='"+catid+"'", con);
            DataTable dt = new DataTable();
            adb.Fill(dt);
            return dt;

        }



    }
}