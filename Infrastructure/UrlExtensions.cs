using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Aubrey Farnbach(Wright) Section 2 Group 2

namespace Project5.Infrastructure
{
    public static class UrlExtensions
    {
        //If request has value then set it to request path in the query string, otherwise path to string
        public static string PathAndQuery (this HttpRequest request) =>
            request.QueryString.HasValue ? $"(request.Path)(request.QueyString)" : request.Path.ToString();
    }
}
