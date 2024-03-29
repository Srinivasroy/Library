﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;
using System.Security.Cryptography;
using System.Text;
using System.Net;


namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private Entity db = new Entity();

   

        public ActionResult Index()
        {
          
            return View();

        }



        public ActionResult Welcome()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        public ActionResult Welcome1()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Login user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Login.FirstOrDefault(s => s.Email == user.Email);
                if (check == null)
                {
                    user.Password = GetMD5(user.Password);
                    user.ConfirmPassword = GetMD5(user.ConfirmPassword);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Login.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
               
                    var f_password = GetMD5(userLogin.Password);
                var data =db.Login.Where(s => s.Email.Equals(userLogin.Email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() == 1)
                {

                    if (data[0].Epic == 0)
                    {


                        // User
                        Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                        Session["Email"] = data.FirstOrDefault().Email;
                        Session["Id"] = data.FirstOrDefault().Id;
                        return RedirectToAction("Welcome1");
                    }
                    // Admin
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["Id"] = data.FirstOrDefault().Id;
                    return RedirectToAction("Welcome");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    //return RedirectToAction("Login");
                }
            }
            return View();
        }


       
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        //Contact
        public ActionResult ContactUs()
        {
            return View();
        }

        //About Us
        public ActionResult About()
        {
            return View();
        }


        //Encrypt Password
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }




    }
}