using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _Statistics:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.v1 = c.Destinations.Count(); //tur sayısı
            ViewBag.v2 = c.Guides.Count();//rehber sayısı
            ViewBag.v3 = "285"; //Müşteri sayısı
            return View();
        }
    }
}
