﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    public class MessageController : Controller
    {//mesajlaşma işlemi için
        public IActionResult Index()
        {
            return View();
        }
    }
}
