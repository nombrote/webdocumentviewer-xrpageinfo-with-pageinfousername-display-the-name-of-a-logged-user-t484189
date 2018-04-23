using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using WebDocumentViewer_UserName.Services;

namespace WebDocumentViewer_UserName {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DevExpress.XtraReports.Web.WebDocumentViewer.Native.WebDocumentViewerBootstrapper.SessionState = System.Web.SessionState.SessionStateBehavior.ReadOnly;
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder();

            DevExpress.Web.ASPxWebControl.CallbackError += Application_Error;

            DefaultWebDocumentViewerContainer.Register<WebDocumentViewerOperationLogger, CustomWebDocumentViewerOperationLogger>();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            //TODO: Handle Exception
        }
    }
}