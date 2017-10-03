using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManager
{
    public class AppException
    {
        #region PROPERTIES
        private string m_pathSaveExceptions = Directory.GetCurrentDirectory();

        /// <summary>
        /// Obtem ou define o caminho onde será gravado o arquivo Exceptions.txt
        /// </summary>

        public string PathSaveExceptions
        {
            get { return m_pathSaveExceptions; }
            set { m_pathSaveExceptions = value; }
            
        }
        #endregion

        ///<summary>
        /// Método para salvar os dados da exceção no arquivo Exceptions.txt
        ///</summary>
        /// <param name="exception">Classe Exception com os dados da última exceção ocorrida</param>
        public void SaveException(Exception exception)
        {
            string message = "Data: " + DateTime.Now + "\r\n";
            message += "Erro: " + exception.Message + "\r\n";
            message += "Arquivo: " + exception.Source + "\r\n";
            message += "Tipo: " + exception.GetType().FullName + "\r\n";

            StackFrame stackFrame = new StackFrame(50, true);

            message += "Método: " + stackFrame.GetMethod() + "\r\n";
            message += "Linha:" + stackFrame.GetFileLineNumber() + "\r\n";
            message += "----------------------------------------------------\r\n";

            string CaminhoNome = m_pathSaveExceptions + "\\Exceptions.txt";

            File.AppendAllText(CaminhoNome, message);
        }
    }
}
  
