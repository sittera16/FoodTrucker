﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrucker.WebMVC.Controllers
{
    public class MenuItemController : Controller
    {
        // GET: MenuItem
        public ActionResult Index()
        {
            return View();
        }
    }
}