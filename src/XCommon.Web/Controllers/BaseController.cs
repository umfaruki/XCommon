﻿using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using XCommon.Application;
using XCommon.Application.Login;
using XCommon.Extensions.String;
using XCommon.Patterns.Ioc;

namespace XCommon.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            Kernel.Resolve(this);

            if (Ticket != null)
            {
                if (Ticket.Culture.IsEmpty())
				{
					return;
				}

				CultureInfo.CurrentCulture = new CultureInfo(Ticket.Culture);
                CultureInfo.CurrentUICulture = new CultureInfo(Ticket.Culture);
            }
        }

        [Inject(forceResolve: false)]
        protected ITicketManager Ticket { get; private set; }

        [Inject(forceResolve: false)]
        protected IApplicationSettings ApplicationSettings { get; private set; }
    }
}
