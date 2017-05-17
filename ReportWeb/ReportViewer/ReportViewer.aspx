<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="ReportWeb.ReportViewer.ReportViewer" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style> html,body,form,#div1 { height: 100%;
                                   width: 100%;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="div1">
            <rsweb:ReportViewer ID="reportViewer" runat="server" Height="100%" Width="100%"><ServerReport ReportPath="J:\Users\Byron\Documents\Visual Studio 2017\Projects\ReportWeb\ReportWeb\Reports\Sales_Order_Detail_2008R2.rdlc" ReportServerUrl="" /></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
