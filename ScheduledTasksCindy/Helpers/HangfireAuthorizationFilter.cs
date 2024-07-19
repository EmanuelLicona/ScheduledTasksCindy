﻿using Hangfire.Annotations;
using Hangfire.Dashboard;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduledTasksCindy.Helpers
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {


            var httpContext = context.GetHttpContext();

            // Allow all authenticated users to see the Dashboard (potentially dangerous).
            //return httpContext.User.Identity?.IsAuthenticated ?? false;
            return true;
        }
    }
}