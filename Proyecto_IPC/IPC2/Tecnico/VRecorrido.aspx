<%@ Page Title="" Language="C#" MasterPageFile="~/UTecnico.Master" AutoEventWireup="true" CodeBehind="VRecorrido.aspx.cs" Inherits="IPC2.Tecnico.VRecorrido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Ingrese nombre del tecnico"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Visualizar" CssClass="button primary" OnClick="Button1_Click" />
    </p>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </asp:Panel>
</asp:Content>