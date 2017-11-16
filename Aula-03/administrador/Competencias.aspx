<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Competencias.aspx.cs" Inherits="administrador_CandidatosEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <!-- BUSCAR -->
   <div style="padding: 20px;">
      <asp:TextBox ID="BuscarNome" Width="180px" CssClass="form-control" runat="server"></asp:TextBox>
      <asp:Button ID="Buscar" Width="80px" OnClick="Buscar_Click" runat="server" Text="Buscar" />
      <asp:Button ID="LimparBusca" Visible="false" Width="50px" OnClick="LimparBusca_Click" runat="server" Text="X" />
   </div>
   <!-- GRID -->
   <div style="padding: 20px;">
      <asp:Label ID="Label2" runat="server" ForeColor="#ff6a00" Font-Size="30px" Text="Lista de Competencias" />
      <br />
      <asp:Panel ID="Panel1" Height="300px" ScrollBars="Vertical" runat="server">
         <asp:GridView ID="Competencia" Width="100%" AutoGenerateColumns="true" AutoGenerateSelectButton="true" OnSelectedIndexChanged="Competencias_SelectedIndexChanged" CellPadding="8" HeaderStyle-BackColor="#dfdfdf" BorderColor="#cccccc" runat="server">
         </asp:GridView>
      </asp:Panel>
   </div>
   <!-- CONTROLES DE EDIÇÃO -->
   <div style="padding: 20px;">
      <!-- FORMULÁRIO DE CADASTRO -->
      <div style="float: left; width: 40%;">
         <asp:Label ID="MsgErro" runat="server" Style="color: red; font-weight: bold" />
         <br />

          <asp:label ID="CompetenciaId" CssClass="form-control" runat="server"></asp:label>

         <label>Nome</label>
         <asp:TextBox ID="Nome" CssClass="form-control" runat="server"></asp:TextBox>
         <br />
         <br />
         <asp:Button ID="Gravar" Enabled="true" OnClick="Gravar_Click" runat="server" Text="Gravar" />
         <br /><br />
         <asp:Button ID="Excluir" Visible="False" OnClick="Excluir_Click" runat="server" Text="Excluir" />
         <br /><br />
      </div>
   </div>
   <div style="clear:both;"></div>

</asp:Content>

