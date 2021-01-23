using System;
using System.Threading.Tasks;
using Lib.Domain.EF;
using Lib.Domain.Proceduce.Interfaces;
using Lib.Domain.Utilities;
using Lib.Domain.ViewModel.Test;
using Microsoft.AspNetCore.Mvc;
namespace Web_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class HomeController : Controller
    {
        private AppDbContext _db;
        ITestInterface _test;
        public HomeController(AppDbContext db, ITestInterface test)
        {
            _db = db;
            _test = test;
        }

        [HttpPost(Name = nameof(Index))]
        [Produces(typeof(CustomJsonResult))]
        public IActionResult Index([FromBody] ColorViewModel model)
        {
            var resultCustom = new CustomJsonResult();
            var result = _test.TestData(model);
            resultCustom.StatusCode = 200;
            resultCustom.Message = "Thành Công!";
            resultCustom.Result = result;
            return Json(resultCustom);
        }
    }
}