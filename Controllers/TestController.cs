﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace genetrix.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Chat()
        {
            return View();
        }

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
    }
}