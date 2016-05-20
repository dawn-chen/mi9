using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mi9
{
    /// <summary>
    /// override the default Json model binder, so that controller can have a chance to raise 400 bad request
    /// otherwise, mvc framework will always throw 500 for invalid jason parameter
    /// </summary>
    public class JsonModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (!IsJSONRequest(controllerContext))
            {
                return base.BindModel(controllerContext, bindingContext);

            }
            try
            {                
                var request = controllerContext.HttpContext.Request;
                var jsonStringData = new StreamReader(request.InputStream).ReadToEnd();
                var targetType = bindingContext.ModelMetadata.ModelType;
                return JsonConvert.DeserializeObject(jsonStringData, targetType);
            }
            catch (Exception)
            {
                //swallow the exception , so that no 500 error return;
                return null;
            }
        }

        private static bool IsJSONRequest(ControllerContext controllerContext)
        {
            var contentType = controllerContext.HttpContext.Request.ContentType; 
            return contentType.Contains("application/json");
        }

    }

   
}