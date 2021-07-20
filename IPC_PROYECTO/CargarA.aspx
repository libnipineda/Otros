<%@ Page Title="" Language="C#" MasterPageFile="~/UAdmin.Master" AutoEventWireup="true" CodeBehind="CargarA.aspx.cs" Inherits="_IPC2_Fase2.CargarA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1 class="major">Carga Masiva De Datos</h1>
    <form id="form1" runat ="server">
      <p>
          <asp:Button ID="Button1" runat="server" Text="Importar Archivos" OnClick="Button1_Click" />
      </p>
        <p>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </p>
    </form>
</asp:Content>
