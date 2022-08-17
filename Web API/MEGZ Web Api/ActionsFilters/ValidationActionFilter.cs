//using Microsoft.AspNetCore.Mvc.Filters;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;


//namespace MEGZ_Web_Api.ActionsFilters
//{
//    public class ValidationActionFilter : Attribute, IActionFilter
//    {
//        public void OnActionExecuted(ActionExecutedContext context)
//        {
//            throw new NotImplementedException();
//        }

//        public void OnActionExecuting(ActionExecutingContext context)
//        {
//            if (!context.ModelState.IsValid)
//            {
//                context.HttpContext.Response.StatusCode = 100;
//            }
//        }
//    }
//}
