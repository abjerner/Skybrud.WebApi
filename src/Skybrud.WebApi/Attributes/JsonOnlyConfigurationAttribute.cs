using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http.Controllers;
using Skybrud.WebApi.Formatters;

namespace Skybrud.WebApi.Attributes {
    
    public class JsonOnlyConfigurationAttribute : Attribute, IControllerConfiguration {
        
        public bool AllowCallback { get; }

        public JsonOnlyConfigurationAttribute() { }

        public JsonOnlyConfigurationAttribute(bool allowCallback) {
            AllowCallback = allowCallback;
        }

        public virtual void Initialize(HttpControllerSettings settings, HttpControllerDescriptor descriptor) {
            var toRemove = settings.Formatters.Where(t => t is JsonMediaTypeFormatter || t is XmlMediaTypeFormatter).ToList();
            foreach (var r in toRemove) {
                settings.Formatters.Remove(r);
            }
            settings.Formatters.Add(new SkybrudJsonMediaTypeFormatter(AllowCallback));
        }

    }

}