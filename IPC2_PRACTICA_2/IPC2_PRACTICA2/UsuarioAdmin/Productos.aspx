<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="IPC2_Practica.UAdmin.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Menu -->
		<nav id="menu">
			<ul class="links">
			  <li><a href="Usuario.aspx">Carga Masiva</a></li>
              <li><a href="Productos.aspx">Agregar Nuevos Productos</a></li>
              <li><a href="UpdateProductos.aspx">Gestión De Productos</a></li>			  
              <li><a href="Inventario.aspx">Inventario</a></li>
              <li><a href="consulta.aspx">Consultas</a></li>
			</ul>
			<ul class="actions vertical">							
			<li><a href="../LogOut.aspx" class="button fit">Cerrar Sesión</a></li>
			</ul>
		</nav> 
    <!-- Datos -->
    <asp:Panel ID="Panel1" runat="server">    
        <p>
          <asp:Label ID="Label1" runat="server" Text="Codigo del producto"></asp:Label>
          <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
          <asp:Label ID="Label2" runat="server" Text="Ingrese una descripción"></asp:Label>
          <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
        </p>                    
        <p>
          <asp:Label ID="Label3" runat="server" Text="Ingrese Costo por Unidad"></asp:Label>
          <asp:TextBox ID="TextBox3" runat="server" TextMode="Number" ForeColor="Black"></asp:TextBox>
        </p>                 
            <p>
                <asp:Label ID="Label4" runat="server" Text="Seleccione el tipo de producto"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombreT" DataValueField="nombreT"></asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConexionSql %>" SelectCommand="SELECT [nombreT] FROM [tipo]"></asp:SqlDataSource>
            </p>            
            <p>
                <asp:Label ID="Label5" runat="server" Text="Seleccione material del producto"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="nombreM" DataValueField="nombreM"></asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConexionSql %>" SelectCommand="SELECT [nombreM] FROM [material]"></asp:SqlDataSource>
            </p>
            <p>
                <asp:Label ID="Label6" runat="server" Text="Seleccione el color del producto"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList3" runat="server" DataSourceID="SqlDataSource3" DataTextField="nombre" DataValueField="nombre"></asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConexionSql %>" SelectCommand="SELECT [nombre] FROM [color]"></asp:SqlDataSource>
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" Text="Agregar Producto" OnClick="Button1_Click" />
                <asp:Label ID="tipo" runat="server" Text=""></asp:Label>
                <asp:Label ID="material" runat="server" Text=""></asp:Label>
                <asp:Label ID="color" runat="server" Text=""></asp:Label>
            </p>                    
    </asp:Panel>
</asp:Content>