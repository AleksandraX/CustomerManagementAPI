﻿using System.Linq;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomerManagementPortal.Api.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        private readonly ILoggerManager _logger;

        public ValidationFilterAttribute(ILoggerManager logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];

            var param = context.ActionArguments
                .SingleOrDefault(x =>
                    x.Value.ToString().Contains("Dto")).Value;

            if (param == null)
            {
                _logger.LogError($"Object sent from client is null. Controller: {controller}, action: { action}");
                context.Result = new BadRequestObjectResult($"Object is null. Controller: { controller }, action: { action}");
                return;
            }

            if (!context.ModelState.IsValid)
            {
                _logger.LogError($"Invalid model state for the object. Controller: { controller}, action: { action}");
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }

        }
    }
}
