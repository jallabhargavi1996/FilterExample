using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyFiltersExamples.CustomFilters
{
    public class ActionandResultFilters:ActionFilterAttribute
    {

        string path = @"C:\Users\user\source\repos\MyFiltersExamples\MyFiltersExamples\CustomFilters\Log.txt";
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"{ context.HttpContext.Request.Path.Value} Ending");
            }
            
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"{ context.HttpContext.Request.Path.Value} starting");
            }
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                var output = (ObjectResult)context.Result;
                sw.WriteLine(output.Value + "" + "Ending");
                //sw.WriteLine((ObjectResult)context.Result);
            }

        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                var output = (ObjectResult)context.Result;
                sw.WriteLine($"{output.Value} Staring");
                //sw.WriteLine((ObjectResult)context.Result);
            }
        }
    }
}
