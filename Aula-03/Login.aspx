<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
   <asp:Panel ID="Panel1" DefaultButton="entrar" runat="server">

      <div style="width: 240px;">
         <asp:Label ID="Mensagem" Visible="false" runat="server" CssClass="label-error" />
         <label>Nome</label>
         <asp:TextBox ID="Nome" CssClass="form-control" runat="server" />

         <label>Senha</label>
         <asp:TextBox ID="Senha" CssClass="form-control" TextMode="Password" runat="server" />
         <br />
         <br />
         <asp:Button ID="Entrar" CssClass="form-control" runat="server" OnClick="Entrar_Click" Text="Entrar" />
      </div>
   </asp:Panel>

</asp:Content>

