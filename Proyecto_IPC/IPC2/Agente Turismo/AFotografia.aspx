<%@ Page Title="" Language="C#" MasterPageFile="~/UAgenteMaster.Master" AutoEventWireup="true" CodeBehind="AFotografia.aspx.cs" Inherits="IPC2.Agente_Turismo.AFotografia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Nombre del sitio turistico: <asp:Label ID="name" runat="server" Text="Label"></asp:Label>
     <p>
        <br / /> Inserte Imagen
        <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="Black" />                                 
        <br /> Ingrese titulo de imagen:        
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> 
        </p>    
    <p>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="nombre"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Conexion %>" SelectCommand="SELECT [nombre] FROM [Region]"></asp:SqlDataSource>
    </p>    
    <p>
      <asp:Button ID="Button1" runat="server" Text="Registrar datos de sitio turistico" OnClick="Button1_Click" CssClass="button primary" />    
    </p>
</asp:Content>
