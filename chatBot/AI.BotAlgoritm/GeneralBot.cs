/*
 * Создано в SharpDevelop.
 * Пользователь: admin
 * Дата: 18.11.2017
 * Время: 19:27
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;

namespace AI.BotAlgoritm
{
	/// <summary>
	/// Description of GeneralBot.
	/// </summary>
	public class GeneralBot
	{
		
		BotBase bb;
		TextClassifier tC;
		
		public GeneralBot(string pathToDirectory)
		{
			tC = new TextClassifier(pathToDirectory);
		}
		
		
		public string GetAnswer(string q)
		{
			int index = tC.RecognClass(q);
			string path = tC.textModel._paths[index];
			path = path.Split('.')[0];
			bb = new BotBase(path);
			return bb.GetAnswer(q);
		}
		
	}
}
