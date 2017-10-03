﻿using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aula_01
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			nome.Focus();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Olá " + nome.Text);
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			Controles formControles = new Controles();
			formControles.Show();
		}

		private void MenuItem_Click_2(object sender, RoutedEventArgs e)
		{
			MessageBoxResult resultado = System.Windows.MessageBox.Show("Deseja realmente sair da janela? ", "Finalização", MessageBoxButton.YesNo,
				MessageBoxImage.Question);

			if (resultado == MessageBoxResult.Yes)
			{
				this.Close();
			}
		}
	}
}
