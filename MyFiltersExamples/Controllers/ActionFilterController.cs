using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFiltersExamples.CustomFilters;


namespace MyFiltersExamples.Controllers
{
    [Route("api/actionFilter")]
    [ApiController]
    public class ActionFilterController : ControllerBase
    {
        [Route("FilterExample")]
        [HttpGet]
        [ActionandResultFilters]
        [ExceptionFilter]
        public dynamic GetValues()
        {
            var obj = new
            {
                name = "Bhargavi",
                college = "Svce",
                Branch = "EEE"
            };
            return obj;
        }
        [HttpGet]
        [ExceptionFilter]
        public string Getdata()
        {
            throw new Exception(" this is not throw exception");
        }
        [Route("getdate")]
        [HttpGet]
        [OutputCache(Duration=10)]
        public string Index()
        {
            return DateTime.Now.ToString();
        }
    }
}
