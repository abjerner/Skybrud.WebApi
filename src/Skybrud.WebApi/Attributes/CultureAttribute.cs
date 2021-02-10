using System.Globalization;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Skybrud.WebApi.Attributes {

    /// <summary>
    /// Attribute used for setting the culture used for a WebAPI controller or method.
    /// </summary>
    public class CultureAttribute : ActionFilterAttribute {

        /// <summary>
        /// Gets the culture.
        /// </summary>
        public CultureInfo Culture { get; }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="cultureName"/>.
        /// </summary>
        /// <param name="cultureName">The name of the culture - eg. <c>da-DK</c>.</param>
        public CultureAttribute(string cultureName) {
            Culture = CultureInfo.GetCultureInfo(cultureName);
        }

        /// <inheritdoc />
        public override void OnActionExecuting(HttpActionContext actionContext) {
            Thread.CurrentThread.CurrentCulture = Culture;
            Thread.CurrentThread.CurrentUICulture = Culture;
        }

    }

}