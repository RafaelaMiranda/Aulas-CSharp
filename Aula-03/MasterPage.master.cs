using AppDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
   protected void Page_Load(object sender, EventArgs e)
   {
      if (Session["Status"] != null)
      {

         if (Session["Status"].ToString() == "1")
         {
            EditarCadastro.Visible = true;
            Competencias.Visible = true;
            Entrar.Visible = false;
            Sair.Visible = true;
         }
      }
      else
      {
         EditarCadastro.Visible = false;
         Competencias.Visible = false;
         Entrar.Visible = true;
         Sair.Visible = false;
      }
   }

   protected void Entrar_Click(object sender, EventArgs e)
   {
      Response.Redirect("~/login.aspx");
   }

   protected void Sair_Click(object sender, EventArgs e)
   {
      Response.Redirect("~/logout.aspx");
   }
}
