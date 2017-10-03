using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

//Namespaces para trabalhar com arquivos
using Microsoft.Win32;//Contem as janelas de dialogo abrir gravar
using System.IO;
using System.Reflection;
using System.Windows.Media.Media3D;

//Namespace da biblioteca appmanager
using AppManager;

namespace Aula_02
{
    /// <summary>
    /// Interaction logic for Arquivo.xaml
    /// </summary>
    public partial class Arquivo : Window
    {
        //Variaveis publicas
        private string caminho = "";

        //Janela de dialogo abrir arquivo/Salvar Arquivo
        private OpenFileDialog DialogoAbrir = null;
        private SaveFileDialog DialogoSalvar = null;


        public Arquivo()
        {
            InitializeComponent();

            //Janela abrir
            DialogoAbrir = new OpenFileDialog();
            DialogoAbrir.Filter = "txt|*.txt";
            DialogoAbrir.AddExtension = true;
            //Define o metodo que será executado quando precionado OK na janela abrir arquivo
            DialogoAbrir.FileOk += AbrirArquivoOK;

            //Janela salvar
            DialogoSalvar = new SaveFileDialog();
            DialogoSalvar.Filter = "txt|*.txt";
            DialogoSalvar.AddExtension = true;
            DialogoSalvar.FileOk += GravarArquivoOK;
        }

        //Abrir o arquivo
        private void Abrir_Click(object sender, RoutedEventArgs e)
        {
            DialogoAbrir.ShowDialog();
        }


        private void AbrirArquivoOK(Object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextReader reader = null;
            try
            {
                throw new System.ArgumentException("Parameter cannot be null, original");

                caminho = DialogoAbrir.FileName;
                FileInfo info = new FileInfo(caminho);
                NomeArquivo.Text = caminho;
                //Abre o arquivo para operação de leitura
                reader = info.OpenText();

                //Lê a primeira linha do arquivo
                string line = reader.ReadLine();
                //Repete enquanto tiver linha para ler
                while (line != null)
                {
                    //Coloca a linha no conteúdo
                    Conteudo.Text += line + "\n";
                    //Lê a próxima linha
                    line = reader.ReadLine();
                }

                Salvar.IsEnabled = false;
            }
            catch (Exception exception)
            {
                AppException appex = new AppException();
                appex.PathSaveExceptions = "E:\\Fatec\\4º Semestre\\Aulas-CSharp-master\\Aula-02";
                appex.SaveException(exception);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        //Ações do botão salvar
        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            SalvarArquivo();
        }

        //Ações do botão salvar como
        private void SalvarComo_Click(object sender, RoutedEventArgs e)
        {
            DialogoSalvar.ShowDialog();
        }

        private void GravarArquivoOK(object sender, System.ComponentModel.CancelEventArgs e)
        {
            caminho = DialogoSalvar.FileName;
            SalvarArquivo();
        }

        //Salva os dados no arquivo
        private void SalvarArquivo()
        {
            if (caminho.Trim() == "")
            {
                DialogoSalvar.ShowDialog();
            }

            //Grava conteúdo editado no caminho definido
            File.WriteAllText(caminho, Conteudo.Text, Encoding.UTF8);

            Salvar.IsEnabled = false;
            SalvarComo.IsEnabled = false;
        }

        //Ações do botão fechar
        private void Fechar_Click(object sender, RoutedEventArgs e)
        {
            //if (MessageBox.Show("Deseja realmente sair", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult resposta = MessageBox.Show("Deseja Salvar antes de Sair?", "Sair", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (resposta == MessageBoxResult.Yes)
            {
                //Salva e sai normalmente
                if (DialogoSalvar.ShowDialog() == true)
                {
                    SalvarArquivo();
                }
                else e.Cancel = true;
            }

            else if (resposta == MessageBoxResult.No)
            {
                //Sai sem salvar
            }

            else
            {
                //Cancela o processo
                e.Cancel = true;
            }

        }

        private void Conteudo_TextChanged(object sender, TextChangedEventArgs e)
        {
            Salvar.IsEnabled = true;
            SalvarComo.IsEnabled = true;
        }
    }
}
