using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lib.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Areas.Admin.Controllers
{
    //[Area("Admin")]
    //[Produces("application/json")]
    //[Route("api/Admin/[controller]/[Action]")]
    //[ApiController]
    public class ValuesController : Controller
    {
        //private AppDbContext _db;

        ////internal AppDbConnection _Db { get; set; }

        //public ValuesController(AppDbContext db)
        //{
        //    _db = db;
        //}

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        ////[Produces(typeof(CustomJsonResult))]
        //public async Task<IActionResult> GetUser()
        //{
        //    CustomJsonResult resultCustom = new CustomJsonResult();
        //    resultCustom.Result = _db.AppUsers.Where(x => x.UserName == "Tan").ToString();
        //    return Json(resultCustom);
        //}
    }
}