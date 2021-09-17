﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorAppointmentSystem.Models;
namespace DoctorAppointmentSystem.Controllers
{
    public class DoctorLoginController : Controller
    {
        SystemEntities db = new SystemEntities();
        // GET: DoctorLogin
        public ActionResult Index(string errorMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            return View("Login");
        }
        
        public RedirectToRouteResult Login(string email, string password)
        {
            var doctor = db.Doctors.Where(c => c.email == email && c.password == password).FirstOrDefault();
            if (doctor == null)
            {
                return RedirectToAction("Index", new { errorMessage = "email or password is not correct!"});
            }
            Session["doctorId"] = doctor.id;
            return RedirectToAction("Index", "Home");
        }
        public RedirectToRouteResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        
    }
}