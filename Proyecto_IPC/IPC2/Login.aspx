<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IPC2.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
         <p>
             <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
             <asp:TextBox ID="TextBox1" runat="server" placeholder="Ej: Libnipineda" BorderStyle="Groove"></asp:TextBox>
         </p>
         <p>
             <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
             <asp:TextBox ID="TextBox2" runat="server" type="password" placeholder="Ej: ********" BorderStyle="Groove"></asp:TextBox>
         </p>
         <p>
             <asp:Button ID="Button1" runat="server" Text="Sign in" OnClick="Button1_Click1" BorderStyle="Dotted" CssClass="button primary" />
         </p>     
</asp:Content>