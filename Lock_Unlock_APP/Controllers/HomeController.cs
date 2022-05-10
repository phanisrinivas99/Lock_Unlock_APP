using Lock_Unlock_APP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static Lock_Unlock_APP.Models.SampleData;

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
        public IActionResult CreateHeader()
        {
            return View();
        }
        public IActionResult CreateDetail()
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
        public JsonResult GetHeaders()
        {
           var  histories = Macro_Fack.Macro.GetHeaders();
            return Json(histories);
        }
        [HttpGet]
        public IActionResult HistoryData()
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
        [HttpPost]
        public async Task<IActionResult> InsertHeader(string status,string userName)
        {
            var id =await Macro.CreateHeader(status, userName);
            return Json(id);
        }
        [HttpPost]
        public async Task<IActionResult> InsertDetails(string status, string ProfileName, string division, int headerId)
        {
            var id =await Macro.CreateDetails(status, ProfileName, division, headerId);
            return Json(id);
        }
        [HttpGet]
        public IActionResult UpdateStatus(int id)
        {
            try
            {
                var details = Macro.UpdateStatus(id);
            }
            catch(Exception ex)
            {

            }
        
            return Json("Success");
        }

        //[HttpGet]
        //public IActionResult UpdateStatus()
        //{
        //    try
        //    {
        //        var details = Macro.UpdateStatus();
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return Json("Success");
        //}
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
