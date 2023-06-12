using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        private readonly IDestinationService _destinationService;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }
        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TAdd(destination); //ekleme işlemi
            var values= JsonConvert.SerializeObject(destination); //json'a dönüştürme
            return Json(destination);// json döndürme
        }

        public IActionResult GetById(int DestinationID)
        {
            var values = _destinationService.TGetByID(DestinationID);
            var jsonvalues = JsonConvert.SerializeObject(values);
            return Json(jsonvalues);
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return NoContent();
        }

        public IActionResult UpdateCity(Destination destination)
        {
            var values = _destinationService.TGetByID(destination.DestinationID);
            destination.Status = values.Status;
            destination.Price = values.Price;
            destination.Image = values.Image;
            destination.Description = values.Description;
            destination.Capacity = values.Capacity;
            destination.CoverImage = values.CoverImage;
            destination.Details1 = values.Details1;
            destination.Details2 = values.Details2;
            destination.Image2 = values.Image2;
            _destinationService.TUpdate(destination);
            var v = JsonConvert.SerializeObject(destination);
            return Json(v);
        }

        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass
        //    {
        //        CityID=1,
        //        CityName="Üsküp",
        //        CityCountry="Makedonya"
        //    },
        //    new CityClass
        //    {
        //         CityID=2,
        //        CityName="Roma",
        //        CityCountry="İtalya"
        //    },
        //     new CityClass
        //     {
        //         CityID=3,
        //        CityName="Londra",
        //        CityCountry="İngiltere"
        //     }
        //};

    }
}
