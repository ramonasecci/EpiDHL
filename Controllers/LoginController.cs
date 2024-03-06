using EpiDHL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EpiDHL.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            {
                if (HttpContext.User.Identity.IsAuthenticated) return RedirectToAction("Index","Spedizioni");
                return View();
            }           
        }

        [HttpPost]
        public ActionResult Index(User user, bool keepLogged)
        {
            try
            {
                DB.conn.Open();
                var command = new SqlCommand(@"
                SELECT *
                FROM Users
                WHERE Email = @email AND Password = @password
            ", DB.conn);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@password", user.Password);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    FormsAuthentication.SetAuthCookie(reader["User_ID"].ToString(), keepLogged);
                    return RedirectToAction("Index", "Spedizioni"); // TODO: alla pagina di pannello
                }
            }
            catch
            {
               
            }
            finally {  DB.conn.Close(); }

            TempData["ErrorLogin"] = true;
            return RedirectToAction("Index");

        }

        //Logout
        [Authorize, HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        //Insert user Register
        public ActionResult Register()
        {
            {
                if (HttpContext.User.Identity.IsAuthenticated) return RedirectToAction("Index", "Spedizioni");
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            // verificare se tutti i campi sono validi
            if (ModelState.IsValid)
            {
                try
                {
                    DB.conn.Open();
                    var command = new SqlCommand(@"
                    INSERT INTO Users
                    (Email, Password)
                    VALUES (@email, @password)
                ", DB.conn);
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@password", user.Password);
                    var countRows = command.ExecuteNonQuery();
                    return RedirectToAction("Index","Spedizioni");
                }catch 
                {
                }finally { DB.conn.Close(); }
             
            }
            // se almeno un campo non è valido si restituisce la view che presenterà anche gli errori
            // NO redirect in questo caso
            return View();
        }








    }
}