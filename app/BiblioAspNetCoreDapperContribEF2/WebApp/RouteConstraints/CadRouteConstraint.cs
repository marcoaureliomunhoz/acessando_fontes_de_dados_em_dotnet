using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApp.RouteConstraints
{
    public class CadRouteConstraint : IRouteConstraint
    {
        private readonly string padraoRegex;

        public CadRouteConstraint(string padraoRegex)
        {
            this.padraoRegex = padraoRegex;
        }

        public bool Match(HttpContext httpContext, 
                          IRouter route, 
                          string routeKey, 
                          RouteValueDictionary values, 
                          RouteDirection routeDirection)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            if (route == null)
            {
                throw new ArgumentNullException(nameof(route));
            }

            if (routeKey == null)
            {
                throw new ArgumentNullException(nameof(routeKey));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            object routeValue;

            if (values.TryGetValue(routeKey, out routeValue) && routeValue != null)
            {
                string parametros = Convert.ToString(routeValue, CultureInfo.InvariantCulture);

                return Regex.Match(parametros, padraoRegex).Success;
            }

            return true;
        }
    }
}
