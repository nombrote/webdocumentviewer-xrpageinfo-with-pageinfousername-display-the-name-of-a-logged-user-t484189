Imports System
Imports System.Web.Http
Imports DevExpress.XtraReports.Web.WebDocumentViewer
Imports WebDocumentViewer_UserName.Services

Namespace WebDocumentViewer_UserName
    ' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    ' visit http://go.microsoft.com/?LinkId=9394801

    Public Class MvcApplication
        Inherits System.Web.HttpApplication

        Protected Sub Application_Start()
            DevExpress.XtraReports.Web.WebDocumentViewer.Native.WebDocumentViewerBootstrapper.SessionState = System.Web.SessionState.SessionStateBehavior.ReadOnly
            AreaRegistration.RegisterAllAreas()

            GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
            RouteConfig.RegisterRoutes(RouteTable.Routes)

            ModelBinders.Binders.DefaultBinder = New DevExpress.Web.Mvc.DevExpressEditorsBinder()

            AddHandler DevExpress.Web.ASPxWebControl.CallbackError, AddressOf Application_Error

            DefaultWebDocumentViewerContainer.Register(Of WebDocumentViewerOperationLogger, CustomWebDocumentViewerOperationLogger)()
        End Sub

        Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
            Dim exception As Exception = Server.GetLastError()
            'TODO: Handle Exception
        End Sub
    End Class
End Namespace