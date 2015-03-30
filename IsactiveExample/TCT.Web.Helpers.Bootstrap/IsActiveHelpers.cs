using System;
using System.Web;
using System.Web.Mvc;

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

        ///// <summary>
        ///// return active class if action is current
        ///// </summary>
        ///// <param name="htmlHelper"></param>
        ///// <param name="action"></param>
        ///// <param name="activeClass"></param>
        ///// <param name="inActiveClass"></param>
        ///// <returns></returns>
        //public static MvcHtmlString IsActive(this HtmlHelper htmlHelper, string action, string activeClass, string inActiveClass = "")
        //{
        //    var routeData = htmlHelper.ViewContext.RouteData;

        //    var routeAction = routeData.Values["action"].ToString();

        //    var returnActive = (action == routeAction);

        //    return new MvcHtmlString(returnActive ? activeClass : inActiveClass);
        //}

        ///// <summary>
        ///// return active class if action is current
        ///// </summary>
        ///// <param name="htmlHelper"></param>
        ///// <param name="action"></param>
        ///// <param name="activeClass"></param>
        ///// <returns></returns>
        //public static MvcHtmlString IsActive(this HtmlHelper htmlHelper, string action, string activeClass)
        //{
        //    return IsActive(htmlHelper, action, activeClass);
        //}

    }
}
