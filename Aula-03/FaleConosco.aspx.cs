using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;
using System.Net.Configuration;

public partial class FaleConosco : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Gravar_Click(object sender, EventArgs e)
    {
        string remetenteEmail = "contatorafaelagomes2@gmail.com"; //O e-mail do remetente
        MailMessage mail = new MailMessage();
        mail.To.Add(Email.Text);
        mail.From = new MailAddress(remetenteEmail, "Rafaela Gomes", System.Text.Encoding.UTF8);
        mail.Subject = "Fale Conosco - Fatec";
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "<table><tr><td><br/><b> Olá " + Nome.Text + ",<br/><br/> Obrigado por se cadastrar no Fatec Americana <br/></strong><b>" + Email.Text + "</b>,<br/><br/>" + Mensagem.Text + "<br/><br/>Obrigado <br/>Rafaela Gomes de Miranda</td ></tr></table>";
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High; //Prioridade do E-Mail

        SmtpClient client = new SmtpClient();  //Adicionando as credenciais do seu e-mail e senha:
        client.Credentials = new System.Net.NetworkCredential(remetenteEmail, "rafaela12345");

        client.Port = 587; // Esta porta é a utilizada pelo Gmail para envio
        client.Host = "smtp.gmail.com"; //Definindo o provedor que irá disparar o e-mail
        client.EnableSsl = true; //Gmail trabalha com Server Secured Layer
        try
        {
            client.Send(mail);
            respostaEnvioLabel.Text = "Envio do E-mail com sucesso";
            respostaEnvioLabel.Visible = true;
        }
        catch (Exception ex)
        {
            respostaEnvioLabel.Text = "Ocorreu um erro ao enviar:" + ex.Message;
            respostaEnvioLabel.Visible = true;
        }
    }
}