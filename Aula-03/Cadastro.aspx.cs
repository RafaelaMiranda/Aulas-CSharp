using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//    BIBLIOTECAS PARA BANCO DE DADOS
using System.Data;
using AppDatabase;

public partial class Cadastro : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
      if (! IsPostBack)
      {
         LoadCompetencias();
      }
   }

   // referencia de strings de conexão:https://www.connectionstrings.com

   static string banco = HttpContext.Current.Server.MapPath("~/app_data/BancoCompetencias.accdb");

   string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + banco + ";Persist Security Info=False;";

   // CRIA UMA instancia da classe de transação com DB
   AppDatabase.OleDBTransaction ole = new OleDBTransaction();

   // CARREGA AS COMPETENCIAS NO CHECKBOXLIST
   protected void LoadCompetencias()
   {
      ole.ConnectionString = conexao;
      DataTable tb = (DataTable)ole.Query("SELECT * FROM Competencias ORDER BY Nome;");

      for(int i=0; i<= tb.Rows.Count -1; i++)
      {
         Competencias.Items.Add(new ListItem(tb.Rows[i]["Nome"].ToString(), tb.Rows[i]["CompetenciaId"].ToString()));
      }
   }


   protected void Gravar_Click(object sender, EventArgs e)
   {
      if (Nome.Text.Trim() == "")
      {
         MsgErro.Text = "O Nome deve ser digitado";
      }
      else if (Email.Text.Trim() == "")
      {
         MsgErro.Text = "O email deve ser digitado";
      }
      else
      {
         string sql = "INSERT INTO Candidatos(Nome,Email,Telefone,Resumo) VALUES('" + Nome.Text + "','" + Email.Text + "','" + Telefone.Text + "','" + Resumo.Text + "');";

         ole.ConnectionString = conexao;
         if ((int)ole.Query(sql) == 1)
         {
            //OBTEM O ID DO CANDIDATO QUE FOI INSERIDO
            DataTable t = (DataTable)ole.Query("SELECT MAX(CandidatoId) AS ID FROM Candidatos");
            string candidatoId = t.Rows[0]["ID"].ToString();

            // grava as competencias do candidato
            GravaCompetencias(candidatoId);

            Entrada.Visible = false;
            fimCadastro.Visible = true;
            limpar();
         }
         else
         {
            MsgErro.Text = "Houve uma falha no cadastro, tente novamente.";
         }
      }
   }

   private void limpar()
   {
      Nome.Text = "";
      Email.Text = "";
      Telefone.Text = "";
      Resumo.Text = "";
   }


   private void GravaCompetencias( string candidatoId)
   {
      // GRAVA AS COMPETENCIAS DO CANDIDATO 

      ole.ConnectionString = conexao;

      for (int i = 0; i <= Competencias.Items.Count - 1; i++)
      {
         if (Competencias.Items[i].Selected)
         {
           string comando = "INSERT INTO CandidatosCompetencias(CompetenciaId,CandidatoId) VALUES(" + Competencias.Items[i].Value.ToString() + "," + candidatoId + ");";

            ole.Query(comando);
         }
      }
   }
}