﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    public class ProfileController : Controller
    {//şifre düzenleme gibi işlemler burada olacak
        public IActionResult Index()
        {
            return View();
        }
    }
}
