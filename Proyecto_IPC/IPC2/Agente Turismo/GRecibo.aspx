<%@ Page Title="" Language="C#" MasterPageFile="~/UAgenteMaster.Master" AutoEventWireup="true" CodeBehind="GRecibo.aspx.cs" Inherits="IPC2.Agente_Turismo.GRecibo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label">Ingrese empresa</asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>        
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="button small" OnClick="Button1_Click" />
    </p>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>        
        <p>
            <asp:Button ID="Button2" runat="server" Text="Generar" CssClass="button primary" OnClick="Button2_Click" />
        </p>
    </asp:Panel>    
</asp:Content>
