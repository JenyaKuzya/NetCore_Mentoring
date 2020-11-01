﻿using Microsoft.AspNetCore.Builder;
using NetCore_Mentoring.API.Models;

namespace NetCore_Mentoring.API.Extensions
{
    public static class ExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware(typeof(ExceptionHandlerMiddleware));
    }
}
