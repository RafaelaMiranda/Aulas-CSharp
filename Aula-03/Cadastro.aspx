<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cadastro.aspx.cs" Inherits="Cadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h1>Cadastro de Candidatos</h1>
        <h4>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam blandit velit nisl, quis aliquet leo rutrum vestibulum. Nulla malesuada velit ipsum, et scelerisque est sagittis vel. Morbi et viverra lacus. Integer rutrum lectus luctus, consectetur nunc nec, ullamcorper ex. Aenean non hendrerit diam. Aenean fringilla enim vel dui aliquam, ut pretium dui sodales. Duis ut lacus gravida, finibus ante nec, pulvinar augue. Cras vestibulum justo mattis mauris hendrerit, sed feugiat augue aliquet. Morbi nec mauris mauris. Ut lobortis iaculis posuere. Etiam vestibulum auctor porta. Sed id iaculis dui.</h4>
    </div>
    
    <!-- FORMULÁRIO -->
    <div id="Entrada" runat="server" Visible="True">
        <asp:Label id="MsgErro" runat="server"></asp:label>
        <label>Nome</label>
        <asp:TextBox runat="server" ID="Nome"></asp:TextBox>
        <label>Email</label>
        <asp:TextBox runat="server" ID="Email"></asp:TextBox>
        <label>Telefone</label>
        <asp:TextBox runat="server" ID="Telefone"></asp:TextBox>
        <label>Resumo</label>
        <asp:TextBox runat="server" ID="Resumo"></asp:TextBox>
        <asp:Button Text="Gravar" runat="server"  ID="Gravar" OnClick="Gravar_OnClick"/>
        <br/>
    </div>
    <div id="fimCadastro" runat="server" Visible="False">
        <h2>Seus dados foram registrados com sucesso!</h2>
        <h4>Obrigado por participar.</h4>
    </div>
</asp:Content>



