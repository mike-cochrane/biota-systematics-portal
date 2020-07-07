﻿using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystematicsPortal.Web.Api.Helpers
{
    public static class LogHelper
    {
        public static void EnrichFromRequest(IDiagnosticContext diagnosticContext, HttpContext httpContext)
        {
            if (diagnosticContext != null && httpContext != null)
            {
                var request = httpContext.Request;

                // Set all the common properties available for every request
                diagnosticContext.Set("Host", request.Host);
                diagnosticContext.Set("Protocol", request.Protocol);
                diagnosticContext.Set("Scheme", request.Scheme);

                // Only set it if available. You're not sending sensitive data in a querystring right?!
                if (request.QueryString.HasValue)
                {
                    diagnosticContext.Set("QueryString", request.QueryString.Value);
                }
                if (request.ContentLength.HasValue)
                {
                    diagnosticContext.Set("ContentLength", request.ContentLength.Value);
                }

                // Set the content-type of the Response at this point
                diagnosticContext.Set("ContentType", httpContext.Response.ContentType);

                // Retrieve the IEndpointFeature selected for the request
                var endpoint = httpContext.GetEndpoint();
                if (endpoint is object) // endpoint != null
                {
                    diagnosticContext.Set("EndpointName", endpoint.DisplayName);
                }
            }
        }
    }
}
