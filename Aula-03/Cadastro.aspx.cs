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
        if (!IsPostBack)
        {
            LoadCompetencias();
        }
    }

    // REFERENCIAS DE STRINGS DE CONEXÃO: https://www.connectionstrings.com/

    static string banco = HttpContext.Current.Server.MapPath("~/app_data/BancoCompetencias.accdb");
    string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + banco + ";Persist Security Info=False;";

    // CRIA UMA INSTÂNCIA DA CLASSE DE TRANSAÇÃO
    AppDatabase.OleDBTransaction ole = new OleDBTransaction();

    protected void Gravar_OnClick(object sender, EventArgs e)
    {

        if (Nome.Text.Trim() == "")
        {
            MsgErro.Text = "O nome deve ser digitado";
        }
        else if (Email.Text.Trim() == "")
        {
            MsgErro.Text = "O email deve ser digitado";
        }
        else
        {
            string sql = "INSERT INTO Candidatos (Nome, Email, Telefone, Resumo) VALUES('" + Nome.Text + "','" + Email.Text + "','" + Telefone.Text + "','" + Resumo.Text + "');";


            ole.ConnectionString = conexao;
            if ((int)ole.Query(sql) == 1)
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

    protected void LoadCompetencias()
    {
        ole.ConnectionString = conexao;
        DataTable tb = (DataTable) ole.Query("SELECT * FROM Competencias ORDER BY Nome;");

        for (int i = 0; i <= tb.Rows.Count - 1; i++)
        {
            Competencias.Items.Add(new ListItem(tb.Rows[i]["nome"].ToString(), tb.Rows[i]["CompetenciaId"].ToString()));
        }
    }
}