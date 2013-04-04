using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Ideascape.Bootstrap.Html
{
    public static class MenuExtensions
    {
        public static IHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, bool activeByControllerOnly = false)
        {
            var action = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            var controller = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            var strCmp = StringComparer.OrdinalIgnoreCase;
            var test = strCmp.Equals(controllerName, controller) && (activeByControllerOnly || strCmp.Equals(actionName, action));

            var listItem = new TagBuilder("li")
            {
                Attributes = {
                    { "class", test ? "active" : "" }
                },
                InnerHtml = htmlHelper.ActionLink(linkText, actionName, controllerName).ToHtmlString()
            };

            return MvcHtmlString.Create(listItem.ToString());
        }
    }
}