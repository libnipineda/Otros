<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="IPC2.Usuario.Consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Button ID="Button1" runat="server" Text="Consulta 1" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Consulta 2" OnClick="Button2_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="Consulta 3" OnClick="Button3_Click" />
    </p>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="False">
        <asp:GridView ID="GridView2" runat="server"></asp:GridView>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" Visible="False">
        <asp:GridView ID="GridView3" runat="server"></asp:GridView>
    </asp:Panel>
</asp:Content>
