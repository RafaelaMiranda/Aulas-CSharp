using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.IO;
using AppDatabase;

public partial class administrador_CandidatosEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCompetencias();
        }
    }

    // referencia de strings de conexão:https://www.connectionstrings.com

    static string banco = HttpContext.Current.Server.MapPath("~/app_data/BancoCompetencias.accdb");

    string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + banco + ";Persist Security Info=False;";

    // CRIA UMA instancia da classe de transação com DB
    AppDatabase.OleDBTransaction ole = new OleDBTransaction();

    protected void LoadCompetencias()
    {
        ole.ConnectionString = conexao;
        DataTable tb = (DataTable)ole.Query("SELECT * FROM Competencias WHERE Nome LIKE '%" + BuscarNome.Text + "%' ORDER BY CompetenciaId;");
        Competencia.DataSource = tb;
        Competencia.DataBind();
    }

    private void limpar()
    {
        CompetenciaId.Value = "";
        Nome.Text = "";
        MsgErro.Text = "";
        LoadCompetencias();
    }

    protected void Buscar_Click(object sender, EventArgs e)
    {
        LimparBusca.Visible = true;
        LoadCompetencias();
    }

    protected void LimparBusca_Click(object sender, EventArgs e)
    {
        BuscarNome.Text = "";
        LimparBusca.Visible = false;
        LoadCompetencias();
    }

    protected void Competencias_SelectedIndexChanged(object sender, EventArgs e)
    {
        ole.ConnectionString = conexao;
        DataTable tb = (DataTable)ole.Query("SELECT * FROM Competencias WHERE CompetenciaId=" + Competencia.SelectedRow.Cells[1].Text.ToString());
        if (tb.Rows.Count == 1)
        {
            CompetenciaId.Value = tb.Rows[0]["CompetenciaId"].ToString();
            Nome.Text = tb.Rows[0]["Nome"].ToString();

            // Ativa os botões
            Gravar.Enabled = true;
            Excluir.Visible = true;
        }
    }

    protected void Excluir_Click(object sender, EventArgs e)
    {
        ole.ConnectionString = conexao;
        ole.Query("DELETE FROM Competencias WHERE CompetenciaId=" + CompetenciaId.Value + ";");
        limpar();
    }



    protected void Gravar_Click(object sender, EventArgs e)
    {
        ole.ConnectionString = conexao;
        if (Nome.Text.Trim() == "")
        {
            MsgErro.Text = "O Nome deve ser digitado";
            MsgErro.Visible = true;
        }
        else
        {
            if (CompetenciaId.Value == "")
            {
                Gravar_Click();

            }

            else
            {
                Editar_Click();
            }

        }
    }

    protected void Editar_Click()
    {
        ole.ConnectionString = conexao;
        ole.Query("UPDATE Competencias SET Nome='" + Nome.Text + "' WHERE CompetenciaId=" + CompetenciaId.Value + " ;");
        limpar();
    }


    protected void Gravar_Click()
    {
        ole.ConnectionString = conexao;
        ole.Query("INSERT INTO Competencias(Nome) VALUES('" + Nome.Text + "');");
        limpar();
    }
}