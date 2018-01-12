<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FaleConosco.aspx.cs" Inherits="FaleConosco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-1 header">
                <h1>FALE CONOSCO</h1>
            </div>
        </div>
        <!-- Form de entrada de dados -->
        <div id="Entrada" runat="server" visible="true">
            <div class="row">
                <div class="col-2">
                        <label>Nome</label>
                        <asp:HiddenField ID="CandidatoId" runat="server" />
                        <asp:TextBox ID="Nome" CssClass="form-control" runat="server"></asp:TextBox>

                        <label>Email</label>
                        <asp:TextBox ID="Email" CssClass="form-control" runat="server"></asp:TextBox>

                        <label>Telefone</label>
                        <asp:TextBox ID="Telefone" CssClass="form-control" runat="server"></asp:TextBox>
                        
                        <label>Mensagem</label>
                        <asp:TextBox ID="Mensagem" CssClass="form-control" runat="server" Height="100px"></asp:TextBox>
                </div>
                <div class="col-2">
                        <div id="map" style="height: 380px; width: 100%;"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-2">
                    <div class="box">
                        <asp:Button ID="Gravar" OnClick="Gravar_Click" Font-Size="16px" Style="padding: 10px;" Text="Enviar" runat="server" />
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div class="box box-border" id="MensagemFinal" runat="server" visible="false">
                    <asp:Label ID="respostaEnvioLabel" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
    </div>
    
    <script>
        function initMap() {
            var uluru = {
                lat: -22.7397892,
                lng: -47.3503339
            };

            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 15,
                center: uluru
            });

            var marker = new google.maps.Marker({
                position: uluru,
                map: map
            });
        }
    </script>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBvfFnWBMaEf7nyYOCKSSWDu4nBJd31ixw&callback=initMap"></script>
</asp:Content>

