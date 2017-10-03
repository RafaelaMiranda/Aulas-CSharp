using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// BIBLIOTECA PARA O BANCO DE DADOS
using System.Data;
using AppDatabase;

public partial class Cadastro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // REFERENCIAS DE STRINGS DE CONEXÃO: https://www.connectionstrings.com/

    static string banco = HttpContext.Current.Server.MapPath("~/app_data/bancodados.accdb");
    string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + banco + ";Persist Security Info=False;";

    protected void Gravar_OnClick(object sender, EventArgs e)
    {
        string sql = "INSERT INTO Cadastro (Nome, Email, Telefone, Resumo) VALUES('" + Nome.Text + "','" + Email.Text + "','" + Telefone.Text + "','" + Resumo.Text + "');";

        // CRIA UMA INSTÂNCIA DA CLASSE DE TRANSAÇÃO
        AppDatabase.OleDBTransaction ole = new OleDBTransaction();
        ole.ConnectionString = conexao;
        if ((int) ole.Query(sql) == 1)
        {
            Entrada.Visible = false;
            fimCadastro.Visible = true;
        }
        else
        {
            MsgErro.Text = "Houve uma falha no cadastro, tente novamente";
        }

       }
}