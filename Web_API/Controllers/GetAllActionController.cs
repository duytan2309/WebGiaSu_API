using Lib.Domain.EF;
using Lib.Domain.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Lib.Data.Entities;

namespace Web_API.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class GetAllActionController : Controller
    {
        private AppDbContext _db;
        public GetAllActionController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = nameof(GetAllAction))]
        [Produces(typeof(CustomJsonResult))]
        public IActionResult GetAllAction()
        {
            try
            {
                var result = new CustomJsonResult();
                Assembly asm = Assembly.GetExecutingAssembly();

                var controlleractionlist = asm.GetTypes()

                        .Where(type => typeof(Microsoft.AspNetCore.Mvc.Controller).IsAssignableFrom(type))
                        .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                        .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                        .Select(x => new
                        {
                            Area = x.DeclaringType.Namespace.Replace("Web_API", "").Replace("Areas", "").Replace("Controllers", "").Replace(".", ""),
                            Controller = x.DeclaringType.Name.Replace("Controller", ""),
                            Action = x.Name,
                            ReturnType = x.ReturnType.Name,
                            Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", "")))
                        })
                        .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();

                foreach (var item in controlleractionlist)
                {
                    var apiId = (item.Area != "" && item.Area != null) ? item.Area + "-" + item.Controller + "-" + item.Action
                            : item.Controller + "-" + item.Action;
                    var link = (item.Area != "" && item.Area != null) ? item.Area + "/" + item.Controller + "/" + item.Action
                       : item.Controller + "/" + item.Action;

                    var checkExist = _db.ApiUrl.Where(x => x.ApiId == apiId).FirstOrDefault();
                    if (checkExist != null)
                    {
                        if (checkExist.Attributes != item.Attributes)
                        {
                            checkExist.Attributes = item.Attributes;
                            _db.ApiUrl.Update(checkExist);
                            _db.SaveChanges();
                        }
                    }


                    ApiUrl apiUrlNew = new ApiUrl()
                    {
                        Id = Guid.NewGuid(),
                        ApiId = apiId,
                        Link = link,
                        Area = item.Area,
                        Controller = item.Controller,
                        Action = item.Action,
                        ReturnType = item.ReturnType
                    };

                    _db.ApiUrl.Add(apiUrlNew);
                    _db.SaveChanges();
                }






                result.Result = controlleractionlist;
                result.StatusCode = 200;
                return Json(result);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }

        }
    }
}
