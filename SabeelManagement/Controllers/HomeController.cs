using DataAccessLayer;
using DataAccessLayer.Domain;
using Microsoft.AspNetCore.Mvc;
using SabeelManagement.Models;
using System.Diagnostics;

namespace SabeelManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MySqlContext _dbContext;

        public HomeController(ILogger<HomeController> logger, MySqlContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SabeelRegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var areaCode = model.AreaId; // or "TR"
            var defaultStartingNumber = 32000;
            var maxNumber = 0;
            // Find the highest number for the specified area code
            try
            {
                var res = _dbContext.Registration
                            .Where(e => e.AreaCode == areaCode.ToString())
                            .Select(e => e.RegistrationNumber).DefaultIfEmpty();


                if (res.Any())
                {
                    maxNumber = res.Max();
                }

                if (maxNumber == 0)
                    maxNumber = defaultStartingNumber;
            }
            catch (Exception ex)
            {

                //maxNumber = defaultStartingNumber;
            }

            // Increment the number for the new entry
            var newEntry = new Registration
            {
                AreaCode = areaCode.ToString(),
                RegistrationNumber = maxNumber + 1,
                Address = model.Address,
                CNIC = model.CNIC,
                SabeelName = model.SabeelName,
                MobileNumber = model.MobileNumber,
                OrganizationName = model.OrganizationName
            };

            _dbContext.Registration.Add(newEntry);
            _dbContext.SaveChanges();

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
    }
}