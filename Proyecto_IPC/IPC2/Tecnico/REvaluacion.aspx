<%@ Page Title="" Language="C#" MasterPageFile="~/UTecnico.Master" AutoEventWireup="true" CodeBehind="REvaluacion.aspx.cs" Inherits="IPC2.Tecnico.REvaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label">Ingrese nombre de la empresa</asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" ForeColor="Black"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="button primary" OnClick="Button1_Click" />
    </p>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <asp:Label ID="Label2" runat="server" Text="Label">Ingrese estado de la evaluación</asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
        <asp:Button ID="Button2" runat="server" Text="Aceptar" CssClass="button icon" OnClick="Button2_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Button3" runat="server" Text="Rechazar" CssClass="button icon" OnClick="Button3_Click" />
    </asp:Panel>    
</asp:Content>
