<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fose.aspx.cs" Inherits="proyecto.Areas.Admin.formatos.fose" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="650px" Width="714px">
            <LocalReport ReportPath="Areas\Admin\formatos\rptfose.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSourcefose" Name="DataSetpro" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:SqlDataSource ID="SqlDataSourcefose" runat="server" ConnectionString="<%$ ConnectionStrings:ProyectoContext %>" SelectCommand="RPT2_fose_generate" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="idorden" QueryStringField="idorden" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
