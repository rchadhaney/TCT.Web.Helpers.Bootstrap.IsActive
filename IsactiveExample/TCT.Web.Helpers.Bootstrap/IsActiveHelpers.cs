using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TCT.Web.Helpers.Bootstrap
{
    public static class IsActiveHelpers
    {

        /// <summary>
        /// Returns the active class when action/controller is true
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        /// <param name="activeClass"></param>
        /// <param name="inActiveClass"></param>
        /// <returns></returns>
        public static MvcHtmlString IsActive(this HtmlHelper htmlHelper, string action, string controller, string activeClass, string inActiveClass = "")
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var routeAction = routeData.Values["action"].ToString();
            var routeController = routeData.Values["controller"].ToString();

            var returnActive = (controller == routeController && action == routeAction);

            return new MvcHtmlString(returnActive ? activeClass : inActiveClass);
        }
        /// <summary>
        /// Returns the active class when action/controller is true
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        /// <param name="activeClass"></param>
        /// <returns></returns>
        public static MvcHtmlString IsActive(this HtmlHelper htmlHelper, string action, string controller, string activeClass)
        {
            return IsActive(htmlHelper, action, controller, activeClass, "");
        }

        /// <summary>
        /// Returns the active class when action/controller/area is true
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        /// <param name="routeValues"></param>
        /// <param name="activeClass"></param>
        /// <param name="inActiveClass"></param>
        /// <returns></returns>
        public static MvcHtmlString IsActive(this HtmlHelper htmlHelper, string action, string controller, object routeValues,
            string activeClass, string inActiveClass = "")
        {
            var routeData = htmlHelper.ViewContext.RouteData;
            var routeTokens = htmlHelper.ViewContext.RouteData.DataTokens;

            var routeAction = routeData.Values["action"].ToString().ToLower();
            var routeController = routeData.Values["controller"].ToString().ToLower();

            //Get routevalue properties.
            var rvProps = routeValues.GetType().GetProperties();

            var pass = true;
            if(rvProps.Count() > 0)
            {
                foreach(var rv in rvProps)
                {
                    if(routeData.Values[rv.Name.ToString()] != null)
                    {
                        var rd = routeData.Values[rv.Name.ToString()].ToString();
                        var rvValue = rv.GetValue(routeValues);
                        if (rd.ToLower() != rvValue.ToString().ToLower())
                        {
                            pass = false;
                        }
                    }
                    if(routeTokens.ContainsKey(rv.Name.ToString()))
                    {
                        var rt = routeTokens[rv.Name.ToString()].ToString();
                        var rvValue = rv.GetValue(routeValues);
                        if(rt.ToLower() != rvValue.ToString().ToLower())
                        {
                            pass = false;
                        }
                    }
                }
            }

            //Update to allow no action to be passed.
            var returnActive = (controller.ToLower() == routeController && (action == null || action.ToLower() == routeAction ) && pass);

            return new MvcHtmlString(returnActive ? activeClass : inActiveClass);
        }

        /// <summary>
        /// return active class if action is current
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="action"></param>
        /// <param name="activeClass"></param>
        /// <returns></returns>
        public static MvcHtmlString IsActive(this HtmlHelper htmlHelper, string action, string activeClass)
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var routeAction = routeData.Values["action"].ToString();

            var returnActive = (action.ToLower() == routeAction.ToLower());

            return new MvcHtmlString(returnActive ? activeClass : "");
        }

    }
}
