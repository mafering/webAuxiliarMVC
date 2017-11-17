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
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer
            AsyncRendering="false" 
            ID="rvDataViewer" 
            runat="server" 
            SizeToReportContent="true"
            Width="90%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ShowPrintButton="False">
            <%--<LocalReport 
                ReportPath="Reportes\RDLC\rptAuxObra.rdlc">
            </LocalReport>--%>
        </rsweb:ReportViewer>
        &nbsp;&nbsp;&nbsp;
    </div>
    </form>
</body>
</html>