using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")] //bu attribute'ü vermezsek index hata verir
    [AllowAnonymous]
    public class CommentController : Controller
    {// yorumlar
        public IActionResult Index()
        {
            return View();
        }
    }
}
