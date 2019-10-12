using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Avassy.AspNetCore.Mvc.Extensions
{
    public static class CookieAuthenticationOptionsExtensions
    {
        public static void OverrideRedirectToAccessDeniedByStatusCode(this CookieAuthenticationOptions options, HttpStatusCode statusCode, params string[] urlsToOverride)
        {
            options.Events.OnRedirectToAccessDenied = context =>
            {
                var mustOverride = false;

                foreach (var url in urlsToOverride)
                {
                    mustOverride = context.Request.Path.StartsWithSegments($"{(url.StartsWith('/') ? url : $"/{url}")}");

                    if (mustOverride)
                    {
                        break;
                    }
                }

                if (mustOverride)
                {
                    context.Response.StatusCode = (int)statusCode;
                }

                return Task.CompletedTask;
            };
        }

        public static void OverrideRedirectToLoginByStatusCode(this CookieAuthenticationOptions options, HttpStatusCode statusCode, params string[] urlsToOverride)
        {
            options.Events.OnRedirectToLogin = context =>
            {
                var mustOverride = false;

                foreach (var url in urlsToOverride)
                {
                    mustOverride = context.Request.Path.StartsWithSegments($"{(url.StartsWith('/') ? url : $"/{url}")}");

                    if (mustOverride)
                    {
                        break;
                    }
                }

                if (mustOverride)
                {
                    context.Response.StatusCode = (int)statusCode;
                }

                return Task.CompletedTask;
            };
        }

        public static void OverrideRedirectToLogoutByStatusCode(this CookieAuthenticationOptions options, HttpStatusCode statusCode, params string[] urlsToOverride)
        {
            options.Events.OnRedirectToLogout = context =>
            {
                var mustOverride = false;

                foreach (var url in urlsToOverride)
                {
                    mustOverride = context.Request.Path.StartsWithSegments($"{(url.StartsWith('/') ? url : $"/{url}")}");

                    if (mustOverride)
                    {
                        break;
                    }
                }

                if (mustOverride)
                {
                    context.Response.StatusCode = (int)statusCode;
                }

                return Task.CompletedTask;
            };
        }
        public static void OverrideRedirectToReturnUrlByStatusCode(this CookieAuthenticationOptions options, HttpStatusCode statusCode, params string[] urlsToOverride)
        {
            options.Events.OnRedirectToReturnUrl = context =>
            {
                var mustOverride = false;

                foreach (var url in urlsToOverride)
                {
                    mustOverride = context.Request.Path.StartsWithSegments($"{(url.StartsWith('/') ? url : $"/{url}")}");

                    if (mustOverride)
                    {
                        break;
                    }
                }

                if (mustOverride)
                {
                    context.Response.StatusCode = (int)statusCode;
                }

                return Task.CompletedTask;
            };
        }
    }
}
