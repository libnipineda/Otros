<%@ Page Title="" Language="C#" MasterPageFile="~/UTecnico.Master" AutoEventWireup="true" CodeBehind="GRevision.aspx.cs" Inherits="IPC2.Tecnico.GRevision" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
       <asp:Label ID="Label1" runat="server" Text="Label">Ingrese nombre de la empresa incrita en el instituto de turismo</asp:Label>
       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
       <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="button primary" OnClick="Button1_Click" />
    </p>
    <asp:GridView ID="GridView1" runat="server" Visible="False"></asp:GridView>
</asp:Content>