using System.Text.RegularExpressions;

namespace RouteParameters.CustomConstraints
{
    // e.g.: sales-report/2020/apr
    public class MonthsCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            // check whether the value exists
            if (!values.ContainsKey(routeKey)) //month
            {
                return false;
            }
            else
            {
                Regex regex = new("^(apr|jul|oct|jan)$");
                string? monthValue = Convert.ToString(values[routeKey]);
                if (monthValue != null && regex.IsMatch(monthValue))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
