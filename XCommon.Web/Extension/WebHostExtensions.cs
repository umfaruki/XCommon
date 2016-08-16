﻿#if NET451
using Microsoft.AspNetCore.Hosting;
using System.ServiceProcess;
using XCommon.Web.Application.WindowsService;
#endif

namespace XCommon.Web
{

    public static class WebHostExtensions
    {
#if NET451
        public static void RunAsCustomService(this IWebHost host)
        {
            var webHostService = new ApplicationHostService(host);
            ServiceBase.Run(webHostService);
        }
#endif
    }

}