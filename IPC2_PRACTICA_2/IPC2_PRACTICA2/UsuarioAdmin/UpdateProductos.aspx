<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateProductos.aspx.cs" Inherits="IPC2_Practica.UsuarioAdmin.UpdateProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="major">Modificar o Eliminar Insumos</h1>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Ingrese código del producto"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" />        
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" Visible="False" CellSpacing="2"></asp:GridView>
        <asp:Panel ID="Panel1" runat="server" Visible="False">          
        <p>
          <asp:Label ID="Label3" runat="server" Text="Ingrese una descripción"></asp:Label>
          <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
        </p>                    
        <p>
          <asp:Label ID="Label4" runat="server" Text="Ingrese Costo por Unidad"></asp:Label>
          <asp:TextBox ID="TextBox3" runat="server" TextMode="Number" ForeColor="Black"></asp:TextBox>
        </p>                 
            <p>
                <asp:Label ID="Label5" runat="server" Text="Seleccione el tipo de producto"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombreT" DataValueField="nombreT"></asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConexionSql %>" SelectCommand="SELECT [nombreT] FROM [tipo]"></asp:SqlDataSource>
            </p>            
            <p>
                <asp:Label ID="Label6" runat="server" Text="Seleccione material del producto"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="nombreM" DataValueField="nombreM"></asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConexionSql %>" SelectCommand="SELECT [nombreM] FROM [material]"></asp:SqlDataSource>
            </p>
            <p>
                <asp:Label ID="Label7" runat="server" Text="Seleccione el color del producto"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList3" runat="server" DataSourceID="SqlDataSource3" DataTextField="nombre" DataValueField="nombre"></asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConexionSql %>" SelectCommand="SELECT [nombre] FROM [color]"></asp:SqlDataSource>
            </p>
        </asp:Panel>
    </p>
     <p>
        <asp:Button ID="Button2" runat="server" Text="Actualizar" OnClick="Button2_Click" Visible="False" />
        &nbsp;  &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp;
        <asp:Button ID="Button3" runat="server" Text="Eliminar" OnClick="Button3_Click" Visible="False" />
     </p>
</asp:Content>
