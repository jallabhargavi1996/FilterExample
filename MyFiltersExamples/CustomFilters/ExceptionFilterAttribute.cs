using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyFiltersExamples.CustomFilters
{
    public class ExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        string path = @"C:\Users\user\source\repos\MyFiltersExamples\MyFiltersExamples\CustomFilters\Log.txt";

        public void OnException(ExceptionContext context)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(context.Exception.Message);
                sw.WriteLine(context.Exception.StackTrace);

            }
        }
    }
}
