/*
 * Создано в SharpDevelop.
 * Пользователь: admin
 * Дата: 09.11.2017
 * Время: 23:54
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace ChatBot
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}
		
		
		void inputText_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Enter) AllText.Text = inputText.Text;
		}
	}
}