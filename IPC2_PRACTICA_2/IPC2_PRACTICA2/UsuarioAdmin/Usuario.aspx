<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="IPC2_Practica.UsuarioAdmin.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">      
    <!-- Cargar datos -->
    <h1 class="major">Carga Masiva De Datos</h1>
     <p>
         <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="Black" />
         <asp:Button ID="Button1" runat="server" Text="Importar y Guardar Datos" OnClick="Button1_Click" />
         <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
     </p>
</asp:Content>
