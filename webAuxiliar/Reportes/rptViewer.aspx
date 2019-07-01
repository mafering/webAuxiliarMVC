<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptViewer.aspx.cs" 
    Inherits="webAuxiliar.Reportes.rptViewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" 
             Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <%--<asp:Panel ID="pnlParentResults" runat="server" ScrollBars="None" CssClass="ParentPanel">--%>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer
            ID="rvDataViewer" 
            runat="server"
            Font-Names="Verdana" 
            Font-Size="8pt" 
            ShowPrintButton="False" 
            ShowRefreshButton="False"
            ShowZoomControl="False" 
            style="Width:99.5%; overflow-x:hidden; overflow-y:scroll;">
        </rsweb:ReportViewer>
    </div>
        
   <%-- </asp:Panel>
       <%--<div style="overflow:scroll; margin-bottom:16px; height: 459px;">--%>
       
       <%--ProcessingMode="Local"--%>
            <%--AsyncRendering="false"--%>
            <%--SizeToReportContent="True"--%>
        <%--WaitMessageFont-Names="Verdana"--%>
        <%--WaitMessageFont-Size="14pt"--%>
        <%--Height="288px"--%>
        <%--&nbsp;&nbsp;&nbsp;&nbsp;--%>
    
        
    
        
    </form>

</body>
</html>