using Microsoft.AspNetCore.Mvc;
using ResponseSystem.Business;
using ResponseSystem.WebApp.Models;
using System.Diagnostics;

namespace ResponseSystem.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IResponseDetails _responseDetails;

        public HomeController(ILogger<HomeController> logger, IResponseDetails responseDetails)
        {
            _logger = logger;
            _responseDetails= responseDetails;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public IActionResult Index(string inputtext)
        {
            ResponseViewModel vm;
            try
            {
                vm = new ResponseViewModel();
                var parsedObj =  _responseDetails.ParseResponse(inputtext);
               
                    vm = new ResponseViewModel() { alarmNo = parsedObj.alamNo, ResponseMsg = parsedObj.message, serverNo = parsedObj.serverNo };
                    return View(vm);
               
               
            }
            catch (Exception ex)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier , ErrorMsg = ex.Message  });
            }
            
        }
    }
}