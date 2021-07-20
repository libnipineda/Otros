<%@ Page Title="" Language="C#" MasterPageFile="~/UAdmin.Master" AutoEventWireup="true" CodeBehind="Reporte1.aspx.cs" Inherits="IPC2.Administrador.Reporte1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" BorderColor="Black" BorderStyle="Dotted" ShowAllPageIds="True" ValidateRequestMode="Enabled" ToolPanelView="None" />
<p>
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="C:\Users\libni\source\repos\IPC-Proyecto\IPC2\IPC2\Reportes\CrystalReport1.rpt">
        </Report>
    </CR:CrystalReportSource>
</p>
</asp:Content>