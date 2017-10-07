﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cadastro.aspx.cs" Inherits="Cadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h1>Cadastro de Candidatos</h1>
        <h4>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam blandit velit nisl, quis aliquet leo rutrum vestibulum. Nulla malesuada velit ipsum, et scelerisque est sagittis vel. Morbi et viverra lacus. Integer rutrum lectus luctus, consectetur nunc nec, ullamcorper ex. Aenean non hendrerit diam. Aenean fringilla enim vel dui aliquam, ut pretium dui sodales. Duis ut lacus gravida, finibus ante nec, pulvinar augue. Cras vestibulum justo mattis mauris hendrerit, sed feugiat augue aliquet. Morbi nec mauris mauris. Ut lobortis iaculis posuere. Etiam vestibulum auctor porta. Sed id iaculis dui.</h4>
    </div>
    <!-- FORMULÁRIO -->
    <div id="Entrada" runat="server" visible="True">
        <div style="float: left; width: 40%;">
            <asp:Label ID="MsgErro" runat="server" style="color: red; font-weight: bold"></asp:Label>
            <br />
            <label>Nome</label>
            <asp:TextBox runat="server" ID="Nome"></asp:TextBox>
            <label>Email</label>
            <asp:TextBox runat="server" ID="Email"></asp:TextBox>
            <label>Telefone</label>
            <asp:TextBox runat="server" ID="Telefone"></asp:TextBox>
            <label>Resumo</label>
            <asp:TextBox runat="server" ID="Resumo"></asp:TextBox>
            <br /><br />
            <asp:Button Text="Gravar" runat="server" ID="Gravar" OnClick="Gravar_OnClick"/>
        </div>
        <!-- FORMULÁRIO DAS COMPETENCIAS -->
        <div style="float: left; width: 35%;" margin-left: 30px;>
            <h3>Suas competências</h3>
            <hr/>
            <asp:CheckBoxList runat="server" ID="Competencias" Font-Size="14px" RepeatDirection="Vertical"/>
        </div>
    </div>
    <div id="fimCadastro" runat="server" visible="False">
        <h2>Seus dados foram registrados com sucesso!</h2>
        <h4>Obrigado por participar.</h4>
    </div>
</asp:Content>



