using Lock_Unlock_APP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lock_Unlock_APP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult LockUnLockDetails()
        {
            return View();
        }

        public IActionResult LockHistory()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LockHistoryData()
        {
            List<Macro_Fack.History> histories = new List<Macro_Fack.History>();
            IEnumerable<string[]> result = null;
            try
            {
                histories = Macro_Fack.Macro.GetHeaders();
                result = from c in histories
                         select new[] {

                                              c.UserName,
                                              c.Lock_Unlock,
                                              c.CreateDate.ToString("dd-MM-yyyy hh:mm tt"),
                           c.Id.ToString()};

            }
            catch (Exception ex)
            {

            }
            return Json(new
            {
                sEcho = 0,
                iTotalRecords = histories.Count(),
                iTotalDisplayRecords = histories.Count(),
                aaData = result
            });
        }
 
        [HttpGet]
        public IActionResult DetailsById(int id)
        {
           var details = Macro_Fack.Macro.GetDetailsById(id);
            var result = from c in details
                         select new[] {

                                              c.Division,
                                              c.ProfileName,
                                              c.LockUnlock_Status,
                            c.CreateDate.ToString("dd-MM-yyyy hh:mm tt")};
            return Json(new
            {
                sEcho = 0,
                iTotalRecords = details.Count(),
                iTotalDisplayRecords = details.Count(),
                aaData = result
            });
        }

        [HttpGet]
        public IActionResult Details()
        {
            var details = Macro_Fack.Macro.GetDetails();
            var result = from c in details
                         select new[] {

                                              c.Division,
                                              c.ProfileName,
                                              c.LockUnlock_Status,
                            c.CreateDate.ToString("dd-MM-yyyy hh:mm tt")};
            return Json(new
            {
                sEcho = 0,
                iTotalRecords = details.Count(),
                iTotalDisplayRecords = details.Count(),
                aaData = result
            });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
