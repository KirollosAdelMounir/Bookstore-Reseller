using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;


namespace Online_BookStore.Controllers
{
    

    public class HomeController : Controller
    {

        Random rnd = new Random();
        public string username;
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;


        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Login()
        {
            return View("Login");
        }
        void connectionString()
        {
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Source Codes\\Third Trial\\OnlineBookReseller.mdf;Integrated Security=True;Connect Timeout=30";
        }
        [HttpPost]
        public ActionResult Verify(FormCollection form)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select userID from Users where Email ='" + form["username"] + "' and Password ='" + form["password"] + "'";
            dr = com.ExecuteReader();
            
            if (dr.Read())
            {
              
                Session["username"] = form["username"];
                username = form["username"];
               

                return RedirectToAction("Index");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }

        public ActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "insert into Users Values('"+rnd.Next(1000,100000)+"','"+form["Email"]+"','"+form["password"]+"','"+form["gender"]+"','"+form["dateofbirth"]+"','"+form["interests"]+"',1,NULL,'"+form["phonenumber"]+"')";
            dr = com.ExecuteReader();
            Session["username"] = form["Email"];
           
            return RedirectToAction("Index");
        }
        public ActionResult ViewBooks()
        {
            if (Session["username"]!=null)
            {
                return View("ViewBooks");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult AccountSettings()
        {
            if (Session["username"] !=null) {
                return View("AccountSettings");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult deletemyaccount()
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "delete from Users where Email = '"+Session["username"].ToString()+"'";
            dr = com.ExecuteReader();
            Session.Abandon();
            return RedirectToAction("Index");
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        public ActionResult ViewTransaction()
        {
            return View("ViewTransaction");
        }
        public ActionResult AddNewBook()
        {
            if (Session["username"] != null)
            {
                return View("AddNewBook");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public ActionResult AddNewBook(FormCollection form)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "insert into Books Values('" + rnd.Next(1000, 100000) + "','" + form["BookName"] + "','" + form["BookCategory"] + "','" + form["Author"] + "','" + form["dateofproduction"] + "','" + form["price"] + "',1,NULL)";
            dr = com.ExecuteReader();
            ViewBag.messagebook = "Book Added";

            return View("AddNewBook");
        }
        public ActionResult ViewUsers()
        {
            OnlineBookResellerEntities1 entities1  = new OnlineBookResellerEntities1();

            
            return View(entities1.Users.ToList());
        }

    }


}