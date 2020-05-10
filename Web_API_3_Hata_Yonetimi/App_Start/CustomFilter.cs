using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Web_API_3_Hata_Yonetimi.App_Start
{
    public class CustomFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage hataMesaji = new HttpResponseMessage(System.Net.HttpStatusCode.NotImplemented);
            hataMesaji.ReasonPhrase = actionExecutedContext.Exception.Message;
            actionExecutedContext.Response = hataMesaji;
            base.OnException(actionExecutedContext);
        }
    }
}